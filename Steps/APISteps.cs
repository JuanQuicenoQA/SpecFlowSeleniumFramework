using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecflowBDD.POCO.JsonBodyRequests;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowBDD.Steps
{
    [Binding]
    public class APISteps
    {
        Task<int> statusCode;
        ReadBookingsIds getBookingIds = new ReadBookingsIds();
        CreateBooking createBooking = new CreateBooking();
        DeletePet deleteBooking = new DeletePet();
        bool result = false;

        #region When

        [When(@"sends Get Method")]
        public void WhenSendsGetMethod()
        {
            statusCode = getBookingIds.GetBookingIds();
        }

        [When(@"sends Post Method")]
        public void WhenSendsPostMethod()
        {
            statusCode = createBooking.CreateBrandNewBooking();
        }

        [When(@"sends Delete Method")]
        public void WhenSendsDeleteMethod()
        {
            statusCode = deleteBooking.DeleteExistingBooking();
        }

        #endregion

        #region Then

        [Then(@"the response code should be (.*)")]
        public void ThenTheResponseCodeShouldBe(int expectedStatusCode)
        {
            if (expectedStatusCode == statusCode.Result)
            {
                result = true;
            }
            Assert.IsTrue(result);
            result = false;
        }

        #endregion
    }
}
