using AutoMapper;
using Castle.Windsor;
using GraphQL.Types;
using Siemens.Backend.Core.ConfigurationRepository;
using Siemens.Crosscutting.Utilities.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Poco.GraphTypes;

namespace Test.Poco.Queries
{
    public class AcsSettingMappingQuery : ObjectGraphType
    {
        public AcsSettingMappingQuery()
        {
            var container = new WindsorContainer();
            container.Install(new GeneralInstaller());
            var repo = container.Resolve<IAcsSettingMappingRepository>();
            var res = Mapper.Map<IEnumerable<AcsSettingMapping>>(repo.GetAllAcsMapping().ToList()).ToList();


            Field<ListGraphType<AcsSettingMappingType>>(
                name: "acsSettingMapping",
                arguments: new QueryArguments(/*new QueryArgument<IntGraphType> { Name = "id" }*/),
                resolve: context =>
                {
                    //var id = context.GetArgument<int>("id");
                    //return res.Where(x => x.Id == id).SingleOrDefault();
                    return res;
                }
            );
            //Field<AcsSettingType>(
            //    name: "posts",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //    resolve: context =>
            //    {
            //        var id = context.GetArgument<int>("id");
            //        return blogService.GetPostsByAuthor(id);
            //    }
            //);
            //Field<StationType>(
            //    name: "socials",
            //    arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //    resolve: context =>
            //    {
            //        var id = context.GetArgument<int>("id");
            //        return blogService.GetSNsByAuthor(id);
            //    }
            //);
        }
    }
}
