using Autofac;
using Stack_Overflow.API.Contexts;
using Stack_Overflow.API.Services;

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

            builder.RegisterType<QuestionService>().As<IQuestionService>()
           .InstancePerLifetimeScope();

            builder.RegisterType<AnswerService>().As<IAnswerService>()
            .InstancePerLifetimeScope();
            
            base.Load(builder);
        }

    }
}
