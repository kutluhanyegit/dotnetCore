using System;
using Microsoft.AspNetCore.Identity;

namespace rentid.Entities
{
    public class appUser:IdentityUser
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string tckn { get; set; }
        
        public string isletmeAd { get; set; }
        public double lati { get; set; }
        public double lon { get; set; }
        public DateTime ktarih { get; set; }
        public bool kvkk { get; set; }
    }
}