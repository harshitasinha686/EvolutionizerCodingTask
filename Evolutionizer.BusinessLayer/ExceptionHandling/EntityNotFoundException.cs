using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionizer.BusinessLayer.ExceptionHandling
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message, object key) : base("Entity  " + " "+message+" " + key + "  Not found")
        { 

        }
    }
}
