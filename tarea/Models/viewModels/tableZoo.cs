using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tarea.Models.viewModels
{
    public class tableZoo
    {
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
