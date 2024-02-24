﻿namespace FinancialHub.Common.Responses.Errors
{
    public class NotFoundErrorResponse : BaseErrorResponse
    {
        public NotFoundErrorResponse(string message) : base(404, message)
        {
        }
    }
}
