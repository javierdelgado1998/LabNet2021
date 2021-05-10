using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Interfaces
{
    public interface ICountriesAPI
    {
        List<CountryDTO> GetCountries();
    }
}
