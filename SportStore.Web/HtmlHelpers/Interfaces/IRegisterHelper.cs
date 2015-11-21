using SportStore.Web.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IRegisterHelper
    {
        RegisterModel GetRegisterModel();
        void Save(RegisterModel registerModel);
    }
}
