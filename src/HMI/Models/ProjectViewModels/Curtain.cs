using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMI.Models.ProjectViewModels
{
    public class Curtain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ширину шторы")]
        [Range(0.5, 10, ErrorMessage = "Длина шторы должна быть от 0.5 до 10 метров")]
        [Display(Name = "Длина")]
        public double Width { get; set; }

        [Required(ErrorMessage = "Введите высоту шторы")]
        [Range(1, 5, ErrorMessage = "Высота шторы должна быть от 1 до 5 метров")]
        [Display(Name = "Высота")]
        public double Height { get; set; }

        [Required]
        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "Материал")]
        public string Material { get; set; }

        //[Required]
        //[Display(Name = "Форма шторы")]
        //public string Form { get; set; }

        [Required(ErrorMessage = "Введите количество штор")]
        [Range(1, 50, ErrorMessage = "Количество штор должно быть от 1 до 50")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

    }
}
