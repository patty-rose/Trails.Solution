using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TrailsClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrailsClient.Models
{
  public class Trail
  {
    public int TrailId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Difficulty { get; set; }

    public virtual ICollection<TrailMarker> TrailMarkers { get; set; }

    public Trail()
      {
        this.TrailMarkers = new HashSet<TrailMarker>();
      }

  public static List<Trail> GetTrails()
    {
      var apiCallTask = TrailApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Trail> TrailList = JsonConvert.DeserializeObject<List<Trail>>(jsonResponse.ToString());

      return TrailList;
    }

    //key differences between GetTrails() and GetDetails(): 1. GetDetails The method will return a singular Trail. 2. GetDetails() will take an id. 3. the API call results in a JSOn object as opposed to a JSON array
    public static Trail GetDetails(int id)
    {
      var apiCallTask = TrailApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Trail Trail = JsonConvert.DeserializeObject<Trail>(jsonResponse.ToString());

      return Trail;
    }

    public static void Post(Trail Trail)
    {
      string jsonTrail = JsonConvert.SerializeObject(Trail);//converts Trail object into JSON 
      var apiCallTask = TrailApiHelper.Post(jsonTrail);
    }

    public static void Put(Trail Trail)
    {
      string jsonTrail = JsonConvert.SerializeObject(Trail);
      var apiCallTask = TrailApiHelper.Put(Trail.TrailId, jsonTrail);
    }

    public static void Delete(int id)
    {
      var apiCallTask = TrailApiHelper.Delete(id);
    }
  }
}