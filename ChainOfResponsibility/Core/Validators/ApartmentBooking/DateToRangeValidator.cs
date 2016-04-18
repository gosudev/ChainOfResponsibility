using System.Collections.Generic;

namespace ChainOfResponsibility.Core.Validators.ApartmentBooking
{
    public class DateToRangeValidator : ValidatorBase
    {
        public override Dictionary<string, string> HandleValidation(Models.ApartmentBooking model)
        {
            if (model.DateTo <= model.DateFrom)
            {
                ErrorsResult.Add("DateTo", "Date to should be grater than Date from");
                return ErrorsResult;
            }

            if (Successor != null)
                return Successor.HandleValidation(model);

            return ErrorsResult;
        }
    }
}