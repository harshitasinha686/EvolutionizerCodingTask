using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.CommonDto
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
