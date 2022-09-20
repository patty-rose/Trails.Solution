using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace TrailsClient.Models
{
  public class TrailMarker
  {
    public int TrailMarkerId { get; set; }

    public virtual Trail Trail { get; set; }

    [DisplayName("Choose Trail")]
    public int TrailId { get; set; }

    public string Name { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    [DisplayName("Trailhead")]
    public bool isTrailhead { get; set; }

    [DisplayName("Landmark")]
    public bool isLandmark { get; set; }

    public string Description { get; set; }

    public static List<TrailMarker> GetTrailMarkers()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<TrailMarker> TrailMarkerList = JsonConvert.DeserializeObject<List<TrailMarker>>(jsonResponse.ToString());

      return TrailMarkerList;
    }

    //key differences between GetTrailMarkers() and GetDetails(): 1. GetDetails The method will return a singular TrailMarker. 2. GetDetails() will take an id. 3. the API call results in a JSOn object as opposed to a JSON array
    public static TrailMarker GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      TrailMarker TrailMarker = JsonConvert.DeserializeObject<TrailMarker>(jsonResponse.ToString());

      return TrailMarker;
    }

    public static void Post(TrailMarker TrailMarker)
    {
      string jsonTrailMarker = JsonConvert.SerializeObject(TrailMarker);//converts TrailMarker object into JSON 
      var apiCallTask = ApiHelper.Post(jsonTrailMarker);
    }

    public static void Put(TrailMarker TrailMarker)
    {
      string jsonTrailMarker = JsonConvert.SerializeObject(TrailMarker);
      var apiCallTask = ApiHelper.Put(TrailMarker.TrailMarkerId, jsonTrailMarker);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}