using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportStore.Web.HtmlHelpers.Interfaces;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System.Web.Mvc;
using SportStore.Web.Models.Home;

namespace SportStore.Web.HtmlHelpers.Classes
{
    public class NewsletterHelper : INewsletterHelper
    {
        private INewsletterRepository _newsletterRepository;

        public NewsletterHelper(INewsletterRepository newsletterRepo)
        {
            _newsletterRepository = newsletterRepo;
        }

        Models.Home.NewsletterModel INewsletterHelper.GetNewsletterModel()
        {
            var list = GetNewsList(_newsletterRepository.TypeOfNews);
            var model = new NewsletterModel();

            model.TypeOfNews = list;

            return model;
        }

        void INewsletterHelper.SaveToDb(Models.Home.NewsletterModel model)
        {
            var mail = model.Email;
            var selectedId = model.selectedTypeOfNews;
            var currentTime = DateTime.Now;

            var modelToSave = new Newsletter() 
            {
                email = mail,
                TypeOfNewsId = selectedId,
                InsertTime = currentTime
            };

            _newsletterRepository.Add(modelToSave);
        }

        bool INewsletterHelper.CanSave()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<SelectListItem> GetNewsList(IEnumerable<_dict_typeofnews_newsletter> list)
        {
            var newList = new List<SelectListItem>();

            foreach (var element in list)
                newList.Add(new SelectListItem()
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });

            return newList;
        }
    }
}