using System.Numerics;
using B201210597.Models.DTO;


namespace B201210597.Models.DTO
{
    
	

   
        public class salon
        {
            public int salonId { get; set; }
            public string salonName { get; set; }

            public int DepartmentId { get; set; }
            public Department Department { get; set; }

            public List<koafor> koafors { get; set; }
        public List<Department> Departments { get; internal set; }
    }

  
}
            