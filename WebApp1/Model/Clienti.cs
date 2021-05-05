using System.ComponentModel.DataAnnotations;

namespace AgenziaFotografica.Model
{
    public class Clienti
    { //Clienti(pkCliente, RagioneSocialeCliente, NazioneCliente, emailCliente)
        [Key]
        [Required]
        public string pkCliente { get; set; }

        [Required]
        public string RagioneSocialeCliente { get; set; }

        [Required]
        public string NazioneCliente { get; set; }

        [Required]
        public string emailCliente { get; set; }
    }
}
