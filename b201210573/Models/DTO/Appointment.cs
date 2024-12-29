using System.Numerics;

namespace B201210597.Models.DTO
{
    public class Appointment
    {

        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int koaforId { get; set; }
        public  koafor Koafor { get; set; }
        public List<koafor> koafors { get; internal set; }
        public List<Kullanici> KullaniciLer { get; internal set; }
        public List<salon> salons { get; internal set; }
        public List<Department> Departments { get; internal set; }
    }
}
