using System;
using System.Collections.Generic;
using System.Text;

namespace Course
{
    internal class PersonList
    {
        private List<Person> persons = new List<Person>()
        {
            new Person("Tuomas","tuomas@veljekset.net","12.8.1990"),
            new Person("Simeoni","simo@veljekset.net","2.5.1980"),
            new Person("Aapo","aapo@veljekset.net","22.10.1970"),
            new Person("Lauri","lauri@veljekset.net","2.9.1989"),
            new Person("Juhani","jussi@veljekset.net","1.8.1978"),
        };

        public void Tulosta()
        {
            Console.WriteLine("Tulosta_____");
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }

        public void TulostaKaanteinen()
        {
            Console.WriteLine("Käänteinen_____");
            for (int i = persons.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(persons[i]);
            }
        }

        public void JarjestaNimenMukaan()
        {
            persons.Sort();
        }

        public void JarjestaIanMukaan()
        {
            persons.Sort((a, b) => a.Age.Value - b.Age.Value);
        }

        public IEnumerable<Person> EtsiNimessaOsana(string osa)
        {
            //var x = from Person p in persons where p.Name.Contains(osa) select p;
            var x = persons.Where(p => p.Name.Contains(osa));
            return x;
        }

        public IEnumerable<string> IkaSuurempi(int age)
        {
            //var x = from Person p in persons where p.Age > age select p.Name;
            var x = persons.Where(p => p.Age > age).Select(p => p.Name);
            return x;
        }
    }
}
