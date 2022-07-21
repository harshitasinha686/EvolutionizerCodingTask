using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Entities
{
    public class TaskDependency
    {
        public int Id { get; set; }
        public int ParentTaskId { get; set; }
        public Task ParentTask { get; set; }
        public int ChildTaskId { get; set; }
        public Task ChildTask { get; set; }
    }
}
