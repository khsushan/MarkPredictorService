using Autofac;
using MarkPredictor.Shared;
using MarkPredictor.Shared.Models;
using MarkPredictorService.Common;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace MarkPredictorService.App_Code
{
    public class Programme
    {
        public static void AppInitialize()
        {
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:9000/"));
            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
            host.Open();
            Console.WriteLine("Service is up and running");
            Console.WriteLine("Press enter to quit ");
            ConfigAutofac();
            Common.AutoMapper.Initialize();
            Console.ReadLine();
            host.Close();
           

        }

        private static void ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MarkPredictorDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleModel>();
            builder.RegisterType<LevelModel>();
            builder.RegisterType<AssessmentModel>();
            InstanceFactory.Container = builder.Build();
        }
    }
}