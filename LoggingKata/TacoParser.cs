using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            if (line == null)
            {
                return null;
            }
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("ERROR: Array length is less than 3");
                return null;
            }

            // grab the latitude from your array at index 0
            double latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            double longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2
            string cityName = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`


            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = cityName;
            tacoBell.Location = new Point(){ Latitude = latitude, Longitude = longitude};

            return tacoBell;


        }

        public static string ShouldParse()
        {
            throw new NotImplementedException();
        }
    }
}