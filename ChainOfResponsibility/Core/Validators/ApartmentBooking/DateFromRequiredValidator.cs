using System;
using System.Collections.Generic;

namespace ChainOfResponsibility.Core.Validators.ApartmentBooking
{
    public class DateFromRequiredValidator : ValidatorBase
    {
        public override Dictionary<string, string> HandleValidation(Models.ApartmentBooking model)
        {
            if (model.DateFrom == DateTime.MinValue)
            {
                ErrorsResult.Add("DateFrom", "Date from field is required");
                return ErrorsResult;
            }

            if (Successor != null)
                return Successor.HandleValidation(model);

            return ErrorsResult;
        }
    }
}