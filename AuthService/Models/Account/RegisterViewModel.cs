using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static AuthService.Models.MaskedType;

namespace AuthService.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Имя пользователя обязательно для заполнения")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Почта обязательна для заполнения")]
        [MaskedType(Masks.Email, ErrorMessage = "Невалидный Email адрес")]
        public string Email { get; set; }

        [MaskedType(Masks.MobilePhohe, ErrorMessage = "Номер должен быть в формате 79009009090")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Пароль обязательный для заполнения")]
        [MinLength(8, ErrorMessage = "Минимальная длина пароля 8 символов")]
        [MaskedType(Masks.IsUpperCase, ErrorMessage = "Пароль должен содержать одну и более прописную букву [A-Z][А-Я]")]
        [MaskedType(Masks.IsLowerCase, ErrorMessage = "Пароль должен содержать одну и более строчную букву [a-z][а-я]")]
        [MaskedType(Masks.IsSpecialCharacter, ErrorMessage = "Пароль должен содержать один и более специальный символ [!@#$%^&*()_+.]")]
        [MaskedType(Masks.IsDigit, ErrorMessage = "Пароль должен содержать одну и более цифру")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
