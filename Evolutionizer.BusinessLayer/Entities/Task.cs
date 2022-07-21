using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolutionizer.BusinessLayer.Entities
{
    public class Task :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<TaskDependency> ParentTaskDependency { get; set; }
        public List<TaskDependency> ChildTaskDependency { get; set; }

        public Task(Project project, string name, string description, DateTime startDate, DateTime endDate)
        {
            Project = project;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        private double GetTaskDuration()
        {
            return (EndDate - StartDate).TotalHours;
        }
        public double GetLongestTaskDependencyDuration()
        {
            // var childTasksList = ChildTaskDependency.Select(x => x.ChildTask);
            // var maxDuration = childTasksList.Select(x => x.GetTaskDuration()).Max();
            return ChildTaskDependency.Select(x => x.ChildTask).Select(x => x.GetTaskDuration()).Sum();
        }
        public Task()
        {
            ChildTaskDependency = new List<TaskDependency>();
        }
        public void UpdateTask(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void UpdateTaskDates(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
        public void UpdateTaskDependency(List<TaskDependency> dependentTasks)
        {
            ChildTaskDependency.Clear();
            ChildTaskDependency.AddRange(dependentTasks);
        }
        
    }
}
