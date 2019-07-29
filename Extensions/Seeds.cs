using System;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;


namespace Projekt.Extensions
{
    public static class Seeds
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Bills(modelBuilder);
            Phones(modelBuilder);
            Clients(modelBuilder);
            Countries(modelBuilder);
            Operators(modelBuilder);
            PhoneOperators(modelBuilder);
            Locations(modelBuilder);
        }

        

        public static void Bills(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>().HasData(
                new Bill()
                {
                    Date=DateTime.Parse("2019-01-01"),
                    Tax = 25,
                    Amount = 1000,
                    Currency = "HRK",
                    PhoneId = 1,
                    FullPriceWithTax = 1250
                },
                new Bill()
                {
                    Date=DateTime.Parse("2019-02-01"),
                    Tax = 25,
                    Amount = 100,
                    Currency = "HRK",
                    PhoneId = 2,
                    FullPriceWithTax = 125
                },
                new Bill()
                {
                    Date=DateTime.Parse("2019-01-02"),
                    Tax = 20,
                    Amount = 1000,
                    Currency = "HRK",
                    PhoneId = 1,
                    FullPriceWithTax = 1200
                }
            );
        }

        public static void Countries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country()
                {
                    Id = 1,
                    Name = "Croatia"
                },
                new Country()
                {
                    Id = 2,
                    Name = "USA"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Germany"
                }
            );
        }

        public static void Clients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client()
                {
                    Id = 1,
                    FirstName = "Albert",
                    LastName = "Einstein",
                    BirthDate = DateTime.Parse("1879-03-14"),
                    Email = "albein@hotmail.com",
                    LocationId = 1
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Valentin",
                    LastName = "Štuban",
                    BirthDate = DateTime.Parse("1996-03-14"),
                    Email = "tin_stuban@hotmail.com",
                    LocationId = 2

                },
                new Client()
                {
                    Id = 3,
                    FirstName = "Marko",
                    LastName = "Štuban",
                    BirthDate = DateTime.Parse("1999-03-14"),
                    Email = "Marko_stuban@hotmail.com",
                    LocationId = 3
                }
            );
        }
        public static void Locations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    Id = 1,
                    Name = "Mraclin",
                    CountryId = 1
                },
                new Location()
                {
                    Id = 2,
                    Name = "New York",
                    CountryId = 2
                },
                new Location()
                {
                    Id = 3,
                    Name = "Berlin",
                    CountryId = 3
                }
            );
        }
        public static void Operators(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operator>().HasData(
                new Operator()
                {
                    Id = 1,
                    DialingNumber = 0968630778,
                    LocationId = 1
                },
                new Operator()
                {
                    Id = 2,
                    DialingNumber = 0968640778,
                    LocationId = 2
                },
                new Operator()
                {
                    Id = 1,
                    DialingNumber = 0968610778,
                    LocationId = 3
                }
            );
        }
        public static void Phones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                new Phone()
                {
                    Id = 1,
                    RegistrationDate = DateTime.Parse("2018-03-03"),
                    ClientId = 1
                },
                new Phone()
                {
                    Id = 2,
                    RegistrationDate = DateTime.Parse("2019-03-03"),
                    ClientId = 2
                },
                new Phone()
                {
                    Id = 3,
                    RegistrationDate = DateTime.Parse("2001-03-03"),
                    ClientId = 3
                }

            );
        }
        public static void PhoneOperators(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneOperator>().HasData(
                new PhoneOperator()
                {
                    Id = 1,
                    Sim = "nano",
                    OperatorId = 1,
                    PhoneId = 1
                },
                new PhoneOperator()
                {
                    Id = 2,
                    Sim = "micro",
                    OperatorId = 2,
                    PhoneId = 2
                },
                new PhoneOperator()
                {
                    Id = 3,
                    Sim = "regular",
                    OperatorId = 3,
                    PhoneId = 3
                }

            );
        }

    }
}