using System;
using System.Collections.Generic;

namespace YouthVolleyballHub.Models
{
    public class Organization
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public int Id { get; set; }

        public List<Event> events { get; set; }

        public Organization(string name, string description, string contactEmail)
        {
            Name = name;
            Description = description;
            ContactEmail = contactEmail;
        }

        public Organization()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Organization @organization &&
            Id == @organization.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

