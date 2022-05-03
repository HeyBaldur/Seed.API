using System;

namespace Seed.Models.V1.Models
{
   public class DimCreatedEmployees
    {
        /// <summary>
        /// Unique identifier of the record
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Unique identifier of the employees
        /// </summary>
        public int DimEmployeeId { get; set; }
        
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Employee
        /// </summary>
        public DimEmployee DimEmployee { get; set; }
    }
}
