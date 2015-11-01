using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportStore.Domain.Entities;
using SportStore.Web.Models.Home;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface INewsletterHelper
    {
        NewsletterModel GetNewsletterModel();
        bool TrySave(NewsletterModel model);
    }
}
