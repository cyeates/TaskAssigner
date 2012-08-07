using TaskAssigner.Domain;
using TaskAssigner.Models;
using TaskAssigner.Models.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TaskAssigner.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(TaskAssigner.App_Start.NinjectWebCommon), "Stop")]

namespace TaskAssigner.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<TaskAssignerContext>().To<TaskAssignerContext>().InRequestScope();
            kernel.Bind<ITicketRepository>().To<TicketRepository>();
            kernel.Bind<IDeveloperRepository>().To<DeveloperRepository>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<OptimizationAlgorithm>().To<RandomOptimize>();
            kernel.Bind<DeveloperService>().To<DeveloperService>();

        }        
    }
}
