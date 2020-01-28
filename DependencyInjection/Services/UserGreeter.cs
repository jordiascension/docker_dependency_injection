using DependencyInjection.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Services
{
    public class UserGreeter : IUserGreeter
    {
        private readonly string user;

        public UserGreeter(string user)
        {
            this.user = user;
            Console.WriteLine($"Created {nameof(UserGreeter)} instance with user {this.user}");
        }

        public string Salute()
        {
            return $"Hola usuario {user}";
        }
    }
}
