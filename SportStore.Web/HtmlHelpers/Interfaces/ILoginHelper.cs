using SportStore.Domain.Entities;
using SportStore.Web.Models.Client;
using System.Collections.Generic;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface ILoginHelper
    {
        IEnumerable<clients> Clients { get; set; }

        bool IfExists(LoginModel loginModel);

        void ForgottenPassword(string email, string newPassword);

        AccountModel GetClient(string clientLogin);
    }
}