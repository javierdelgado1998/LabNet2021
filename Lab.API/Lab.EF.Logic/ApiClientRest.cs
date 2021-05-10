using Lab.EF.Entities;
using Lab.EF.Logic.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class ApiClientRest : ICountriesAPI
    {
        public List<CountryDTO> GetCountries()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/all");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFrom = reader.ReadToEnd();
                            List<CountryDTO> countries = JsonConvert.DeserializeObject<List<CountryDTO>>(responseFrom);
                            return countries;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
