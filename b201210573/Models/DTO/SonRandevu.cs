namespace B201210597.Models.DTO
{
    public class SonRandevu
    {
       public int id { get; set; }
        public string Department { get; set; }
        public string salon { get; set; }
        public string koafor { get; set; }
        public string IsGunler { get; set; }
        public string IsSaat { get; set; }
        public List<Department> Departments { get; internal set; }
        public List<salon> salons { get; internal set; }
        public List<koafor> koafors { get; internal set; }
    }
}
