using B201210597.Models.DTO;

namespace B201210597.Models.DTO
{
    public class koafor
    {
        public int koaforId { get; set; }
        public string koaforName { get; set; }
        public string WorkingDays { get; set; }
        public string WorkingHours { get; set; }

            public int salonId { get; set; }
            public salon salon { get; set; }
		    public List<salon> salons { get; set; }

        public List<SonRandevu> Randevular{ get; set; }

        public List<Appointment> Appointments { get; set; }
    }

}
