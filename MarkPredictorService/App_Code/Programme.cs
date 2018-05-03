using Autofac;
using MarkPredictor.Shared;
using MarkPredictor.Shared.Models;
using MarkPredictorService.Common;
using MarkPredictorService.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace MarkPredictorService.App_Code
{
    public class Programme
    {
        private const string BASE_URL = "http://localhost:9000/";

        public static void AppInitialize()
        {
            WebServiceHost hostLevel = new WebServiceHost(typeof(Service), new Uri(BASE_URL));
            ServiceEndpoint levelServiceEndpoint = hostLevel.AddServiceEndpoint(typeof(ILevelService), new WebHttpBinding(), "levels/");
            WebServiceHost hostModule = new WebServiceHost(typeof(ModuleService), new Uri(BASE_URL));
            ServiceEndpoint moduleServiceEndpoint = hostModule.AddServiceEndpoint(typeof(IModuleService), new WebHttpBinding(), "modules/");
            WebServiceHost hostAssessment = new WebServiceHost(typeof(AssessmentService), new Uri(BASE_URL));
            ServiceEndpoint assessmentServiceEndpoint = hostAssessment.AddServiceEndpoint(typeof(IAssessmentService), new WebHttpBinding(), "assessments/");
            WebServiceHost hostAccount = new WebServiceHost(typeof(AccountService), new Uri(BASE_URL));
            ServiceEndpoint accountServiceEndpoint = hostAccount.AddServiceEndpoint(typeof(IAccountService), new WebHttpBinding(), "accounts/");
            ServiceDebugBehavior sdb = hostLevel.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;
            hostLevel.Open();
            hostModule.Open();
            hostAssessment.Open();
            hostAccount.Open();
            Console.WriteLine("Service is up and running");
            Console.WriteLine("Press enter to quit ");
            ConfigAutofac();
            Common.AutoMapper.Initialize();
            Console.ReadLine();
            hostLevel.Close();
            hostModule.Close();
            hostAssessment.Close();
            hostAccount.Close();
           

        }

        private static void ConfigAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MarkPredictorDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ModuleModel>();
            builder.RegisterType<LevelModel>();
            builder.RegisterType<AssessmentModel>();
             builder.RegisterType<StudentModel>();
            InstanceFactory.Container = builder.Build();
        }
    }
}