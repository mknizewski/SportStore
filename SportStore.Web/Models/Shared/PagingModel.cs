﻿using System;

namespace SportStore.Web.Models.Shared
{
    public class PagingModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems) / ItemsPerPage;
            }
        }
    }
}