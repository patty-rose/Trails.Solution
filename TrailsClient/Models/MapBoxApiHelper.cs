using System.Threading.Tasks;
using RestSharp;

namespace TrailsClient.Models
{
  class MapBoxApiHelper
  {
    public static async Task<string> GetMap()
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"TrailMarkers", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    // public static async Task<string> Get(int id)
    // {
    //   RestClient client = new RestClient("http://localhost:5004/api");
    //   RestRequest request = new RestRequest($"TrailMarkers/{id}", Method.GET);
    //   var response = await client.ExecuteTaskAsync(request);
    //   return response.Content;
    // }

    // public static async Task Post(string newTrailMarker)
    // {
    //   RestClient client = new RestClient("http://localhost:5004/api");
    //   RestRequest request = new RestRequest($"TrailMarkers", Method.POST);
    //   request.AddHeader("Content-Type", "application/json");
    //   request.AddJsonBody(newTrailMarker);
    //   var response = await client.ExecuteTaskAsync(request);
    // }

    // public static async Task Put(int id, string newTrailMarker)
    // {
    //   RestClient client = new RestClient("http://localhost:5004/api");
    //   RestRequest request = new RestRequest($"TrailMarkers/{id}", Method.PUT);
    //   request.AddHeader("Content-Type", "application/json");
    //   request.AddJsonBody(newTrailMarker);
    //   var response = await client.ExecuteTaskAsync(request);
    // }

    // public static async Task Delete(int id)
    // {
    //   RestClient client = new RestClient("http://localhost:5004/api");
    //   RestRequest request = new RestRequest($"TrailMarkers/{id}", Method.DELETE);
    //   request.AddHeader("Content-Type", "application/json");
    //   var response = await client.ExecuteTaskAsync(request);
    // }
  }
}