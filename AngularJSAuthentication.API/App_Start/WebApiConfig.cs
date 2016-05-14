using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using TicketSystem.Core.Model;

namespace TicketSystem.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            //config.MapHttpAttributeRoutes();
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Event>("Events");
            builder.EntitySet<EventType>("EventTypes");
            builder.EntitySet<TicketPurchase>("TicketPurchases");
            config.MapODataServiceRoute(
                "odata",
                "api",
                builder.GetEdmModel(),
                new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer)
            );
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.EnsureInitialized();

        }
    }
}
