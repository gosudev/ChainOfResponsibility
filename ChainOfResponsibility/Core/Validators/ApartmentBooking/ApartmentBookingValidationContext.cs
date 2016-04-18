using System.Collections.Generic;

namespace ChainOfResponsibility.Core.Validators.ApartmentBooking
{
    public class ApartmentBookingValidationContext
    {
        public static Dictionary<string, string> Validate(Models.ApartmentBooking model)
        {
            /* Hook up validation chain
             DateFrom not null
             DateTo not null
             DateFrom greater than now
             DateTo greater than DateFrom
             Dummy apartment validation base on type
             */

            DateFromRequiredValidator dateFromRequiredValidator = new DateFromRequiredValidator();
            DateFromRangeValidator dateFromRangeValidator = new DateFromRangeValidator();
            dateFromRequiredValidator.SetSuccessor(dateFromRangeValidator);
            DateToRequiredValidator dateTimeToRequiredValidator = new DateToRequiredValidator();
            dateFromRangeValidator.SetSuccessor(dateTimeToRequiredValidator);
            DateToRangeValidator dateToRangeValidator = new DateToRangeValidator();
            dateTimeToRequiredValidator.SetSuccessor(dateToRangeValidator);
            ApartmentAvaliableValidator apartmentAvaliableValidator = new ApartmentAvaliableValidator();
            dateToRangeValidator.SetSuccessor(apartmentAvaliableValidator);

            return dateFromRequiredValidator.HandleValidation(model);
        }
    }
}