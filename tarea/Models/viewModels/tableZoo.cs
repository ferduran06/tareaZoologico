using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tarea.Models.viewModels
{
    public class tableZoo
    {

        // Clase para obtener información de los codigos, donde se pueda 
        // guardar la información y así poder validar la información.
        public int id { get; set; }

        [Required]              
        [StringLength(20)]
        [Display(Name = "pais")]

        public string pais { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "telefono")]
        public String telefono { get; set; }
        
        public string sitioWeb { get; set; }
        }
    }
