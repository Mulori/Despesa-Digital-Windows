using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DespesaDigital.Code.WEB
{
    public class webApi
    {
        public static string TodosPaisesAmericaSul(string uri)
        {
            string responseData = "";

            string URLAuth = "http://www.geonames.org/" + uri;
            HttpWebRequest webRequest = WebRequest.Create(URLAuth) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.Accept = "application/json";

            try
            {
                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                
            }            

            return responseData;
        }
    }
}
