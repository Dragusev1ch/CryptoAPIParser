using APIParser;
using Newtonsoft.Json.Linq;

var request = new GetRequest("https://cryptingup.com/api/exchanges");
request.Run();

var response = request.Response;

var json = JObject.Parse(response);
Console.WriteLine(json);
