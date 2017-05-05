using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Heaven.Models.Models.DataModels;

namespace IT_Heaven.Models.Models.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            RecentlyAdded = new List<ArticlePreviewModel>();
            RecentlySold = new List<ArticlePreviewModel>(); 
        }
        public IEnumerable<ArticlePreviewModel> RecentlyAdded { get; set; }
        public IEnumerable<ArticlePreviewModel> RecentlySold { get; set; }
    }
}
