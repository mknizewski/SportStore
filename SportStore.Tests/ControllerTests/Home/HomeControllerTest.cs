using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Domain.Entities;
using SportStore.Web.Models.Home;
using SportStore.Web.Controllers;
using System.Web.Mvc;
using System.Collections;
using System.Collections.Generic;

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
            int iterator = 1;

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
            list.Add(new SelectListItem() { Text = "Piłka Nożna", Value = "1" });
            list.Add(new SelectListItem() { Text = "Kocmołuch", Value = "2" });

            return list;
        }
    }
}
