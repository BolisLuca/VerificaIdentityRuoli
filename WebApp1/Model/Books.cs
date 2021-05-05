using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenziaFotografica.Model
{
    public class Books
    {
        //Books(pkBook, descrizioneBook, dataBook, numeroScatti, fkModello, fkCliente)

        [Key]
        [Required]
        [RegularExpression(@"[bk]+\d+\d+\d")]
        public string pkBook { get; set; }

        [Required]

        public string descrizioneBook { get; set; }

        [Required]

        public DateTime dataBook { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int numeroScatti { get; set; }

        [ForeignKey("fkModello")]
        public string fkModello { get; set; }

        [ForeignKey("fkCliente")]
        public string fkCliente { get; set; }

    }
}
