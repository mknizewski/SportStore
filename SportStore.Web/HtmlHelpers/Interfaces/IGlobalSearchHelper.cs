using SportStore.Web.Models.Search;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IGlobalSearchHelper
    {
        GlobalSearchModel SearchItems(GlobalSearchModel model);

        GlobalSearchModel GetModel(string text);
    }
}