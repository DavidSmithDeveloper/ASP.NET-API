namespace DavidWebApi.Models.Repositories
{
    public static class CarRepository
    {
        private static List<Car> cars = new List<Car>()
        {
            new Car { CarId = 1, Make = "Toyota", Model = "Corolla", Doors = 4, Color = "White", Price = 20000},
            new Car { CarId = 2, Make = "Honda", Model = "Accord", Doors = 2, Color = "Blue", Price = 15000},
            new Car { CarId = 3, Make = "Ford", Model = "Focus", Doors = 4, Color = "Green", Price = 10000}
        };

        public static List<Car> GetCars()
        {
            return cars;
        }

        public static bool CarExists(int id)
        {
            return cars.Any(x => x.CarId == id);
        }

        public static Car? GetCarById(int id)
        {
            return cars.FirstOrDefault(x => x.CarId == id);
        }

        public static Car? GetCarByProperties(string? make, string? model, string? color)
        {
            return cars.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(make) &&
            !string.IsNullOrWhiteSpace(x.Make) &&
            x.Make.Equals(make, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(model) &&
            !string.IsNullOrWhiteSpace(x.Model) &&
            x.Model.Equals(model, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
        }
        public static void AddCar(Car car)
        {
            int maxId = cars.Max(x => x.CarId);
            car.CarId = maxId + 1;
            cars.Add(car);
        }
        public static void UpdateCar(Car car) 
        {
            var carToUpdate = cars.First(x => x.CarId ==  car.CarId);
            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            carToUpdate.Color = car.Color;
            carToUpdate.Doors = car.Doors;
            carToUpdate.Price = car.Price;
        }

        public static void DeleteCar(int carId) 
        {
            var car = GetCarById(carId);
            if (car != null)
            {
                cars.Remove(car);
            }
        }
    }
}
