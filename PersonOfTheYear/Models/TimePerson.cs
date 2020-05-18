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

        public TimePerson()
        {

        }

        //GetPersons method reads in the data from a csv file and store the data into a string array
        public static List<TimePerson> GetPersons(TimeSelected timeSelected)
        {
            string[] personOfYearData = File.ReadAllLines("App_Data/personOfTheYear.csv");
            List<TimePerson> people = new List<TimePerson>();

            //for loop to split data into columns by ,

            for (var i = 0; i < personOfYearData.Length; i++)
            {
                string[] columns = personOfYearData[i].Split(',');
                TimePerson person = new TimePerson()
                {
                    Year = int.Parse(columns[0]),
                    Honor = columns[1],
                    Name = columns[2],
                    Country = columns[3],
                    BirthYear = (columns[4] == "") ? 0 : Convert.ToInt32(columns[4]),
                    DeathYear = (columns[5] == "") ? 0 : Convert.ToInt32(columns[5]),
                    Title = columns[6],
                    Category = columns[7],
                    Context = columns[8],

                };
                  // we need to use add method to add the object to the list 
                  people.Add(person);
            }
            List<TimePerson> result = people.Where(p => (p.Year >= timeSelected.FromYear && p.Year <= timeSelected.ToYear)).ToList();
            return result;
        }



    }
}
