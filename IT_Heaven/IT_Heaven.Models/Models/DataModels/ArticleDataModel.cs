using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace IT_Heaven.Models.Models.DataModels
{
    public class ArticleDataModel
    {
        
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Discount { get; set; }     
        public string Description { get; set; }    
        public decimal Price { get; set; }       
        public string Type { get; set; }
        public string Category { get; set; }      
        public DateTime UploadDate { get; set; }     
    }
}
