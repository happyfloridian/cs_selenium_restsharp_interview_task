using System.Text.Json;
using ApiTests.Pocos;
using RestSharp;

namespace ApiTests.ApiTests;

[TestFixture]
public class CommentsEndpointsTests : ApiBase
{
    [Test]
    public void UserCanCreateNewComment()
    {
        var idOfPostToComment = 1;
        var request = new RestRequest($"posts/{idOfPostToComment}/comments", Method.Post);
        var response = client.Post(request);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
    }
    
    [Test]
    public void UserCanRetrieveAllCommentsForAPost()
    {
        var idOfPost = 1;
        var request = new RestRequest($"comments?postId={idOfPost}", Method.Get);
        var response = client.Get(request);
        var deserialized = JsonSerializer.Deserialize<List<GetCommentsPoco>>(response.Content);

        Assert.That((int)response.StatusCode, Is.EqualTo(200));
        
        foreach (var each in deserialized)
        {
            Assert.That(each.PostId, Is.EqualTo(idOfPost));
            Assert.That(each.Id, Is.Not.EqualTo(null));
            Assert.That(each.Name, Is.Not.Null);
            Assert.That(each.Email, Is.Not.Null);
            Assert.That(each.Body, Is.Not.Null);
        }
    }
}