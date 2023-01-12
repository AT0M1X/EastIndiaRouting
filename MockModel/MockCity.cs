using System.Collections.Generic;
using System.Linq;

namespace EIT.MockModel
{
    public class MockCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Available { get; set; } 

        public static List<int> GetAvailableId()
        {
            var cities = GetMockCities();
            var cityIds = cities.Where(x => x.Available == 1).Select(x => x.Id).ToList();
            return cityIds;
        }

        public static List<MockCity> GetMockCities() {
            List<MockCity> Cities = new List<MockCity>();
            Cities.Add(new MockCity {Id=1, Name= "De Kanariske Øer", Available=1}); 
            Cities.Add(new MockCity { Id = 2, Name = "Marrakesh", Available = 0 });
            Cities.Add(new MockCity { Id = 3, Name = "Tunis", Available = 1 }); 
            Cities.Add(new MockCity { Id = 4, Name = "Tripoli", Available = 0 });
            Cities.Add(new MockCity { Id = 5, Name = "Sahara", Available = 0 });
            Cities.Add(new MockCity { Id = 6, Name = "Timbuktu", Available = 0 });
            Cities.Add(new MockCity { Id = 7, Name = "Dakar", Available = 1 }); 
            Cities.Add(new MockCity { Id = 8, Name = "Wadai", Available = 0 });
            Cities.Add(new MockCity { Id = 9, Name = "Omdurman", Available = 0 });
            Cities.Add(new MockCity { Id = 10, Name = "Suakin", Available = 1 }); 
            Cities.Add(new MockCity { Id = 11, Name = "Kap Guardafui", Available = 1 }); 
            Cities.Add(new MockCity { Id = 12, Name = "Addis Abeba", Available = 0 });
            Cities.Add(new MockCity { Id = 13, Name = "Darfur", Available = 0 });
            Cities.Add(new MockCity { Id = 14, Name = "Slavekysten", Available = 1 }); 
            Cities.Add(new MockCity { Id = 15, Name = "Guldkysten", Available = 1 }); 
            Cities.Add(new MockCity { Id = 16, Name = "Sierra Leone", Available = 1 });
            Cities.Add(new MockCity { Id = 17, Name = "St. Helena", Available = 1 });
            Cities.Add(new MockCity { Id = 18, Name = "Luanda", Available = 0 });
            Cities.Add(new MockCity { Id = 19, Name = "Congo", Available = 0 });
            Cities.Add(new MockCity { Id = 20, Name = "Kabalo", Available = 0 });
            Cities.Add(new MockCity { Id = 21, Name = "Bahr El Ghazal", Available = 0 });
            Cities.Add(new MockCity { Id = 22, Name = "Victoriasøen", Available = 0 });
            Cities.Add(new MockCity { Id = 23, Name = "Zanzibar", Available = 0 });
            Cities.Add(new MockCity { Id = 24, Name = "Mocambique", Available = 1 }); 
            Cities.Add(new MockCity { Id = 25, Name = "Amatave", Available = 1 }); 
            Cities.Add(new MockCity { Id = 26, Name = "Kap St. Marie", Available = 1 }); 
            Cities.Add(new MockCity { Id = 27, Name = "Dragebjerget", Available = 0 });
            Cities.Add(new MockCity { Id = 28, Name = "Victoriafaldene", Available = 0 });
            Cities.Add(new MockCity { Id = 29, Name = "Hvalbugten", Available = 1 }); 
            Cities.Add(new MockCity { Id = 30, Name = "Kapstaden", Available = 1 }); 
            Cities.Add(new MockCity { Id = 31, Name = "Tanger", Available = 1 }); 
            Cities.Add(new MockCity { Id = 32, Name = "Cairo", Available = 1 }); 
            return Cities; 
        }
    }
}
