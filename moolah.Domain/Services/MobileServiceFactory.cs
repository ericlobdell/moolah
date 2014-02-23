using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace moolah.Domain.Services
{
    public static class MobileServiceFactory
    { 

        public static MobileServiceClient CreateClient()
        {
            return new MobileServiceClient(
                "https://moolah.azure-mobile.net/",
                "JlqBSKGQirbbJCPpIGYBNDVxsWEyJH22"
            );
        }
    }
}
