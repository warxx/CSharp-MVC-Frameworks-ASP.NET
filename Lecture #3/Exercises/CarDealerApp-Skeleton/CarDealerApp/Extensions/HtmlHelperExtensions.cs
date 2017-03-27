
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Reflection;
using System.Web.Mvc;
using System.Web.UI;
using CarDealer.Models;

namespace CarDealerApp.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, string width = null, string height = null, string alt = null)
        {
            var builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("width", width);
            builder.MergeAttribute("height", height);
            builder.MergeAttribute("alt", alt);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString YouTube(this HtmlHelper helper, string videoId, int width = 560, int height = 315)
        {
            var builder = new TagBuilder("iframe");
            builder.MergeAttribute("src", "https://www.youtube.com/embed/" + videoId);
            builder.MergeAttribute("width", width.ToString());
            builder.MergeAttribute("height", height.ToString());
            builder.MergeAttribute("frameborder", "0");
            builder.MergeAttribute("allowfullscreen", "true");
           // builder.AddCssClass("img-thumbnail");
            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Table<T>(this HtmlHelper helper, IEnumerable<T> collection, string[] cssClasses)
        {
            var builder = new TagBuilder("table");

            foreach (var @class in cssClasses)
            {
                builder.AddCssClass(@class);
            }

            var tableHeaderRow = new TagBuilder("tr");

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var colHeaderName = new TagBuilder("th");
                colHeaderName.SetInnerText(prop.Name);
                tableHeaderRow.InnerHtml += colHeaderName;
            }

            builder.InnerHtml += tableHeaderRow;

            foreach (var item in collection)
            {
                var tableRow = new TagBuilder("tr");

                foreach (var prop in props)
                {
                    var tableDate = new TagBuilder("td");
                    tableDate.SetInnerText(GetPropValue(item, prop.Name));
                    tableRow.InnerHtml += tableDate;
                }
                builder.InnerHtml += tableRow;
            }

            return new MvcHtmlString(builder.ToString(TagRenderMode.Normal));
        }

        public static string GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null).ToString();
        }
    }
}