using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Heaven.Models.Models.ViewModels
{
    public class NavigationViewModel
    {
        public int NavigationId { get; set; }      
        public string DummyOneCategory { get; set; }
        public string DummyTwoCategory { get; set; }
        public string DummyThreeCategory { get; set; }
        public string DummyFourCategory { get; set; }
        public IEnumerable<ArticlePreviewModel> DummyOne { get; set; }
        public IEnumerable<ArticlePreviewModel> DummyTwo { get; set; }
        public IEnumerable<ArticlePreviewModel> DummyThree { get; set; }
        public IEnumerable<ArticlePreviewModel> DummyFour { get; set; }

    }
}
