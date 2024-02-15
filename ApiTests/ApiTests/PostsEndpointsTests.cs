using System.Text.Json;
using ApiTests.Pocos;
using RestSharp;

namespace ApiTests.ApiTests;

[TestFixture]
public class PostsEndpointsTests : ApiBase
{
    [Test]
    public void UserCanRetrieveAllPosts()
    {
        var request = new RestRequest("posts", Method.Get);
        var response = client.Get(request);
        var deserialized = JsonSerializer.Deserialize<List<GetPostsPoco>>(response.Content);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        
        foreach (var each in deserialized)
        {
            Assert.That(each.UserId, Is.Not.EqualTo(null));
            Assert.That(each.Id, Is.Not.EqualTo(null));
            Assert.That(each.Title, Is.Not.Null);
            Assert.That(each.Body, Is.Not.Null);
        }
    }
    
    [Test]
    public void UserCanCreateAPost()
    {
        var newPost = new CreatePostPoco()
        {
            Title = "This is the NEW post title",
            Body = "This is the NEW post body",
            UserId = 100
        };
        
        var request = new RestRequest("posts", Method.Post);
        
        request.AddHeader("Content-type", "application/json; charset=UTF-8");
        request.AddJsonBody(newPost);
        
        var response = client.Post(request);
        var deserialized = JsonSerializer.Deserialize<GetPostsPoco>(response.Content);
        
        Assert.That((int)response.StatusCode, Is.EqualTo(201));
        
        var idOfNewPost = deserialized.Id;

        Assert.Multiple(() =>
        {
            Assert.That(idOfNewPost, Is.Not.EqualTo(null));
            Assert.That(deserialized.Title, Is.EqualTo("This is the NEW post title"));
            Assert.That(deserialized.Body, Is.EqualTo("This is the NEW post body"));
            Assert.That(deserialized.UserId, Is.EqualTo(100));
        });
    }
    
    [Test]
    public void UserCanUpdateExistingPost()
    {
        var postToUpdate = 1;
        var jsonPayload = "  {\n  " +
                          "\t\"id\": 1,\n     " +
                          "\"title\": \"this is the EDITED post title\",\n     " +
                          "\"body\": \"this is the EDITED post body\",\n     " +
                          "\"userId\": 1\n  }";
        
        var request = new RestRequest($"posts/{postToUpdate}", Method.Put);
        
        request.AddHeader("Content-type", "application/json; charset=UTF-8");
        request.AddJsonBody(jsonPayload);
        
        var response = client.Put(request);
        var deserialized = JsonSerializer.Deserialize<GetPostsPoco>(response.Content);
        
        Assert.Multiple(() =>
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(deserialized.Id, Is.EqualTo(postToUpdate));
            Assert.That(deserialized.Title, Is.EqualTo("this is the EDITED post title"));
            Assert.That(deserialized.Body, Is.EqualTo("this is the EDITED post body"));
            Assert.That(deserialized.UserId, Is.EqualTo(1));
        });
    }
    
    [Test]
    public void UserCanDeleteExistingPost()
    {
        var postToDelete = 1;
        var request = new RestRequest($"posts/{postToDelete}", Method.Delete);
        var response = client.Delete(request);
        
        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        
        //test can also continue with a GET
        //and check to make sure the List<deserialized.Id> Does.Not.Contain(postToDelete);
    }
}