using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HTTPRequests;
using Moq;
using Xunit;
using Newtonsoft.Json;

namespace HTTPRequestsTests
{
    /*
    public class RequestsTestsFixture {
        public Requests req;
        public Mock moq;
        public RequestsTestsFixture()
        {
            var moqRes = new Mock<HttpResponseMessage>();
            var res = moqRes.Object;
            var moqHttp = new Mock<HTTPRequests.HttpClientHandler>();
            moqHttp.Setup(x => x.GetAsync("http://google.com"));
            moq = moqHttp;
            req = new Requests(moqHttp.Object);
        }
    }
    */

    public class RequestsTests //: IClassFixture<RequestsTestsFixture>
    {
        [Fact]
        public void GetData_CheckGetAsyncIsCalled()
        {
            // Arrange/Setup
            //var moqRes = new Mock<HttpResponseMessage>();
            var moqHttp = new Mock<HTTPRequests.IHttpClientHandler>();
            moqHttp.Setup(HttpHandler => HttpHandler.GetAsync(It.IsAny<string>()))
                   .Returns(() => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)));
            var req = new Requests(moqHttp.Object);
            var url = "testurl";

            // Act
            var todo = req.GetData(url);

            // Assert
            moqHttp.Verify(moqHttpInst => moqHttpInst.GetAsync(It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        public void GetData_CheckGetAsyncIsCalled_EmptyContent()
        {
            // Arrange/Setup
            var response = new HttpResponseMessage( HttpStatusCode.OK );
            var moqHttp = new Mock<HTTPRequests.IHttpClientHandler>();
            moqHttp.Setup(HttpHandler => HttpHandler.GetAsync(It.IsAny<string>()))
                   .Returns(() => Task.FromResult(response) );
            var req = new Requests(moqHttp.Object);
            var url = "testurl";

            // Act
            var todo = req.GetData(url);
            Console.WriteLine("Ending here after expection");

            // Assert
            Assert.True(todo.IsCompleted);

        }

        [Fact]
        public void GetData_CheckGetAsyncIsCalled_ReturnsString()
        {
            // Arrange/Setup

            // Content = new StringContent(SerializedString, System.Text.Encoding.UTF8, "application/json")
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Content here 123") };
            var moqHttp = new Mock<HTTPRequests.IHttpClientHandler>();
            moqHttp.Setup(HttpHandler => HttpHandler.GetAsync(It.IsAny<string>()))
                   .Returns(() => Task.FromResult(response));
            var req = new Requests(moqHttp.Object);
            var url = "testurl";

            // Act
            var todo = req.GetData(url);
            Console.WriteLine(todo.Result);

            // 
            Assert.Equal("Content here 123", todo.Result);
        }

        [Fact]
        public void GetData_CheckGetAsyncIsCalled_ReturnsJSON()
        {
            // Arrange/Setup
            var mockJson = "{\"GroupId\":1,\"Samples\":[{\"SampleId\":1},{\"SampleId\":2}]}";
            var JSONContent = new StringContent(mockJson, System.Text.Encoding.UTF8, "application/json");
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = JSONContent };
            var moqHttp = new Mock<HTTPRequests.IHttpClientHandler>();
            moqHttp.Setup(HttpHandler => HttpHandler.GetAsync(It.IsAny<string>()))
                   .Returns(() => Task.FromResult(response));
            var req = new Requests(moqHttp.Object);
            var url = "testurl";

            // Act
            var todo = req.GetData(url);
            Console.WriteLine(todo.Result);

            // Assert
            Assert.Equal(mockJson, todo.Result);
        }
    }
}
