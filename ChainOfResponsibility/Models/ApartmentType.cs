using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChainOfResponsibility.Models
{
    public enum ApartmentType : byte
    {
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "One Bedroom Executive")]
        OneBedroomExecutive,
        [Display(Name = "Two Bedroom")]
        TwoBedroom,
    }
}