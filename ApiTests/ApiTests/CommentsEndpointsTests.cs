using System.Text.Json;
using ApiTests.Pocos;
using RestSharp;

namespace ApiTests.ApiTests;

[TestFixture]
[Parallelizable]
public class CommentsEndpointsTests : ApiBase
{
    [Test]
    [Retry(2)]
    public void UserCanCreateNewComment()
    {
        var idOfPostToComment = 1;
        
        var newComment = new CreateCommentPoco()
        {
            PostId = 1,
            Name = "Jane Doe",
            Email = "some.name@gmail.com",
            Body = "This is the new comment I wanted to post."
        };
        
        var request = new RestRequest($"posts/{idOfPostToComment}/comments", Method.Post);
        var response = client.Post(request);

        Assert.That((int)response.StatusCode, Is.EqualTo(201), "Response code doesn't match");
        
        //the site doesn't seem to actually record the comment
        //so I can't continue the test with a GET to check the content
    }
    
    [Test]
    [Retry(2)]
    public void UserCanRetrieveAllCommentsForAPost()
    {
        var idOfPost = 1;
        var request = new RestRequest($"comments?postId={idOfPost}", Method.Get);
        var response = client.Get(request);
        var deserialized = JsonSerializer.Deserialize<List<GetCommentsPoco>>(response.Content);

        Assert.That((int)response.StatusCode, Is.EqualTo(200), "Response code doesn't match");
        
        foreach (var each in deserialized)
        {
            Assert.That(each.PostId, Is.EqualTo(idOfPost), "Actual PostId doesn't match Id of post to see comments for");
            Assert.That(each.Id, Is.Not.EqualTo(null), "Null Id found");
            Assert.That(each.Name, Is.Not.Null, "Null name field found");
            Assert.That(each.Email, Is.Not.Null, "Null email field found");
            Assert.That(each.Body, Is.Not.Null, "Null body field found");
        }
    }
}