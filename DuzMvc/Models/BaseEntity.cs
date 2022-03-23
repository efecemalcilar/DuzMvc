using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuzMvc.Models
{
    public class BaseEntity
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Base entity deddiği iki tablonun ortak alanı gibi bir şey mi ? 
        public int Id { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}