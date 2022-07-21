using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolutionizer.BusinessLayer.Entities
{
    public class Program : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Project> Projects { get; set; }

        public DateTime StartDate { get => CalculateStartDate(); }
        public DateTime EndDate { get => CalculateEndDate(); }

        private DateTime CalculateStartDate()
        {
            return Projects.Select(x => x.StartDate).Min();
        }
        private DateTime CalculateEndDate()
        {
            return Projects.Select(x => x.EndDate).Max();
        }
        public void UpdateProgram(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Program()
        {
            Projects = new List<Project>();
        }
    }

}
