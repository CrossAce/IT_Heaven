using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Heaven.Models.Models.BindingModels;
using IT_Heaven.Models.Models.DataModels;
using IT_Heaven.Models.CategoriesSemiModels;
using System.Web;
using AutoMapper;
using Newtonsoft.Json;
using IT_Heaven.Models.Models.ViewModels;
using IT_Heaven.Models.CustomValidation;
using System.Data.Entity.Migrations;

namespace IT_Heaven.Data.Services
{

    public class SpecialUserService : Service
    {
        private ModelValidation validation = new ModelValidation();

        public AddArticleBindingModel GetArticleBindingModel()
        {
            AddArticleBindingModel model = new AddArticleBindingModel();
            model.Categories = CategoriesInformation.Categories;
            return model;
        }
        public bool AddArticle(AddArticleBindingModel model, HttpPostedFileBase file)
        {

            if (!validation.IsAddModelValid(model))
            {
                return false;
            }

            if (file != null)
            {
                var img = new byte[file.ContentLength];
                file.InputStream.Read(img, 0, file.ContentLength);
                if (!validation.IsImage(img))
                    return false;

                model.Image = img;

            }
            else
            {
                return false;
            }

            if (model.Type == null || model.Type == "")
            {
                model.Type = "none";
            }

            model.UploadDate = DateTime.Now;


            var article = Mapper.Map<ArticleDataModel>(model);
            article.Discount = 0;
            context.Articles.Add(article);
            context.SaveChanges();

            return true;
        }
        public EditBindingModel GetEditModel(int id)
        {
            var article = context.Articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
                return MapTo_EditBindingModel(article);

            return null;
        }
        public bool DeleteArticle(int id)
        {
            var article = context.Articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                context.Articles.Remove(article);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditArticle(EditBindingModel model, HttpPostedFileBase file)
        {
            try
            {
                if (!validation.IsEditModelValid(model))
                {
                    return false;
                }

                var oldArticle = context.Articles.First(a => a.Id == model.Id);
                if (model.Type == null || model.Type == "" || model.Type == "None")
                {
                    model.Type = "None";
                }

                var article = Mapper.Map<ArticleDataModel>(model);
                if (file != null)
                {
                    var img = new byte[file.ContentLength];
                    file.InputStream.Read(img, 0, file.ContentLength);
                    if (!validation.IsImage(img))
                        return false;
                    article.Image = new byte[file.ContentLength];

                }
                else
                {
                    article.Image = oldArticle.Image;
                }
                article.UploadDate = oldArticle.UploadDate;
                context.Articles.AddOrUpdate(article);
                context.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        public bool DeleteUser(string Id)
        {
            using (var usersDb = new ApplicationDbContext())
            {
                var _user = usersDb.Users.FirstOrDefault(user => user.Id == Id);
                if (_user != null)
                {
                    usersDb.Users.Remove(_user);
                    usersDb.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<UserViewModel> GetUsersViewModel()
        {
            using (var userDb = new ApplicationDbContext())
            {
                var userViewModels = new List<UserViewModel>();
                foreach (var user in userDb.Users)
                {
                    userViewModels.Add(new UserViewModel()
                    {
                        Id = user.Id,
                        Name = user.UserName,
                        Role = GetRoleName(user.Roles.First().RoleId)
                    });

                }
                return userViewModels;
            }
        }


        public string[] JsonString(int? itemInfo)
        {
            return CategoriesInformation.GetAdditionalInformation((int)itemInfo);
        }


    
       
        private EditBindingModel MapTo_EditBindingModel(ArticleDataModel article)
        {
            try
            {
                var base64 = Convert.ToBase64String(article.Image);
                var imgsrc = string.Format("data:file/gif;base64,{0}", base64);

                var model = Mapper.Map<EditBindingModel>(article);
                model.Image = article.Image;
                model.Image64 = imgsrc;
                model.Categories = CategoriesInformation.Categories;

                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private string GetRoleName(string roleId)
        {
            using (var userDb = new ApplicationDbContext())
            {
                return userDb.Roles.First(role => role.Id == roleId).Name;
            }
        }


    }
}
