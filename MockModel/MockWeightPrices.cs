using System.Collections.Generic;

namespace EIT.MockModel
{
    public class MockWeightPrices
    {
        public int Id { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int Price { get; set; }

        public MockWeightPrices(int id, int minimum, int maximum, int price) { 
            Id= id;
            Minimum= minimum;
            Maximum= maximum;
            Price= price;
        }
        public static List<MockWeightPrices> GetMockWeightPrices()
        {
            var mockWeights = new List<MockWeightPrices>{
                new MockWeightPrices(1, 0, 10, 8),
                new MockWeightPrices(2, 0, 10, 5),
                new MockWeightPrices(3, 10, 50, 8 ),
                new MockWeightPrices(4, 10, 50, 5),
                new MockWeightPrices(5, 50, 100, 8 ),
                new MockWeightPrices(6, 50, 100, 5)
            };

            return mockWeights;
        }
    }
}
