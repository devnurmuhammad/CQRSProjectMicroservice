namespace TezYordam.Web.ViewModels
{
    public class CallDTO
    {
        public string Description { get; set; } = default!;
        public DateTime CalledAt { get; set; }
        public DateTime ArrivedAt { get; set; }
        public int PatientId { get; set; }
        public int CarId { get; set; }
        public int DoctorId { get; set; }
    }
}
