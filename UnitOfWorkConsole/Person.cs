using System;

namespace UnitOfWorkConsole
{
    [PetaPoco.PrimaryKey("Id")]
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsLeader { get; set; }
    }
}