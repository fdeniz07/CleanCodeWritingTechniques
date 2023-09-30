using System;

namespace ReferenceTypesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 20;
            int number2 = 25;

            number1=number2;
            number2 = 30;
            Console.WriteLine(number1);


            int[] numbers1 = new[] { 1, 2, 3 };
            int[] numbers2 = new[] { 4, 5, 6 };

            numbers1=numbers2;
            numbers2[0] = 30;
            Console.WriteLine(numbers1[0]);



            Customer customer = new Customer{Id=1,FirstName = "Joe"};
            Customer customer2 = customer;

            Person person1 = customer;
            Person person2 = new Employee();

            PersonDal personDal = new PersonDal();
            personDal.Add(new Visitor());

            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }

    class Customer:Person
    {
        public string CreditCardNo { get; set; }
    }

    class Employee : Person
    {
        public decimal Salary { get; set; }
    }

    class Visitor : Person
    {
        public string VisitorCardNo { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    class PersonDal
    {
        public void Add(Person person)
        {

        }
    }
}
