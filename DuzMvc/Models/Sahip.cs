using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DuzMvc.Models
{
    public class Sahip:BaseEntity
    {
        public Sahip()
        {
            Tasinmazlar = new Collection<Tasinmaz>();
        }
        [DisplayName("Sahip Adi Soyadi")]
        public string Name { get; set; }
        public DateTime? DTarih { get; set; }
        public string Idno { get; set; }
        public virtual ICollection<Tasinmaz> Tasinmazlar { get; set; } = new Collection<Tasinmaz>(); // Burda newleyerek ref alarak içerisindeki bilgileridüzmüş oluyorum taşınmazlar adresine gittiği zaman içini dolu görücez.




    }
}