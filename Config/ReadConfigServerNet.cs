using DespesaDigital.Code.DTO.dtoServerNet;
using Newtonsoft.Json;
using System.IO;

namespace DespesaDigital.Config
{
    public class ReadConfigServerNet
    {
        public static dtoServerNet GetConfigServerNET()
        {
            var dto = new dtoServerNet();

            using (StreamReader json_read = new StreamReader("server_net.json"))
            {
                var json = json_read.ReadToEnd();

                var atributtes = JsonConvert.DeserializeObject<dtoServerNet>(json);

                dto.IP = atributtes.IP;
            }

            return dto;
        }
    }
}
