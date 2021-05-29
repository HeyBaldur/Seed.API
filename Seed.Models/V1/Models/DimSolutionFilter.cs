using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed.Models.V1.Models
{
    public class DimSolutionFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FilterLevel { get; set; }
        public string Description { get; set; }
        public int SolutionId { get; set; }
        public int? DimSolutionId { get; set; }
        public virtual DimSolution DimSolution { get; set; }

        /// <summary>
        /// Produces the set difference of two sequences.
        /// </summary>
        public class FilterComparer : IEqualityComparer<DimSolutionFilter>
        {
            /// <summary>
            /// Determines whether two object instances are equal.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public bool Equals(DimSolutionFilter x, DimSolutionFilter y)
            {
                return x.Name == y.Name &&
                    x.FilterLevel == y.FilterLevel &&
                    x.SolutionId == y.SolutionId &&
                    x.Description == y.Description;
            }

            /// <summary>
            /// Serves as the default hash function.
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int GetHashCode(DimSolutionFilter obj)
            {
                //Check whether the object is null
                if (obj is null) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = obj == null ? 0 : obj.GetHashCode();

                //Get hash code for the Code field.
                int hashProductCode = obj.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName ^ hashProductCode;
            }
        }
    }
}
