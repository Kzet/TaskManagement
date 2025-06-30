using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities.Core
{
    public class BaseGuidModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
