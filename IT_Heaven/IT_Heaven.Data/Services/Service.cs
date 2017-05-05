using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using IT_Heaven.Models.Models.BindingModels;
using IT_Heaven.Models.Models.DataModels;
using IT_Heaven.Models.Models.ViewModels;
using AutoMapper;
using System.Reflection;
using IT_Heaven.Models.CategoriesSemiModels;


namespace IT_Heaven.Data.Services
{

    public class Service
    {
        protected IT_HeavenADO context = new IT_HeavenADO();
        public Service()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AddArticleBindingModel, ArticleDataModel>().ForMember("Id", opt => opt.Ignore());
                cfg.CreateMap<ArticleDataModel, ArticleViewModel>().ForMember("Image", opt => opt.Ignore());
                cfg.CreateMap<ArticleDataModel, EditBindingModel>();
                cfg.CreateMap<EditBindingModel, ArticleDataModel>().IgnoreAllNonExisting();
                cfg.CreateMap<ArticleDataModel, ArticlePreviewModel>().IgnoreAllNonExisting();
                

            });
        }

        #region Public methods

        public string UserIsInRole(IPrincipal user)
        {
            if (user.IsInRole("Admin")) return "Admin";
            else if (user.IsInRole("Helper")) return "Helper";
            else return "User";
        }
        public HomeViewModel GetHomeModel()
        {
            return new HomeViewModel() { RecentlyAdded = this.RecentlyAdded("") };
        }
        public NavigationViewModel GetNavModel(int navigationId, params CategoriesInformation.CategoriesEnum[] _categoriesEnum)
        {
            var articles = new List<ArticleDataModel>[4];
            var categories = new string[4];

            if (_categoriesEnum.Length < 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        categories[i] = GetStringCategoryFromEnum(_categoriesEnum[i]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        categories[i] = "";
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                    categories[i] = GetStringCategoryFromEnum(_categoriesEnum[i]);
            }

            for (int i = 0; i < categories.Length; i++)
            {
                var tmp = categories[i];
                var additional = CategoriesInformation.CheckAndGetAdditional(tmp);
                articles[i] = context.Articles
                    .Where(a => a.Category == tmp || a.Category == additional)
                    .OrderByDescending(o => o.UploadDate)
                    .Take(10)
                    .ToList();
            }

            var returns = new IEnumerable<ArticlePreviewModel>[4];
            for (int i = 0; i < categories.Length; i++)
            {
                returns[i] = MapArticles(articles[i]);
            }

            return new NavigationViewModel()
            {
                NavigationId = navigationId,
                DummyOneCategory = categories[0],
                DummyTwoCategory = categories[1],
                DummyThreeCategory = categories[2],
                DummyFourCategory = categories[3],
                DummyOne = returns[0],
                DummyTwo = returns[1],
                DummyThree = returns[2],
                DummyFour = returns[3],
            };
        }
        public CategoryArticleViewModel GetCategoryArticleModel(CategoriesInformation.CategoriesEnum category)
        {
            var converted = GetStringCategoryFromEnum(category);
            var model = new CategoryArticleViewModel();
            var additionalInfo = CategoriesInformation.GetAdditionalInformation(converted);
            model.PreviewModels = PreviewArticleModels(converted);
            model.SortBar = new SortBindingModel();
            model.SortBar.SortByValues = new string[] { "Most recent", "Price (ascending)", "Price (descending)" };
            var passArr = new string[] { "Any" };
            if (additionalInfo != null)
            {
                Array.Resize(ref passArr, additionalInfo.Length + 1);
                Array.Copy(additionalInfo, 0, passArr, 1, additionalInfo.Length);
            }
            model.SortBar.TypeDropDownValues = passArr;
            return model;
        }
        public CategoryArticleViewModel GetSorted_CAM(CategoriesInformation.CategoriesEnum category, SortBindingModel model)
        {
            var converted = GetStringCategoryFromEnum(category);
            var returnModel = new CategoryArticleViewModel();

            IEnumerable<ArticleDataModel> queryModel = context.Articles
                .Where(a => a.Category == converted);

            System.Diagnostics.Debug.WriteLine(string.Format("Search => {0} / Order => {1} / PriceF => {2} / PriceT => {3} / Category => {4} / querymodelISNULL = {5} / Type = {6}",
                model.Search != null ? model.Search : "NULL", model.SortBy, model.PriceLimitationFrom, model.PriceLimitationTo, converted, queryModel != null ? "No" : "Yes", model.Type));

            #region querryModel != null
            if (queryModel != null)
            {
                if (model.Type != null && model.Type != "Any")
                {
                    IEnumerable<ArticleDataModel> temp;
                    temp = queryModel
                        .Where(a => a.Type == model.Type);
                    if (temp != null) queryModel = temp;
                }
                if (model.Search != null && model.Search != string.Empty)
                {
                    IEnumerable<ArticleDataModel> temp;
                    temp = queryModel
                        .Where(a => a.Name.Contains(model.Search));
                    if (temp != null && temp.Count() > 0) queryModel = temp;
                }

                switch (model.SortBy)
                {
                    case "Most recent":
                        {
                            queryModel = queryModel
                                .OrderByDescending(a => a.UploadDate);
                        }
                        break;
                    case "Price (ascending)":
                        {
                            queryModel = queryModel
                                .OrderBy(a => a.Price);
                        }
                        break;
                    case "Price (descending)":
                        {
                            queryModel = queryModel
                              .OrderByDescending(a => a.Price);
                        }
                        break;
                }

                if (model.PriceLimitationTo != 0)
                {
                    queryModel = queryModel
                         .Where(a => (a.Price >= model.PriceLimitationFrom && a.Price <= model.PriceLimitationTo));
                }
            }
            #endregion

            var mapped = MapArticles(queryModel);
            returnModel.PreviewModels = mapped;
            returnModel.SortBar = new SortBindingModel()
            {
                SortByValues = new string[] { "Most recent", "Price (ascending)", "Price (descending)" }
            };

            return returnModel;
        }
        public ArticleViewModel GetArticleViewModel(int Id)
        {
            var article = context.Articles.FirstOrDefault(a => a.Id == Id);
            if (article != null)
                return this.MapTo_ArticleViewModel(article);
            else
                return null;
        }
      
        public bool Add_or_RemoveToCart(string User, int id)
        {
            try
            {
                var singleArticle = context.
                    ShopingNodes.
                    Where(u => u.Username == User).
                    FirstOrDefault(u => u.Id == id);

                if (singleArticle != null)
                {

                    context.ShopingNodes.Remove(singleArticle);
                    context.SaveChanges();
                    return false;
                }
                else
                {
                    context.ShopingNodes.Add(new ShopingNode() { Username = User, ArticleId = id });
                    context.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
        public bool RemoveShoppingNodes(int id)
        {
            var singleNode = context.ShopingNodes.FirstOrDefault(node=>node.Id == id);
            if(singleNode != null)
            {
                context.ShopingNodes.Remove(singleNode);
                context.SaveChanges();
                return true;
            }
            return false;
        }

   
        public IEnumerable<ShoppingNodeViewModel> GetShopingNodes(string user)
        {
            var Nodes = context.ShopingNodes.Where(node => node.Username == user);
            var ConvertedNodes = new List<ShoppingNodeViewModel>();
            foreach (var node in Nodes)
            {
                var article = context.Articles.FirstOrDefault(i => i.Id == node.ArticleId);
                if (article != null)
                {
                    var base64 = Convert.ToBase64String(article.Image);
                    var imgsrc = string.Format("data:file/gif;base64,{0}", base64);
                    ConvertedNodes.Add(new ShoppingNodeViewModel()
                    {
                        Id = node.Id,
                        ArticleId = article.Id,
                        Image64 = imgsrc,
                        Name = article.Name,
                        Price = article.Price,
                        Discount = article.Discount
                    });
                }
            }

            return ConvertedNodes;
        }
        

        #endregion

        #region Private Methods

        private IEnumerable<ArticlePreviewModel> PreviewArticleModels(string category)
        {
            var articles = context.Articles
              .Where(a => a.Category == category)
              .ToList();

            return MapArticles(articles);
        }
        private IEnumerable<ArticlePreviewModel> RecentlyAdded(string category)
        {
            var articles = context.Articles
              .OrderByDescending(a => a.UploadDate)
              .Take(40)
              .ToList();

            if (category != "")
            {
                articles = articles.Where(a => a.Category == category).ToList();
            }

            return MapArticles(articles);
        }
        private IEnumerable<ArticlePreviewModel> MapArticles(IEnumerable<ArticleDataModel> articles)
        {
            var mappedArticles = new List<ArticlePreviewModel>();

            foreach (var article in articles)
            {
                mappedArticles.Add(Mapper.Map<ArticlePreviewModel>(article));
            }
            return mappedArticles;
        }
        private ArticleViewModel MapTo_ArticleViewModel(ArticleDataModel article)
        {
            try
            {
                var base64 = Convert.ToBase64String(article.Image);
                var imgsrc = string.Format("data:file/gif;base64,{0}", base64);

                var model = Mapper.Map<ArticleViewModel>(article);
                model.Image = imgsrc;
                return model;
            }
            catch
            {
                return null;
            }
        }

       

        private string GetStringCategoryFromEnum(CategoriesInformation.CategoriesEnum category)
        {
            var converted = CategoriesInformation.Categories.
                ToArray()[(int)category];
            return converted;
        }
      
        #endregion

    }


    static class MapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>
       (this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }

    }

}
