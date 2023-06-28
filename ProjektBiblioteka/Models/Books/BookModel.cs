using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBiblioteka.Models.Books
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Wprowadź tytuł")]
        [MaxLength(128, ErrorMessage = "Maksymalna długość wynosi 128 znaków")]
        public string? Title { get; set; }
        
        [MaxLength(128, ErrorMessage = "Maksymalna długość wynosi 128 znaków")]
        public string? Description { get; set; }

        public string? Category { get; set; }

        [Required(ErrorMessage = "Wprowadź autora")]
        [MaxLength(128, ErrorMessage = "Maksymalna długość wynosi 128 znaków")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Wprowadź ilość stron")]
        [Range(0, 2000, ErrorMessage = "Zakres wynosi od 0 do 2000 stron")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "Wprowadź rok wydania")]
        [Range(1500, 2023, ErrorMessage = "Rok wydania ma zakres od 1500 do 2023")]
        public int Year { get; set; }
    }
}
