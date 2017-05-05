using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Heaven.Models.Models.ViewModels
{
    public class ShoppingNodeViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Image64 { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }

    }
}
