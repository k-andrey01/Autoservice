namespace Autoservice.Models
{
    public class Ccar
    {
        public int CcarID { get; set; }
        public int CarID { get; set; }
        public int ClientCarID { get; set; }

        public Car Car { get; set; }
        public ClientCar ClientCar { get; set; }
    }
}
