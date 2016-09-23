using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HMI.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите ваш электронный адрес")]
        [EmailAddress]
        [Display(Name = "Электронный адрес")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Пароль должен состоять от 6 до 100 символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "Ваше имя")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Имя должно состоять от 6 до 50 символов")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Сотовый телефон")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Введите корректный номер телефона")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }

        

        [Required(ErrorMessage = "Введите почтовый индекс")]
        [Display(Name = "Почтовый индекс")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Почтовый индекс должен состоять из шести цифр (пр. '61060')")]
        public string PostalCode { get; set; }
    }
}
