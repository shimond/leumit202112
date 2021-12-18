using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Validations
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class OddValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var stringValue = value.ToString();
            var isValid = int.TryParse(stringValue, out int result);
            if (!isValid)
            {
                return false;
            }
            return result % 2 == 1;
        }
    }
}
