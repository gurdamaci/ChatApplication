using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using ChatApp.Business.Abstract;
using ChatApp.Business.Concrete;
using ChatApp.Core.MessageQueuing;
using ChatApp.Core.MessageQueuing.RabbitMQ;
using ChatApp.DAL.Abstract;
using ChatApp.DAL.Concrete.ADONET;


namespace ChatApp.ASPNETWinFormUI
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }


        private void Application_Start(object sender, EventArgs e)
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();

            builder.RegisterType<RabbitMQPublisher>().As<IMQAdapter>();
            
            builder.RegisterType<AdoUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<AdoChatRoomDal>().As<IChatRoomDal>();
            builder.RegisterType<ChatRoomManager>().As<IChatRoomService>();

            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

        }
    }
}