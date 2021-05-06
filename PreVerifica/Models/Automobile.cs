using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PreVerifica.Models
{
    public class Automobile//Id, Nome, Descrizione, cavalli, data di produzione
    {
        [Key]
        public string PkId { get; set; }

        [Required]
        [StringLength(30,ErrorMessage="Il nome del modello ha lunghezza massima 30 caratteri!")]
        public string NomeModello { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Too long description!")]

        public string Descrizione { get; set; }
        [Required]
        [Range(0,int.MaxValue, ErrorMessage ="cavalli value is out of range")]

        public int cavalli { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage ="Data di produzione must be a date")]
        public DateTime data_di_produzione { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="The UserName of the user must be an email")]
        public string fkUserName { get; set; }
    }
}
