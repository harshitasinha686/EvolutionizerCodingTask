using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolutionizer.BusinessLayer.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Task> Tasks { get; set; }

        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public DateTime StartDate { get => CalculateStartDate(); }
        public DateTime EndDate { get => CalculateEndDate(); }

        private DateTime CalculateStartDate()
        {
            return Tasks.Select(x => x.StartDate).Min();
        }
        private DateTime CalculateEndDate()
        {
            return Tasks.Select(x => x.EndDate).Max();
        }
        public Project(Program program, string name, string description)
        {
            Program = program;
            Name = name;
            Description = description;
            Tasks = new List<Task>();
        }

        public Project()
        {
            Tasks = new List<Task>();
        }

        public void UpdateProject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Task GetTaskWithMaxChildTaskDuration()
        {
            return Tasks.OrderByDescending(x => x.GetLongestTaskDependencyDuration()).First();
        }

    }
}
