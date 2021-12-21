using Autoservice.Models;
using System;
using System.Linq;

namespace Autoservice.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ServiceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var clients = new Client[]
            {
                new Client { FirstMidName = "Carson",   LastName = "Alexander",
                    PhoneNumber = "89999999999", Email="rururu@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString()},
                new Client { FirstMidName = "Meredith", LastName = "Alonso",
                    PhoneNumber = "89999999998", Email="rururu1@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Arturo",   LastName = "Anand",
                    PhoneNumber = "89999999997", Email="rururu2@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    PhoneNumber = "89999999996", Email="rururu3@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Yan",      LastName = "Li",
                    PhoneNumber = "89999999995", Email="rururu4@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Peggy",    LastName = "Justice",
                    PhoneNumber = "89999999994", Email="rururu5@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Laura",    LastName = "Norman",
                    PhoneNumber = "89999999993", Email="rururu6@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() },
                new Client { FirstMidName = "Nino",     LastName = "Olivetto",
                    PhoneNumber = "89999999992", Email="rururu7@mail.ru", Password="BillyVan", Role=Role.Клиент.ToString() }
            };

            foreach (Client s in clients)
            {
                context.Clients.Add(s);
            }
            context.SaveChanges();

            var masters = new Master[]
            {
                new Master { FirstMidName = "Kim",     LastName = "Abercrombie",
                    Stage = 2, Email="ukukuk@gmail.com", Password="Sir143", Role=Role.Мастер.ToString() },
                new Master { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    Stage = 5, Email="ukukuk1@gmail.com", Password="Sir143", Role=Role.Мастер.ToString() },
                new Master { FirstMidName = "Roger",   LastName = "Harui",
                    Stage = 1, Email="ukukuk2@gmail.com", Password="Sir143", Role=Role.Мастер.ToString() },
                new Master { FirstMidName = "Candace", LastName = "Kapoor",
                    Stage = 8, Email="ukukuk3@gmail.com", Password="Sir143", Role=Role.Мастер.ToString() },
                new Master { FirstMidName = "Roger",   LastName = "Zheng",
                    Stage = 5, Email="ukukuk4@gmail.com", Password="Sir143", Role=Role.Мастер.ToString() }
            };

            foreach (Master i in masters)
            {
                context.Masters.Add(i);
            }
            context.SaveChanges();

            var cars = new Car[]
            {
                new Car { Name = "Lada",     Model="Granta"},
                new Car { Name = "Kia",     Model="K5"},
                new Car { Name = "BMW",     Model="X6"},
                new Car { Name = "Renaut",     Model="Logan"},
                new Car { Name ="Ford", Model="Focus"}
            };

            foreach (Car d in cars)
            {
                context.Cars.Add(d);
            }
            context.SaveChanges();

            var clientCars = new ClientCar[]
            {
                new ClientCar {Number = "T096PA43", Year = 2016,
                    CarID = cars.Single( s => s.Name == "Lada").CarID
                },
                new ClientCar {Number = "Y039TA116", Year = 2015,
                    CarID = cars.Single( s => s.Name == "Ford").CarID
                },
                new ClientCar {Number = "B143PA777", Year = 2021,
                    CarID = cars.Single( s => s.Name == "BMW").CarID
                },
                new ClientCar {Number = "B666AT16", Year = 2013,
                    CarID = cars.Single( s => s.Name == "Lada").CarID
                },
                new ClientCar {Number = "T098PA43", Year = 2020,
                    CarID = cars.Single( s => s.Name == "Kia").CarID
                },
                new ClientCar {Number = "A765YE99", Year = 2016,
                    CarID = cars.Single( s => s.Name == "Renaut").CarID
                },
                new ClientCar {Number = "T065OP12", Year = 2016,
                    CarID = cars.Single( s => s.Name == "Lada").CarID
                },
            };

            foreach (ClientCar c in clientCars)
            {
                context.ClientCars.Add(c);
            }
            context.SaveChanges();

            var requests = new Request[]
            {
                new Request {Date = DateTime.Parse("2015-09-01"), Price = 5200,
                    ClientId = 1,
                    MasterId = 2,
                    ClientCarId = 1
                },
                new Request {Date = DateTime.Parse("2018-10-01"), Price = 4300,
                    ClientId = 3,
                    MasterId = 1,
                    ClientCarId = 4
                },
                new Request {Date = DateTime.Parse("2020-12-01"), Price = 25900,
                    ClientId = 7,
                    MasterId = 5,
                    ClientCarId = 2
                },
                new Request {Date = DateTime.Parse("2021-09-12"), Price = 50000,
                    ClientId = 4,
                    MasterId = 1,
                    ClientCarId = 3
                },
                new Request {Date = DateTime.Parse("2016-07-03"), Price = 12000,
                    ClientId = 3,
                    MasterId = 4,
                    ClientCarId = 5
                },
            };

            foreach (Request c in requests)
            {
                context.Requests.Add(c);
            }
            context.SaveChanges();

            /*var ccars = new Ccar[]
            {
                new Ccar {
                    CarID=1,
                    ClientCarID=1},
                new Ccar {
                    CarID=5,
                    ClientCarID=2},
                new Ccar {
                    CarID=3,
                    ClientCarID=3},
                new Ccar {
                    CarID=1,
                    ClientCarID=4},
                new Ccar {
                    CarID=2,
                    ClientCarID=5},
                new Ccar {
                    CarID=4,
                    ClientCarID=6},
                new Ccar {
                    CarID=1,
                    ClientCarID=7},
            };

            foreach (Ccar o in ccars)
            {
                context.Ccars.Add(o);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    RequestID = 1,
                    ClientID = 1,
                    MasterID = 2,
                    ClientCarID = 1
                },
                new Enrollment {
                    RequestID = 2,
                    ClientID = 3,
                    MasterID = 1,
                    ClientCarID = 4
                },
                new Enrollment {
                    RequestID = 3,
                    ClientID = 7,
                    MasterID = 5,
                    ClientCarID = 2
                },
                new Enrollment {
                    RequestID = 4,
                    ClientID = 4,
                    MasterID = 1,
                    ClientCarID = 3
                },
                new Enrollment {
                    RequestID = 5,
                    ClientID = 3,
                    MasterID = 4,
                    ClientCarID = 5
                },
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Client.ID == e.ClientID &&
                            s.Request.RequestID == e.RequestID &&
                            s.Master.ID == e.MasterID &&
                            s.ClientCar.ClientCarID == e.ClientCarID).SingleOrDefault();
                if (enrollmentInDataBase != null)   
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();*/
        }
    }
}