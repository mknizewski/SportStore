using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportStore.Web.Controllers;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Web.Models.Home;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SportStore.Tests.ControllerTests.Home
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CanReturnedNewsletterDictionary()
        {
            //przygotowanie
            Mock<INewsletterHelper> mock = new Mock<INewsletterHelper>();
            mock.Setup(x => x.GetNewsletterModel()).Returns(new NewsletterModel()
            {
                TypeOfNews = FillTypeOfNews()
            });
            HomeController homeController = new HomeController(mock.Object);
            int iterator = 3;

            //działanie
            var returnedModel = (NewsletterModel)homeController.SaveNewsletter().Model;
            var listItem = returnedModel.TypeOfNews;

            //asercje
            foreach (var el in listItem)
            {
                Assert.AreEqual(el.Value, iterator.ToString());
                iterator++;
            }
        }

        private IEnumerable<SelectListItem> FillTypeOfNews()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Piłka Nożna", Value = "3" });
            list.Add(new SelectListItem() { Text = "Kocmołuch", Value = "4" });

            return list;
        }
    }
}