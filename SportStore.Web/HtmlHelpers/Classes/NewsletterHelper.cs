﻿using System;
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

        bool INewsletterHelper.TrySave(Models.Home.NewsletterModel model)
        {
            string mail = model.Email;
            int selectedId = model.selectedTypeOfNews;

            var ifExists = (from Newsletter modelNews in _newsletterRepository.Newsletters
                            where modelNews.email == mail
                            select modelNews).FirstOrDefault();


            if (ifExists == null)
            {
                var currentTime = DateTime.Now;

                var modelToSave = new Newsletter()
                {
                    email = mail,
                    Id_Type_Of_News = selectedId,
                    InsertTime = currentTime
                };

                _newsletterRepository.Add(modelToSave);

                return true;
            }
            else
                return false;

        }

        private IEnumerable<SelectListItem> GetNewsList(IEnumerable<_dict_newsletter> list)
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