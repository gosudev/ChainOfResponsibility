using System.Collections.Generic;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Core.Validators.ApartmentBooking
{
    public class ApartmentAvaliableValidator : ValidatorBase
    {
        public override Dictionary<string, string> HandleValidation(Models.ApartmentBooking model)
        {
            /* Dummy validation */
            if (model.ApartmentType == ApartmentType.OneBedroomExecutive)
            {
                ErrorsResult.Add("ApartmentType", string.Format("{0} is currently not avaliable", model.ApartmentType));
                return ErrorsResult;
            }

            if (Successor != null)
                return Successor.HandleValidation(model);

            return ErrorsResult;
        }
    }
}