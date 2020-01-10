using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//B1 Changes 1.0
//B2 Changes 1.0
//B2 Changes 1.1
//B2 Changes 1.2

namespace Test.Poco
{
    public class AcsSettingMapping
    {
        public int Id { get; set; }
        public Station Station { get; set; }
        public AcsSetting Setting { get; set; }
    }

    public class AcsSetting
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int CommunicationId { get; set; }
        public bool Enabled { get; set; }
    }
}
