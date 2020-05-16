using System.Collections.Generic;

namespace ApiBox.StarWars
{
    public class Person : Node
    {
        public static IEnumerable<Person> Seed()
        {
            return new[]
            {
                new Person() { Id = "AS", Name = "Anakin Skywalker", HomePlanetId = "Tattoine" },
                new Person() { Id = "LS", Name = "Luke Skywalker",   HomePlanetId = "Tattoine" },
                new Person() { Id = "CB", Name = "Chewbacca",        HomePlanetId = "Kashyyk" },
                new Person() { Id = "SP", Name = "Sheev Palpatine",  HomePlanetId = "Naboo" },
                new Person() { Id = "HS", Name = "Han Solo",         HomePlanetId = "Corellia" }
            };
        }

        public string Name { get; set; } = "";
        public string HomePlanetId { get; set; } = "";
    }
}
