using project_intro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Validations
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class ProductComplexValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var p = value as ProductDTO;
            if(p == null)
            {
                throw new InvalidOperationException();
            }

            if(p.Name.StartsWith("A") && p.Price > 200)
            {
                return false;
            }

            return true;
        }
    }
}
