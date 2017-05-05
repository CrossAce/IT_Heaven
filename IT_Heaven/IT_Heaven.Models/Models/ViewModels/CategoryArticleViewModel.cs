using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Heaven.Models.Models.BindingModels;


namespace IT_Heaven.Models.Models.ViewModels
{
    public class CategoryArticleViewModel
    {
        public IEnumerable<ArticlePreviewModel> PreviewModels { get; set; }

        public SortBindingModel SortBar { get; set; }
    }
  

}
