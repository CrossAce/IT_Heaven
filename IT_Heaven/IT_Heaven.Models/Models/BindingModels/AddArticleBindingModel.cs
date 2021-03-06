﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using IT_Heaven.Models.CustomValidation;

namespace IT_Heaven.Models.Models.BindingModels
{
    public class AddArticleBindingModel
    {
       
        public byte[] Image { get; set; }

        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 6, ErrorMessage = "The {0} must be atleast {2} characters long!")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "The {0} must be atleast {2} characters long!")]
        public string Brand { get; set; }      

        [Required]
        [StringLength(1000,MinimumLength = 7,ErrorMessage = "The {0} must be atleast {2} characters long!")]
        public string Description { get; set; }

        [Required]
        [Range(minimum: 0.00, maximum: 15000.00, ErrorMessage = "The price is not within the range [0.00 ; 15000.0]!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please select a category!")]
        [CustomCategory("None",ErrorMessage = "Please select a category!")]
        public string Category { get; set; }

        [ArticleType(ErrorMessage = "Please select a type!")]
        public string Type { get; set; }
        
        [Display(Name="Categories")]
        public ICollection<string> Categories { get; set; }

        public DateTime UploadDate { get; set; }

    }
}
