using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba14.Models.ViewModels
{
    public class UsersViewModel
    {
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("(^[a-zA-Z]+$)", ErrorMessage = "Solo se permiten letras")]
        [Display(Name = "Apellido")]
        public string Apel { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("(^[a-zA-Z]+$)", ErrorMessage = "Solo se permiten letras")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
    }
}