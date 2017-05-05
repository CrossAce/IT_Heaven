using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Heaven.Models.Models.BindingModels;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace IT_Heaven.Models.CustomValidation
{
    public class ModelValidation
    {
        public bool IsAddModelValid(AddArticleBindingModel model)
        {

            if (model.Name.Length < 3 || model.Name.Length > 100)
            {
                return false;
            }
            if (model.Price < 0 || model.Price > 15000)
            {
                return false;
            }
            if (model.Category == "None")
            {
                return false;
            }
            if (CategoriesSemiModels
                .CategoriesInformation.GetAdditionalInformation(model.Category) != null
                && model.Type == "None")
            {
                return false;
            }
          
            if (model.Brand == null)
            {
                return false;
            }
            if (model.Description.Length < 10 || model.Description.Length > 1000)
            {
                return false;
            }
            return true;
        }
        public bool IsEditModelValid(EditBindingModel model)
        {

            if (model.Name.Length < 3 || model.Name.Length > 100)
            {
                return false;
            }
            if (model.Price < 0 || model.Price > 15000)
            {
                return false;
            }
            if (model.Category == "None")
            {
                return false;
            }
            if (CategoriesSemiModels
                .CategoriesInformation.GetAdditionalInformation(model.Category) != null
                 && model.Type == "None")
            {
                return false;
            }
            if (model.Discount < 0 || model.Discount > 100)
            {
                return false;
            }
            if (model.Brand == null)
            {
                return false;
            }
            if (model.Description.Length < 10 || model.Description.Length > 1000)
            {
                return false;
            }
            return true;
        }
        public bool IsImage(byte[] imageArr)
        {
            
            //try
            //{
                Image image = null;
                using (MemoryStream stream = new MemoryStream(imageArr))
                {
                    image = Image.FromStream(stream);
                }
                if (ImageFormat.Jpeg.Equals(image.RawFormat))
                {
                    return true;
                }
                else if (ImageFormat.Png.Equals(image.RawFormat))
                {
                    return true;
                }
                image.Dispose();
                return false;
            //}
            //catch
            //{
            //    return false;
            //}
           
        }
    }
}
