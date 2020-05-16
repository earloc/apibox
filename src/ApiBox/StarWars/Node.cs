using System;

namespace ApiBox.StarWars
{
    public class Node
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ModificationInfo Created { get; set; } = new ModificationInfo();
        public ModificationInfo Modified { get; set; } = new ModificationInfo();
    }
}
