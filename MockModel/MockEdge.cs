using System.Collections.Generic;

namespace EIT.MockModel
{
    public class MockEdge
    {
        public int Id { get; set; }
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Segments { get; set; }
        public MockEdge(int id, int source, int destination , int segments) {
            Id = id;
            Source = source;
            Destination = destination;
            Segments = segments;
        }
        public static List<MockEdge> GetMockEdges() {
            var edges = new List<MockEdge>
            {
                new MockEdge(1, 1, 7, 5),
                new MockEdge(2, 7, 1, 5),
                new MockEdge(3, 2, 16, 3 ),
                new MockEdge(4, 16, 2, 3),
                new MockEdge(5, 16, 15, 4),
                new MockEdge(6, 15, 16, 4),
                new MockEdge(7, 15, 14, 4),
                new MockEdge(8, 14, 15, 4),
                new MockEdge(9, 15, 29, 11),
                new MockEdge(10, 29, 15, 11),
                new MockEdge(11, 14, 29, 9),
                new MockEdge(12, 29, 14, 9),
                new MockEdge(13, 7, 17, 10),
                new MockEdge(14, 17, 7, 10),
                new MockEdge(15, 17, 30, 9),
                new MockEdge(16, 30, 17, 9),
                new MockEdge(17, 29, 30, 3),
                new MockEdge(18, 30, 29, 3  ),
                new MockEdge(19, 30, 26, 8),
                new MockEdge(20, 26, 30, 8),
                new MockEdge(21, 26, 24, 3),
                new MockEdge(22, 24, 26, 3),
                new MockEdge( 23, 24, 11, 8),
                new MockEdge(24, 11, 24, 8),
                new MockEdge(25, 11, 25, 8),
                new MockEdge( 26, 25, 11, 8),
                new MockEdge(27, 11, 10, 4),
                new MockEdge(28, 10, 11, 4),
                new MockEdge(29, 10, 32, 4),
                new MockEdge(30, 32, 10, 4 ),
                new MockEdge(31, 32, 3, 5),
                new MockEdge(32, 3, 32, 5),
                new MockEdge(33, 3, 31, 3),
                new MockEdge(34, 31, 3, 3),
                new MockEdge(35, 31, 1, 3),
                new MockEdge(36, 1, 31, 3),
            };
            return edges; 
        }
    }
}
