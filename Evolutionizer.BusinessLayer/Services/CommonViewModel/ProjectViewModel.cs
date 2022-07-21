using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.CommonViewModel
{
    public class ProjectViewModel : BaseViewModel
    {
        public int ProgramId { get; set; }
        public List<TaskViewModel> Tasks { get; set; }
    }
}
