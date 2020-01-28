using DependencyInjection.Abstractions;
using DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Register
            var services = new ServiceCollection();
            //services.AddSingleton<IGreeter,Greeter>();

            //Para realizar la inyección por llamada
            services.AddTransient<IGreeter, Greeter>();


            //Resolve
            var serviceProvider = services.BuildServiceProvider();

            var greeter1 = serviceProvider.GetService<IGreeter>();
            var greeter2 = serviceProvider.GetService<IGreeter>();
            Console.WriteLine(greeter1.Salute("Pepe"));
            Console.WriteLine(greeter2.Salute("Manuel"));
            PrintHash(greeter1);
            PrintHash(greeter2);

            //Crear su propio scope para Multitenant Architecture. By default is Singleton
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var greeter3 = scope.ServiceProvider.GetService<IGreeter>();
                Console.WriteLine(greeter3.Salute("Fernando"));
                PrintHash(greeter3);
            }

            //Fase de registro con parámetro y factoría
            //Cada vez que realicemos una instancia de FriendsMaker,
            //entonces vamos a pedir una nueva instancia de UserGreeter
            services.AddTransient<IUserGreeter>(sp =>
            {
                return new UserGreeter("Lucas");
            });
            //Lo registramos "AsSelf" porque no tiene ninguna abstracción
            services.AddTransient<FriendsMaker>();

            //Fase de resolución
            var serviceProvider2 = services.BuildServiceProvider();
            var friendMaker = serviceProvider2.GetService<FriendsMaker>();
            Console.WriteLine(friendMaker.TellAJoke());

      

        }

        static void PrintHash(Object obj)
        {
            Console.WriteLine(obj.GetHashCode().ToString());
        }
    }
}
