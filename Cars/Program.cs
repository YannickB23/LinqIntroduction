﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");

            #region Extension method syntax:
            //var query = cars.OrderByDescending(c => c.Combined)
            //                .ThenBy(c => c.Name);
            #endregion

            /*Query syntax: */
            var query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending     /*ascending hoeft niet want is default*/
                select new
                {
                    car.Manufacturer,
                    car.Name,
                    car.Combined
                };

            #region Extension method syntax: 
            //var top =
            //    cars.OrderByDescending(c => c.Combined)
            //        .ThenBy(c => c.Name)
            //        .Select(c => c)
            //        .First(c => c.Manufacturer == "BMW" && c.Year == 2016);
            #endregion

            var result = cars.SelectMany(c => c.Name);

            foreach (var character in result)
            {
                Console.WriteLine(character);
            }

            //foreach (var car in query.Take(10))
            //{
            //    Console.WriteLine($"{car.Name} : {car.Combined}");
            //}
        }

        #region Extension method syntax:
        //private static List<Car> ProcessFile(string path)
        //{
        //    return
        //    File.ReadAllLines(path)
        //        .Skip(1)
        //        .Where(line => line.Length > 1)
        //        .Select(Car.ParseFromCSV)
        //        .ToList();
        //}
        #endregion

        /*Query syntax: */
        private static List<Car> ProcessFile(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }
    }
    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');

                yield return new Car
                {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7]),
                };
            }
        }
    }
}