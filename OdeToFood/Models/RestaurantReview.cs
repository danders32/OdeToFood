using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{


    public class RestaurantReview : IValidatableObject
    {
        public int ID { get; set; }

        [Range(1,10, ErrorMessage="custom")]
        [Required]
        public int Rating { get; set; }

        [Required(ErrorMessageResourceType=typeof(OdeToFood.Views.Home.Resources), ErrorMessageResourceName="Greeting")]
        [StringLength(1024)]
        public string BOdy { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText="anonymous")]

        public string ReviewerName { get; set; }
        public int RestaurantID { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("scott"))
            {
                yield return new ValidationResult("Sorry, Scott, you can't do this");
            }
        }
    }
}