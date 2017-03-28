
using System.Web.Mvc;

namespace CameraBazaar.App.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string imageUrl, int width = 200, int height = 200, string alt = null)
        {
            var builder = new TagBuilder("img");
            builder.AddCssClass("img-thumbnail");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("width", width.ToString());
            builder.MergeAttribute("height", height.ToString());
            builder.MergeAttribute("alt", alt);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}