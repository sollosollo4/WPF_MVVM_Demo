using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.Data
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static Person[] GetPeople()
        {
            var result = new Person[]
            {
                new Person() {FirstName = "Иван", LastName = "Иванович"},
                new Person() {FirstName = "Сергей", LastName = "Сергеевич"},
                new Person() {FirstName = "Виталий", LastName = "Витальевич"},
                new Person() {FirstName = "Влад", LastName = "Владиславович"},
            };

            return result;
        }
    }
}
