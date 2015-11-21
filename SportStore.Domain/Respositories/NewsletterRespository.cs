using SportStore.Domain.Abstract;
using SportStore.Domain.Concrete;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SportStore.Domain.Respositories
{
    /// <summary>
    /// Autor:  Mateusz Kniżewski
    /// Opis:   Klasa logiki CRUD newsleettera oraz repo tabeli newsletter
    /// Data:   20.10.15
    /// </summary>
    public class NewsletterRespository : INewsletterRepository
    {
        private EFDbContext context = new EFDbContext();

        IEnumerable<Newsletter> INewsletterRepository.Newsletters
        {
            get
            {
                return context.Newsletter;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<_dict_newsletter> INewsletterRepository.TypeOfNews
        {
            get
            {
                return context.DictNewsletter;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void INewsletterRepository.Add(Newsletter news)
        {
            context.Newsletter.Add(news);
            context.SaveChanges();
        }

        void INewsletterRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}