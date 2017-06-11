using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicStashWeb.PostcodeApi
{
    public class Adresgegevens
    {
        public int Huisnummer
        {
            get { return huisnummer; }
            set { huisnummer = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public Adresgegevens(int huisnummer, string postcode)
        {
            this.huisnummer = huisnummer;
            this.postcode = postcode;
        }

        private int huisnummer;
        private string postcode; 

    }
}