using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REV_EXAM_3.Models
{
    public class BasicDemoClass: IValidatableObject
    {
        //Steps to follow in order to activate a db according to a model
        /*
         *1. Create the model 
         * 2. Add the [Key] attribute on the PK of the model/ also import the data annotation
         * 3.Build/rebuilt project/solution
         * 4.Create an Entity frame work controller
         * 5. Also, just in case you will need to modify something in the future, do the following command in the nugget managaer"
         * ---> Enable-Migrations -EnableAutomaticMigrations
         */

        [Key]
        public int myPk { get; set; }

        [MinLength(3, ErrorMessage ="It needs at least 3 char")]
        public string name1 { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Invalid Date")]
        [Required]
        public DateTime randomeDate { get; set; }


        // this is to refresh you about the IValidatable object in case it is in the exam
        // Also remember, this will activate only after the data anotation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // cheking is the date is more than 2 years ago according to now
            if(randomeDate < DateTime.Now.AddYears(-2))
            {
                yield return (new ValidationResult(errorMessage: "The date SHALL not PASS", memberNames: new[] { "randomeDate" }));
            }
        }



        /*
         * If you later on want to add a field, then all you have to do is is tu build again then:
         * --->Add-migration Initial
         * --->update-database -f 
         */
    }
}