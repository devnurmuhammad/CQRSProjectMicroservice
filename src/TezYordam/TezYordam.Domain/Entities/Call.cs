using System.ComponentModel.DataAnnotations.Schema;

namespace TezYordam.Domain.Entities
{
    public class Call
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public DateTime CalledAt { get; set; }
        public DateTime ArrivedAt { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car? Car { get; set; }
        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
