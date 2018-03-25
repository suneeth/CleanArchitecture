using System.Net;
using DDDGuestbook.Core.Entities;
using Newtonsoft.Json;
using Xunit;

namespace DDDGuestbook.Tests.Integration.Web
{
    public class ApiGuestBookControllerListShould:BaseWebTest
    {
        [Fact]
        public void ReturnsGuestBookWithOneItem()
        {
            var response = _client.GetAsync("/api/guestbook/1").Result;
            response.EnsureSuccessStatusCode();
            var stringResponse = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<GuestBook>(stringResponse);
        }

        [Fact]
        public void Returns404GivenInvalidId()
        {
            string invalidId = "100";
            var response = _client.GetAsync($"/api/guestbook/{invalidId}").Result;

            Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
            var stringResponse = response.Content.ReadAsStringAsync().Result;

            Assert.Equal(invalidId.ToString(),stringResponse);
        }
    }
}