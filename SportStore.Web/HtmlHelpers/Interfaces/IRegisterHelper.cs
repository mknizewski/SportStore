using SportStore.Web.Models.Client;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IRegisterHelper
    {
        RegisterModel GetRegisterModel();

        void Save(RegisterModel registerModel);
    }
}