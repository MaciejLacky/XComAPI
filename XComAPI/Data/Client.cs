using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XComAPI.Data
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        [Required(ErrorMessage = "Imie wymagane")]
        [Display(Name = "Imie")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail wymagane")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int IdEvent { get; set; }
        public virtual Event Event { get; set; }
    }
}
