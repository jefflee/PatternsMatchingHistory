using System;
using System.Collections.Generic;

namespace PropertyPatternMatching001
{
    internal class Program
    {
        private static void Main(string[] _)
        {
            foreach (var p in Create())
            {

                if (p is { FirstName: string firstName, LastName: "Chung", Address: { City: string city, ZipCode: "100" } })
                {
                    Console.WriteLine($"Hi {firstName} from {city}");
                }
            }
            Console.ReadLine();
        }

        private static List<Person> Create()
        {
            return new List<Person>()
            {
                { "Bill" , "Chung" , "Taipei", "100"  },
                { "Tom", "Chung", "Taichung", "200" },
                { "John" ,  "Lee" , "Taipei" , "100"},
                { "John" ,  "Lee" , "Taichung" , "200"},
            };
        }
    }

    internal static class PersonExtensions
    {
        public static void Add(this ICollection<Person> people, string firstName, string lastName, string city, string zipCode)
        {
            people.Add(new Person { FirstName = firstName, LastName = lastName, Address = new Address { City = city, ZipCode = zipCode } });
        }
    }

    internal class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

    }

    internal class Address
    {
        public string City { get; set; }

        public string ZipCode { get; set; }

    }
}
