using Microsoft.VisualStudio.TestTools.UnitTesting;
using IT_Heaven.Data.Services;
using IT_Heaven.Data;
using IT_Heaven.Models.CategoriesSemiModels;
using IT_Heaven.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Heaven.Data.Services.Tests
{
   
    [TestClass()]
    public class ServiceTests
    {
        #region Test 1
        [TestMethod()]
        public void Test_GetStringCategoryFromEnum()
        {
            var givenEnum = CategoriesInformation.CategoriesEnum.Computers;
            var expectedResult = "Computers";

            var act = GetStringCategoryFromEnum(givenEnum);

            Assert.AreEqual(expectedResult, act); 
            
        }
        private string GetStringCategoryFromEnum(CategoriesInformation.CategoriesEnum category)
        {
            var converted = CategoriesInformation.Categories.
                ToArray()[(int)category];
            return converted;
        }
        #endregion

     

    

      
    }
}