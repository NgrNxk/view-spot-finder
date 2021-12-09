using System;
using System.Collections.Generic;
using System.IO;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Microsoft.Extensions.DependencyInjection;
using ViewSpotFinder.Business;

[assembly:LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]
namespace ViewSpotFinder
{
    public class Handler
    {
        private readonly ServiceProvider _serviceProvider;

        public Handler(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Handler() : this(StartUp.Container.BuildServiceProvider())
        {

        }

        public IList<Model.Value> Hello(Request request)
        {
            using var stream = new FileStream(Path.Combine("testdata", request.Filename), FileMode.Open, FileAccess.Read);
            var mesh = new DefaultLambdaJsonSerializer().Deserialize<Model.InputMesh>(stream);

            var finder = new Business.ViewSpotFinder(new ParsedMesh(mesh));
            
            return finder.findViewSpots(request.ViewPointCount);
        }
    }

    public class Response
    {
        public IList<Model.Value> ViewSpots { get; set; }

        public Response(IList<Model.Value> viewSpots)
        {
            ViewSpots = viewSpots;
        }
    }

    public class Request
    {
        public string Filename { get; set; }
        public int ViewPointCount { get; set; }
    }

}

