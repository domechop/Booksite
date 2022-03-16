using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Booksite.Models
{
    public class Summary
    {
        [Key]
        [BindNever]

        public int SummaryId { get; set; }

        [BindNever]

        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name:")]
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state:")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a zip:")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Please enter a country:")]
        public string Country { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}