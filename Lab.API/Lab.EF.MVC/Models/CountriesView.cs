using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.EF.MVC.Models
{
    public class CountriesView
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Flag { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public int Population { get; set; }
        public string NativeName { get; set; }
        public List<Language> languages { get; set; }
    }
}