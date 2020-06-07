using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OrganizationForUpdateDto
    {
        [Required(ErrorMessage = "Organization name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        [MinLength(5, ErrorMessage = "Minimum length for the Name is 60 characters.")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Org Name is a required field.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is a required field.")]
        public string Country { get; set; }
    }
}