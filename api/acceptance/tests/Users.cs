using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using UserApi;
using UserApi.Models;
using App.Library.CodeStructures.Behavioural;
using UserApi.UseCases;

namespace Acceptance.Tests
{
  public class UsersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
  {
    private readonly HttpClient _client;

    public UsersControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
    {
      _client = factory.CreateClient();
    }

    [Fact]
    public async Task CanCreateUser()
    {
      var requestBody = new Dictionary<string, string>() {
        {"email", "johnny@mail.com"},
        {"password", "P@55w0rd12345"},
      };

      var json = JsonConvert.SerializeObject(requestBody);
      var data = new StringContent(json, Encoding.UTF8, "application/json");
      // The endpoint or route of the controller action.
      var httpResponse = await _client.PostAsync("/api/users", data);

      // Must be successful.
      httpResponse.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task CanReadUser()
    {
      // The endpoint or route of the controller action.
      var getHttpResponse = await _client.GetAsync("/api/users");

      // Deserialize and examine results.
      var stringResponse = await getHttpResponse.Content.ReadAsStringAsync();
      JObject response = JsonConvert.DeserializeObject<JObject>(stringResponse);

      var user = response["payload"]["users"].First().ToObject<User>(); ;

      Assert.Equal("johnny@mail.com", user.Email);
      Assert.Equal("P@55w0rd12345", user.Password);
    }
  }
}
