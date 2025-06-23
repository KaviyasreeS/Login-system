namespace HospitalSystemAPI.Models
{
    public class Patient
    {
        public int Id { get; set; } // Auto-increment
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}