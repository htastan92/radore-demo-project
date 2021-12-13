using Autofac;
using Business.Abstract;
using Business.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    internal class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            

            builder.RegisterType<AccountApiManager>().As<IAccountApiService>();

        }
    }
}
