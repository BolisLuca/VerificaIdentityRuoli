using System;
using System.ComponentModel.DataAnnotations;

namespace Bolis.Models
{
    public class Eventi
    {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(30)]
        public string Titolo { get; set; }
        [Required, StringLength(50)]
        public string Descrizione { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string FkUserName { get; set; }
    }
}
