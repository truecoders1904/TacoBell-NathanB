using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

            double furthestDistance = 0;
            ITrackable locA = null;
            ITrackable locB = null;


            for (int i = 0; i < locations.Length; i++)
            {

                GeoCoordinate corA = new GeoCoordinate();
                corA.Latitude = locations[i].Location.Latitude;
                corA.Longitude = locations[i].Location.Longitude;


                for (int k = 0; k < locations.Length; k++)
                {
                    GeoCoordinate corB = new GeoCoordinate();
                    corB.Latitude = locations[k].Location.Latitude;
                    corB.Longitude = locations[k].Location.Longitude;

                    if (corA.GetDistanceTo(corB) >= furthestDistance)
                    {
                        furthestDistance = corA.GetDistanceTo(corB);
                         
                        locA = locations[i];
                       
                        locB = locations[k];
                    }
                }
            }

            Console.WriteLine($"The two furtherst Tacobells are {locA.Name} and {locB.Name}");
        }
    }
}