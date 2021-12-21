namespace Autoservice.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int RequestID { get; set; }
        public int ClientID { get; set; }
        public int MasterID { get; set; }
        public int ClientCarID { get; set; }

        public Request Request { get; set; }
        public Client Client { get; set; }
        public Master Master { get; set; }
        public ClientCar ClientCar { get; set; }
    }
}
