using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace WebUI2
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    //public class RootObject
    //{
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Probabilities for Class \"0\"")]
    //    public Double Class0 { get; set; }
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Probabilities for Class \"1\"")]
    //    public Double Class1 { get; set; }
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Probabilities for Class \"2\"")]
    //    public Double Class2 { get; set; }
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Probabilities for Class \"3\"")]
    //    public Double Class3 { get; set; }
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Probabilities for Class \"4\"")]
    //    public Double Class4 { get; set; }
    //    [Newtonsoft.Json.JsonProperty(PropertyName = "Scored Labels")]
    //    public Int32 ScoredClass { get; set; }

    //}
    public class FaceVal
    {
        //public FaceVal(Int32 ScoredClass, Double Probability);
        public Double Probability { get; set; }
        public Int32 ScoredClass { get; set; }
    }

public class Rootobject
{
public Results Results { get; set; }
}

public class Results
{
public Output1 output1 { get; set; }
}

public class Output1
{
public string type { get; set; }
public Value value { get; set; }
}

public class Value
{
public string[] ColumnNames { get; set; }
public string[] ColumnTypes { get; set; }
public string[][] Values { get; set; }
}


    public class CallAmlService
    {
        static string apiKey = ConfigurationManager.AppSettings["AMLAPIKey"].ToString();
        public static async Task<FaceVal> CallAml()
        {
            FaceVal x = await InvokeRequestResponseService();
            return x;
        }

        static async Task<FaceVal> InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"Column1.FaceLandmarks.PupilLeft.X", "Column1.FaceLandmarks.PupilLeft.Y", "Column1.FaceLandmarks.PupilRight.X", "Column1.FaceLandmarks.PupilRight.Y", "Column1.FaceLandmarks.NoseTip.X", "Column1.FaceLandmarks.NoseTip.Y", "Column1.FaceLandmarks.MouthLeft.X", "Column1.FaceLandmarks.MouthLeft.Y", "Column1.FaceLandmarks.MouthRight.X", "Column1.FaceLandmarks.MouthRight.Y", "Column1.FaceLandmarks.EyebrowLeftOuter.X", "Column1.FaceLandmarks.EyebrowLeftOuter.Y", "Column1.FaceLandmarks.EyebrowLeftInner.X", "Column1.FaceLandmarks.EyebrowLeftInner.Y", "Column1.FaceLandmarks.EyeLeftOuter.X", "Column1.FaceLandmarks.EyeLeftOuter.Y", "Column1.FaceLandmarks.EyeLeftTop.X", "Column1.FaceLandmarks.EyeLeftTop.Y", "Column1.FaceLandmarks.EyeLeftBottom.X", "Column1.FaceLandmarks.EyeLeftBottom.Y", "Column1.FaceLandmarks.EyeLeftInner.X", "Column1.FaceLandmarks.EyeLeftInner.Y", "Column1.FaceLandmarks.EyebrowRightInner.X", "Column1.FaceLandmarks.EyebrowRightInner.Y", "Column1.FaceLandmarks.EyebrowRightOuter.X", "Column1.FaceLandmarks.EyebrowRightOuter.Y", "Column1.FaceLandmarks.EyeRightInner.X", "Column1.FaceLandmarks.EyeRightInner.Y", "Column1.FaceLandmarks.EyeRightTop.X", "Column1.FaceLandmarks.EyeRightTop.Y", "Column1.FaceLandmarks.EyeRightBottom.X", "Column1.FaceLandmarks.EyeRightBottom.Y", "Column1.FaceLandmarks.EyeRightOuter.X", "Column1.FaceLandmarks.EyeRightOuter.Y", "Column1.FaceLandmarks.NoseRootLeft.X", "Column1.FaceLandmarks.NoseRootLeft.Y", "Column1.FaceLandmarks.NoseRootRight.X", "Column1.FaceLandmarks.NoseRootRight.Y", "Column1.FaceLandmarks.NoseLeftAlarTop.X", "Column1.FaceLandmarks.NoseLeftAlarTop.Y", "Column1.FaceLandmarks.NoseRightAlarTop.X", "Column1.FaceLandmarks.NoseRightAlarTop.Y", "Column1.FaceLandmarks.NoseLeftAlarOutTip.X", "Column1.FaceLandmarks.NoseLeftAlarOutTip.Y", "Column1.FaceLandmarks.NoseRightAlarOutTip.X", "Column1.FaceLandmarks.NoseRightAlarOutTip.Y", "Column1.FaceLandmarks.UpperLipTop.X", "Column1.FaceLandmarks.UpperLipTop.Y", "Column1.FaceLandmarks.UpperLipBottom.X", "Column1.FaceLandmarks.UpperLipBottom.Y", "Column1.FaceLandmarks.UnderLipTop.X", "Column1.FaceLandmarks.UnderLipTop.Y", "Column1.FaceLandmarks.UnderLipBottom.X", "Column1.FaceLandmarks.UnderLipBottom.Y", "Assignments"},
                                //Values = new string[,] {  {"59.8","85.8","112.3","90.9","81.9","115.2","60.5","144.1","99.7","148.2","37.9","67.8","76.7","67","49.5","85","58.7","82.4","57.6","89.2","66.8","87.9","98.5","68.1","133.6","76.7","104.1","91.3","112.6","87.5","112.6","94.4","121.8","92.2","79.2","90.9","92.8","91.7","71.5","107.5","94.2","110.6","66","118.1","97.3","122.8","81.7","134.1","80.8","140.1","81.1","149","79.9","158.1","0" },  }
                                Values = new string[,] {  { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },  }

                            }
                        },
                                        },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                //const string apiKey = "abc123"; // Replace this with the API key for the web service
                try {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                    
                    client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/ed92dffcd0724f1991aa01acc940fc67/services/0f398fce58aa4b34b3031db24ce41f8b/execute?api-version=2.0&details=true");
                    // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                    // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                    // For instance, replace code such as:
                    //      result = await DoSomeTask()
                    // with the following:
                    //      result = await DoSomeTask().ConfigureAwait(false)


                    HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                    if (response.IsSuccessStatusCode)
                    {
                        //string result = await response.Content.ReadAsStringAsync();
                        //RootObject model = JsonConvert.DeserializeObject<RootObject>(result);

                        Rootobject model = await response.Content.ReadAsAsync<Rootobject>();
                        string[] values= model.Results.output1.value.Values[0];
                        Int32 Class = Convert.ToInt32(values[values.Length - 1]);
                        FaceVal val = new FaceVal();
                        val.ScoredClass = Class;
                        val.Probability = Convert.ToDouble(values[Class]);

                        return val;
                        //Console.WriteLine("Result: {0}", result);
                    }
                    else
                    {
                        // Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                        // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                        //Console.WriteLine(response.Headers.ToString());

                        string responseContent = await response.Content.ReadAsStringAsync();
                        return null;
                        //Console.WriteLine(responseContent);
                    }
                }
                catch(Exception ex)
                {
                    var msg = ex.Message;

                }

                return null;

            }
        }
    }


}