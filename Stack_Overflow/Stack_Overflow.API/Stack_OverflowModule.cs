using Autofac;
using Stack_Overflow.API.Contexts;

namespace Stack_Overflow.API
{
    public class Stack_OverflowModule: Module
    {
        private readonly string _connectionString;

        public Stack_OverflowModule(string connectionString)
        {
            _connectionString = connectionString;
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();
           
            //builder.RegisterType<ShowGroupDataService>().As<IShowGroupDataService>()
            //  .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
