using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using IT_Heaven.Models.Models.ViewModels;

namespace IT_Heaven.Resources.Helpers
{
    public static class PanelHelper
    {
        public static MvcHtmlString ArticlePanel(this HtmlHelper helper, ArticlePreviewModel model)
        {
            var base64 = Convert.ToBase64String(model.Image);
            var imgsrc = string.Format("data:file/gif;base64,{0}", base64);

            decimal newPrice = 0;
            if (model.Discount != 0)
                newPrice = model.Price * (model.Discount * 0.01M);

            newPrice = model.Price - newPrice;

            TagBuilder outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("card-item js-card-item ph-card items");

            TagBuilder anchor = new TagBuilder("a");
            anchor.AddCssClass("card");
            anchor.MergeAttribute("href", string.Format("/Article/Details/{0}", model.Id));

            TagBuilder preloader = new TagBuilder("div");
            preloader.AddCssClass("preloader hidden");

            TagBuilder postloader = new TagBuilder("div");
            postloader.AddCssClass("postloader hidden");

            TagBuilder holder = new TagBuilder("div");
            holder.AddCssClass("card-heading");

            TagBuilder thumbnail_wrapper = new TagBuilder("div");
            thumbnail_wrapper.AddCssClass("thumbnail-wrapper");

            TagBuilder thumbnail = new TagBuilder("div");
            thumbnail.AddCssClass("thumbnail");

            TagBuilder image = new TagBuilder("img");
           
            image.MergeAttribute("src", imgsrc);
            image.MergeAttribute("alt", "");

            TagBuilder titleOuterDiv = new TagBuilder("div");
            titleOuterDiv.AddCssClass("card-body product-title-zone");

            TagBuilder titleInnerDiv = new TagBuilder("div");
            titleInnerDiv.AddCssClass("product-title");
            titleInnerDiv.InnerHtml = model.Name;

            TagBuilder PriceContainer = new TagBuilder("div");
            PriceContainer.AddCssClass("card-body");
            TagBuilder oldPrice = new TagBuilder("p");
            TagBuilder _newPrice = new TagBuilder("p");
            if (model.Discount != 0)
            {
                oldPrice.AddCssClass("product-old-price");
                oldPrice.InnerHtml = Math.Round(model.Price, 2).ToString();

                _newPrice.AddCssClass("product-new-price");
                _newPrice.InnerHtml = Math.Round(newPrice, 2).ToString() + "лв.";
            }
            else
            {

                _newPrice.AddCssClass("product-new-price");
                _newPrice.InnerHtml = Math.Round(model.Price, 2).ToString() + "лв.";
            }

            PriceContainer.InnerHtml = model.Discount != 0 ? oldPrice.ToString() + _newPrice.ToString() : _newPrice.ToString();
            titleOuterDiv.InnerHtml = titleInnerDiv.ToString();
            thumbnail.InnerHtml = image.ToString();
            thumbnail_wrapper.InnerHtml = thumbnail.ToString();
            holder.InnerHtml = thumbnail_wrapper.ToString();
            anchor.InnerHtml = preloader.ToString() + postloader.ToString() + holder.ToString() + titleOuterDiv.ToString() + PriceContainer.ToString();
            outerDiv.InnerHtml = anchor.ToString();
            return new MvcHtmlString(outerDiv.ToString());
        }
    }
}