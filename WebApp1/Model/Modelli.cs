using System;
using System.ComponentModel.DataAnnotations;

namespace AgenziaFotografica.Model
{
    public class Modelli
    {

        //Modelli(pkModello, NomeModello, DataNascita, NazioneModello, emailModello)
        [Key]
        [Required]
        [RegularExpression(@"[mod]+\d+\d")]
        public string pkModello { get; set; }

        [Required]
        public string NomeModello { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascita { get; set; }

        [Required]
        public string NazioneModello { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string emailModello { get; set; }

        public string UserName { get; set; }
    }
}
