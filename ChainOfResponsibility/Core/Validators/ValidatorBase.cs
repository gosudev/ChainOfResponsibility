using System.Collections.Generic;

namespace ChainOfResponsibility.Core.Validators
{
    public abstract class ValidatorBase
    {
        protected ValidatorBase Successor { get; private set; }
        protected Dictionary<string, string> ErrorsResult { get; set; }

        protected ValidatorBase()
        {
            ErrorsResult = new Dictionary<string, string>();
        }

        public abstract Dictionary<string, string> HandleValidation(Models.ApartmentBooking model);

        /// <summary>
        /// Set next validation
        /// </summary>
        /// <param name="successor"></param>
        public void SetSuccessor(ValidatorBase successor)
        {
            this.Successor = successor;
        }
    }
}