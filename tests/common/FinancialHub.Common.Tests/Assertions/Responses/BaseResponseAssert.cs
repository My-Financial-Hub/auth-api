﻿using FinancialHub.Common.Responses.Errors;
using FinancialHub.Common.Responses.Success;
using NUnit.Framework;

namespace FinancialHub.Common.Tests.Assertions.Responses
{
    public static class BaseResponseAssert
    {
        public static void IsValid<T>(T expected, BaseResponse<T> response)
        {
            Assert.That(expected, Is.EqualTo(response.Data));
        }

        public static void IsValid<T>(BaseResponse<T> expected, BaseResponse<T> response)
        {
            Assert.That(response.Data, Is.EqualTo(expected.Data));
        }

        public static void HasError(BaseErrorResponse expected, BaseErrorResponse response)
        {
            Assert.Multiple(() =>
            {
                Assert.That(response.Message, Is.EqualTo(expected.Message));
                Assert.That(response.Code, Is.EqualTo(expected.Code));
            });
        }
    }
}
