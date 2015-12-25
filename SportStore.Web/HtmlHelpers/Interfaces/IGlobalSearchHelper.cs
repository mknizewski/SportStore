using SportStore.Domain.Entities;
using SportStore.Web.Models.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Web.HtmlHelpers.Interfaces
{
    public interface IGlobalSearchHelper
    {
        GlobalSearchModel SearchItems(GlobalSearchModel model);
        GlobalSearchModel GetModel(string text);
    }
}
