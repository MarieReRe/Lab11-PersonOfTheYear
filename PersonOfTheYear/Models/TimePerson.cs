using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonOfTheYear.Models
{
    public class TimePerson
    {

        //properties we want to include that the constructor needs to instantiate
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        //constructor
        public TimePerson(int year, string honor, string name, string country, int birthYear, int deathYear, string title, string category, string context)
        {
            Year = year;
            Honor = honor;
            Name = name;
            Country = country;
            BirthYear = birthYear;
            DeathYear = deathYear;
            Title = title;
            Category = category;
            Context = context;
        }

        //GetPersons method reads in the data from a csv file and store the data into a string array
        public static List<TimePerson> GetPersons(int fromYear, int toYear)
        {
            //instantiate a new list of people
            List<TimePerson> people = new List<TimePerson>();

          
            string[] personOfYearData = File.ReadAllLines("App_Data/personOfTheYear.csv");
            //for loop to split data into columns by ,

            for (var i = 1; i < personOfYearData.Length; i++)
            {
                string[] columns = personOfYearData[i].Split(',');
                TimePerson person = new TimePerson
                (

                   Convert.ToInt32(columns[0]),
                  columns[1],
                    columns[2],
                    columns[3],
                    (columns[4] == "") ? 0 : Convert.ToInt32(columns[4]),
                   (columns[5] == "") ? 0 : Convert.ToInt32(columns[5]),
                 columns[6],
                  columns[7],
                    columns[8]



            );
                  // we need to use add method to add the object to the list 
                  people.Add(person);
            }
            try
            {
                List<TimePerson> result = people.Where(p => p.Year >= fromYear && p.Year <= toYear).ToList();
                return result;
            }
            catch (ArgumentNullException aNEx)
            {

                Console.WriteLine("Sorry, please enter the range of years you'd like to search: {0}", aNEx.Message);
                
            }

            return null;
        }



    }
}
