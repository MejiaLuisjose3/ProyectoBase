using BusinessLogic.Commun.DataBase;
using DataLocal.GeneralConfig;
using Interfaces.GeneralConfig.database;
using Unity;

namespace GeneralConfig.Injection
{
    public static class Injection
    {

        public static IUnityContainer unityContainer { get; set; }
        public static void Run(IUnityContainer container)
        {
            //Configurations
            //container.RegisterType<IDbFactory, DbFactory>();
            //container.RegisterType<IOperationResult, OperationResult>();
            //InjectionPlanes.Run(container);

            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType(typeof(IBaseModel<>), typeof(BaseModel<>));

            container.RegisterType<IOperation, Operation>();

            
             unityContainer = container;
        }

    }
}
