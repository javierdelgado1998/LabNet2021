using Lab.EF.Entities;
using Lab.EF.Logic.Interfaces;
using Lab.EF.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CountriesLogic
    {
        private ICountriesAPI countryAPI { get; set; }
        public CountriesLogic(ICountriesAPI countryAPI)
        {
            this.countryAPI = countryAPI;
        }
        public List<Country> GetCountries()
        {
            try
            {
                return (from c in countryAPI.GetCountries()
                        select new Country
                        {
                            Name = c.name,
                            Capital = c.capital,
                            Flag = c.flag,
                            languages = c.languages,
                            NativeName = c.nativeName,
                            Population = c.population,
                            Region = c.region,
                            SubRegion = c.subregion
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
