﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportStore.Web.Models.Catalog
{
    public class OpinionModel
    {
        public int? Id_User { get; set; }
        public int Id_Item { get; set; }
        public string Opinion { get; set; }
        public int Rate { get; set; }
    }
}