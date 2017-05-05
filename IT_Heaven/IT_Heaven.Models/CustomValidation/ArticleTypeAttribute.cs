using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IT_Heaven.Models.CategoriesSemiModels;

namespace IT_Heaven.Models.CustomValidation
{
    class ArticleTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !CategoriesInformation.Special.Contains(value);
        }  
    }
}
