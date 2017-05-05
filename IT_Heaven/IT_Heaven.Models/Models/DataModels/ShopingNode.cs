using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_Heaven.Models.Models.DataModels
{
    public class ShopingNode
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public int ArticleId { get; set; }

     
    }
}
