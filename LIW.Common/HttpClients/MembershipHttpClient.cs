using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIW.Common.HttpClients
{
    public class MembershipHttpClient
    {
        public HttpClient Client { get; }

        public MembershipHttpClient(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}
