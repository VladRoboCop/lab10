using System;

namespace ProjectRoot.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string Product { get; set; }
    }
}
