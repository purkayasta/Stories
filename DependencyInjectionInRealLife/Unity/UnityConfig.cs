using Models.Interface;
using Models.Repository;

namespace Unity
{
    internal static class UnityConfig
    {
        public static UnityContainer Register()
        {
            var container = new UnityContainer();
            container.RegisterType<IStudentRepository, StudentRepository>();
            return container;
        }
    }
}
