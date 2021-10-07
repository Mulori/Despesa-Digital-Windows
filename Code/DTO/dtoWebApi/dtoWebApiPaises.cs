using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DespesaDigital.Code.DTO.dtoWebApi
{
    public class dtoWebApiPaises
    {
        public int totalResultsCount { get; set; }
        public List<geonames> geonames { get; set; }
    }

    public class geonames
    {
        public string adminCode1 { get; set; }
        public string lng { get; set; }
        public string toponymName { get; set; }
        public string fcl { get; set; }
        public string population { get; set; }
        public string countryCode { get; set; }
        public string fclName { get; set; }
        public string countryName { get; set; }
        public string fcodeName { get; set; }
        public string geonameId { get; set; }
        public string adminName1 { get; set; }
        public string countryId { get; set; }
        public string lat { get; set; }
        public string name { get; set; }
        public string fcode { get;set; }
    }
}
