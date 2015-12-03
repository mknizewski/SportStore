using SportStore.Web.Models.Home;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface INewsletterHelper
    {
        NewsletterModel GetNewsletterModel();

        bool TrySave(NewsletterModel model);
    }
}