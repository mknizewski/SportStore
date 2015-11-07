using SportStore.Domain.Entities;
using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface ILoginHelper
    {
        IEnumerable<clients> Clients { get; set; }
        bool IfExists(LoginModel loginModel);
        void ForgottenPassword(string email, string newPassword);
    }
}
