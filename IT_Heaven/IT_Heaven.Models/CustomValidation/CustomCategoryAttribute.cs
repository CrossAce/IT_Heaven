using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IT_Heaven.Models.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CustomCategoryAttribute : ValidationAttribute
    {
        readonly string _TestAgaints;
        public string TestAgaints { get { return _TestAgaints; } }

        public CustomCategoryAttribute(string TAgaints)
        {
            _TestAgaints = TAgaints;
        }

        public override bool IsValid(object value)
        {
            var category = (String)value;
            bool result = true;
            if (this.TestAgaints != null)
            {
                if (TestAgaints == category) return false;
            }
            return result;
        }
    }
}