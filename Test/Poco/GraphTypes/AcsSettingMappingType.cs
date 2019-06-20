using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Poco.GraphTypes
{
    public class AcsSettingMappingType : ObjectGraphType<AcsSettingMapping>
    {
        public AcsSettingMappingType()
        {
            Field(x => x.Id).Description("Id of an AcsSetting");
            Field<AcsSettingType>("setting");
            Field<StationType>("station");
        }
    }
}
