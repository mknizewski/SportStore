using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image)
        {
            var img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            return new MvcHtmlString("<img src='" + img + "' class='thumbnail' style='width: 340px; height: 300px' />");
        }
    }
}