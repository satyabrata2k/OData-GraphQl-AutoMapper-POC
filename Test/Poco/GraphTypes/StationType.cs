using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Poco.GraphTypes
{
    public class StationType : ObjectGraphType<Station>
    {
        public StationType()
        {
            Field(x => x.Id).Description("Id of an Station");
            Field(x => x.Name).Description("Name of an Station");
            Field(x => x.CommunicationId).Description("Communication Id of an Station");
            Field(x => x.Enabled).Description("Is Station Enabled");
            Field(x => x.IpAddress).Description("Ip description of an Station");
        }
    }
}
