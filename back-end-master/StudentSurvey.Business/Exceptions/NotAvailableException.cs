using System;

namespace StudentSurvey.Business.Exceptions
{
    public class NotAvailableException : ApplicationException
    {
        public NotAvailableException(string message) : base(message)
        {

        }
    }
}
