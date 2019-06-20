using GraphQL.Client;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");

            var heroRequest = new GraphQLRequest{Query= @"
	                                                {
  acsSettingMapping {
    id
    station {
      id
      name
      communicationId
    }
    setting {
      id
      isDeleted
    }
  }
}",
                                                };


            var graphQLClient = new GraphQLClient("http://localhost:51467/graphql/");
            var graphQLResponse = graphQLClient.PostAsync(heroRequest).GetAwaiter().GetResult();

            var dynamicHeroName = graphQLResponse.Data.acsSettingMapping; 

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
