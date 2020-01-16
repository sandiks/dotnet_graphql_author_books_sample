using WebApp.GraphqlSample.Database;
using GraphQL;

namespace WebApp.GraphqlSample.Graphql 
{
  [GraphQLMetadata("Mutation")]
  public class Mutation 
  {
    [GraphQLMetadata("addAuthor")]
    public Author Add(string name)
    {
      return null;
    }
  }
}
