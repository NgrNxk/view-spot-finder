using Amazon.Lambda.Core;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace ViewSpotFinder
{
    public class Handler
    {
       public Response Hello(Request request)
       {
           return new Response("Go Serverless v1.0! Your function executed successfully!", request);
       }
    }

    public class Response
    {
      public string Message {get; set;}
      public Request Request {get; set;}

      public Response(string message, Request request){
        Message = message;
        Request = request;
      }
    }

    public class Request: Model.Mesh
    {
    }

}

