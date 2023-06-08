using project_intro.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project_intro.Models
{
    //public record Product
    //{
    //    public int Id { get; init; } = -1;
    //    public string Name { get; init; }
    //}

    [ProductComplexValidation]
    public record ProductDTO(int Id, 
        [Required(ErrorMessage ="THIS IS CUSTOM")] 
        string Name, 
        [System.ComponentModel.DataAnnotations.Range(0, 90000)]
        [OddValidation] 
        double Price);




}
