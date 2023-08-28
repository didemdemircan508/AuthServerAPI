using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyAuthServer.Core.Configuration
{
    public class Client
    {

        public string Id { get; set; }

        public string Secret { get; set; }
    //ww.myapi1.com buna ulaşablır www.myapi.com2 bunda erişelbilir audince bunun için lullanıyoruz payloadda göterşceğiz
    
        public List<string> Audiences { get; set; }
    }
}
