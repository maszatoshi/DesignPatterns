using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.Creational.Builder
{
    public interface IUser
    {
        string Name { get; }
        int Age { get; }
        string Address { get; }
    }

    public class User : IUser
    {
        private string name;
        private int age;
        private string address;

        public string Name { get { return name; } }
        public int Age { get { return age; } }
        public string Address { get { return address; } }


        private User() { }

        //UserBuilder nélkül nem lehet létrehozni User-t
        public class UserBuilder
        {
            private readonly User user;

            public UserBuilder()
            {
                user = new User();
            }

            // Azért UserBuildert return-ölünk, hogy fluent API-t lehessen használni az object build-hez
            public UserBuilder WithName(string name)
            {
                user.name = name;
                return this;
            }

            public UserBuilder WithAge(int age)
            {
                user.age = age;
                return this;
            }

            public UserBuilder WithAddress(string address)
            {
                user.address = address;
                return this;
            }

            // Ezzel adjuk vissza a User-t.
            public User Build()
            {
                return user;
            }
        }

        
    }
}
