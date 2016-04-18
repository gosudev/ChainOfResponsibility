using System;
using System.Collections.Generic;

namespace ChainOfResponsibility.Core.Validators.ApartmentBooking
{
    public class DateToRequiredValidator : ValidatorBase
    {
        public override Dictionary<string, string> HandleValidation(Models.ApartmentBooking model)
        {
            if (model.DateTo == DateTime.MinValue)
            {
                ErrorsResult.Add("DateTo", "Date to 2 field is required");
                return ErrorsResult;
            }

            if (Successor != null)
                return Successor.HandleValidation(model);

            return ErrorsResult;
        }
    }
}