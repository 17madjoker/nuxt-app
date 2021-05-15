using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AuthService.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public sealed class MaskedType : ValidationAttribute
    {
        private readonly string _mask;

        public MaskedType(string mask = null)
        {
            _mask = mask;
        }

        public override bool IsValid(object value)
        {
            var val = Convert.ToString(value).Trim();

            if (string.IsNullOrEmpty(val))
                return true;

            return Regex.IsMatch(val, _mask);
        }

        public static class Masks
        {
            public const string Login = @"^[A-Za-zА-Яа-я0-9!@#$%^&*()_+.]+$";
            public const string Email = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            public const string MobilePhohe = @"^[7][0-9]{10}$";
            public const string IsUpperCase = @"[A-ZА-Я]+";
            public const string IsLowerCase = @"[a-zа-я]+";
            public const string IsSpecialCharacter = @"[!@#$%^&*()_+.]+";
            public const string IsDigit = @"[0-9]+";
        }
    }
}
