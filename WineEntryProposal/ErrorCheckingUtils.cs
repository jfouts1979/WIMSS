using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace WineEntryProposal
{
    public class ErrorCheckingUtils

    {


    }

    // After doing a search on DbEntityValidationException - How can I easily tell what caused the error?
    // This code was available as a solution on stackoverflow.  So I incorporated into my solution.
    // There were some tweaks available to the solution on that site that I also updated to allow for even 
    // further information on errors as it will be important with future updates of the app to allow for 
    // quick debugging to take place.  Thank you future version of myself.  (and Daylen - nephew).

    public partial class SomethingSomethingEntities
    {
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }


}