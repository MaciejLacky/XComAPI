using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XComAPI.Data
{
    public class Event
    {
        [Key]
        public int IdEvent { get; set; }
        [Required(ErrorMessage = "Nazwa eventu wymagana")]
        [Display(Name = "Nazwa eventu")]
        public string EventName { get; set; }
        [Display(Name = "Data od:")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Data do:")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }
        [Display(Name = "Opis eventu")]
        public string EventDescription { get; set; }
        [Display(Name = "Max ilość osób")]
        public int MaxNumberOfPeople { get; set; }
    }
}
