using System;

namespace CESAPI.Model
{
    public class ServiceAccount
    {
        public int ServiceAccountID { get; set; }
        public string CompanyName { get; set; }
        public Guid CollaborationID { get; set; }
    }
}
