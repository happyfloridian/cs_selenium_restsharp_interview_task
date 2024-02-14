using RestSharp;

namespace ApiTests;

public class ApiBase
{
    protected RestClient client; 
    
    [SetUp]
    public void SetUp()
    {
        client = new RestClient("https://jsonplaceholder.typicode.com/");
    }
}