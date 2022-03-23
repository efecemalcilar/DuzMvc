using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuzMvc.Models
{
    public class Tasinmaz: BaseEntity
    {

        [StringLength(100),Required(ErrorMessage = "{0} alani zorunludur. ")]

        public string Name { get; set; } //0 alanı Name adına tekabül ediyor.
        [StringLength(30)]

        public string Sehir { get; set; }
        [StringLength(330)]  //nvarchar(330)

        public string Adres { get; set; }

        public DateTime? AlinisTarih { get; set; }
        public decimal AlinisFiyat { get; set; }
        public int SahipId { get; set; }
        [StringLength(330)]

        public string Aciklama { get; set; }

        public virtual Sahip Sahip { get; set; } //navgiation property

        







    }
}