using System;
using Models;
using Models.Interface;

namespace Unity
{
    class Program
    {
        /// <summary>
        /// Declare our repository interface instance.
        /// </summary>
        private static IStudentRepository _studentRepository;

        static void Main(string[] args)
        {
            // Loading the class instance to our interface instance
            GetDependentInstances();

            Console.WriteLine($"Service Started on {DateTime.Now}");

            // Calling the api class and passing our interface instance.
            var apiInstance = new StudentApi(_studentRepository);

            // Calling the execute method to run it 😄😄😄
            apiInstance.Execute();
            Console.WriteLine($"Service Ended on {DateTime.Now}");
        }
        /// <summary>
        /// Getting All the dependency from the configuration class
        /// </summary>
        static void GetDependentInstances()
        {
            var container = UnityConfig.Register();
            _studentRepository = container.Resolve<IStudentRepository>();
        }
    }
}
