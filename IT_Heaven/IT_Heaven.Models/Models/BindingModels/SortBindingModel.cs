using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_Heaven.Models.Models.BindingModels
{
    public class SortBindingModel
    {
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string Search { get; set; }

        public string Type { get; set; }

        public string[] TypeDropDownValues { get; set; }

        public string SortBy { get; set; }

        public string[] SortByValues { get; set; }

        [Range(minimum: 0, maximum: 15000.00)]
        public decimal PriceLimitationFrom { get; set; }
        [Display(Name = "15000")]
        [Range(minimum: 0, maximum: 15000.00)]
        public decimal PriceLimitationTo { get; set; }
    }
}
