using web_Api_Proje.Models;

namespace web_Api_Proje.Services
{
    public interface IVehicleService
    {
        List<Vehicle> GetVehiclesByColor(string color);
        List<Vehicle> GetCarsByColor(string color);
        List<Vehicle> GetBusesByColor(string color);
        List<Vehicle> GetBoatsByColor(string color);
        void ToggleHeadlights(int carId);
        void DeleteCar(int carId);
    }

    public class VehicleService:IVehicleService
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public List<Vehicle> GetVehiclesByColor(string color)
        {
            return _vehicles.FindAll(v => v.Color == color);
        }

        public List<Vehicle> GetCarsByColor(string color)
        {
            return _vehicles.FindAll(v => v is Car && v.Color == color);
        }

        public List<Vehicle> GetBusesByColor(string color)
        {
            return _vehicles.FindAll(v => v is Bus && v.Color == color);
        }

        public List<Vehicle> GetBoatsByColor(string color)
        {
            return _vehicles.FindAll(v => v is Boat && v.Color == color);
        }

        public void ToggleHeadlights(int carId)
        {
            var car = _vehicles.Find(v => v is Car && v.Id == carId) as Car;
            if (car != null)
            {
                car.HasHeadlights = !car.HasHeadlights;
            }
        }

        public void DeleteCar(int carId)
        {
            _vehicles.RemoveAll(v => v is Car && v.Id == carId);
        }
    }
}

