using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostcodeAPI;
using PostcodeAPI.V2;
using PostcodeAPI.V2.Wrappers;

namespace MyMusicStashWeb.PostcodeApi
{
    public class Client
    {
        public static PostcodeApiClient ClientPostcode
        {
            get
            {
                PostcodeApiClient client = new PostcodeApiClient("T77DABUeHPecBbCBOJuO8hreNqTic1b78pdSapv1");
                return client;
            }

        }

        public ApiHalResultWrapper GetAdress(Adresgegevens adres)
        {
            try
            {
                ApiHalResultWrapper result1 = ClientPostcode.GetAddress(adres.Postcode, adres.Huisnummer);
                return result1;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}