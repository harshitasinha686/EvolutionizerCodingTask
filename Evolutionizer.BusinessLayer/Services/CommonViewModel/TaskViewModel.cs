using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.Services.CommonViewModel
{
    public class TaskViewModel : BaseViewModel
    {
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        public List<TaskViewModel> ChildTask { get; set; }
    }
}
