using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Poco.GraphTypes
{
    public class AcsSettingType : ObjectGraphType<AcsSetting>
    {
        public AcsSettingType()
        {
            Field(x => x.Id).Description("Id of an AcsSetting");
            Field(x => x.Description).Description("Desc of an AcsSetting");
            Field(x => x.IsDeleted).Description("Is Deleted");
        }
    }
}
