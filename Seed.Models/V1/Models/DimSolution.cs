using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Models.V1.Models
{
    public class DimSolution
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionSub { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<DimSolutionFilter> Filters { get; set; }
    }
}
