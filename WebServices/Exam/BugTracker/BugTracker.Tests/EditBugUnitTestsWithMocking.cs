namespace BugTracker.Tests
{
    using System;
    using System.Linq.Dynamic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;

    using BugTracker.Data.Models;
    using BugTracker.RestServices.Controllers;
    using BugTracker.RestServices.Models.Bugs;
    using BugTracker.Tests.Models;

    using Messages.Tests.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EditBugUnitTestsWithMocking
    {
        [TestMethod]
        public void EditExistingBugTitle_ShouldReturn200OK_Modify()
        {
            // Arrange -> create a new bug
            var data = new BugTrackerDataMock();
            var bug = new Bug() { Id = 1, Title = "test", Status = Status.Open };
            data.Bugs.Add(bug);

            var controller = new BugsController(data);
            this.SetupControllerForTesting(controller, "bugs");
            
            // Act -> edit the above created bug
            var httpResponse = controller.PatchEditBug(1, new BugBindingEditBugModel() { Title = "test1" })
              .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> 200 OK
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            // Assert the service holds the modified bug
            Assert.AreEqual("test1", bug.Title);
            Assert.AreEqual(Status.Open, bug.Status);
        }

        [TestMethod]
        public void EditExistingBugDescriptionAndStatus_ShouldReturn200OK_Modify()
        {
            // Arrange -> create a new bug
            var data = new BugTrackerDataMock();
            var bug = new Bug() { Id = 1, Title = "test", Status = Status.Open };
            data.Bugs.Add(bug);

            var controller = new BugsController(data);
            this.SetupControllerForTesting(controller, "bugs");

            // Act -> edit the above created bug
            var httpResponse = controller.PatchEditBug(1, new BugBindingEditBugModel() { Description = "Bomba",  Status = "Closed" })
              .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> 200 OK
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            // Assert the service holds the modified bug
            Assert.AreEqual("test", bug.Title);
            Assert.AreEqual(Status.Closed, bug.Status);
            Assert.AreEqual("Bomba", bug.Description);
        }


        [TestMethod]
        public void EditNonExistingBug_ShouldReturn404NotFound()
        {
            // Arrange -> create a new bug
            var data = new BugTrackerDataMock();

            var controller = new BugsController(data);
            this.SetupControllerForTesting(controller, "bugs");

            // Act -> edit the above created bug
            var httpResponse = controller.PatchEditBug(1, new BugBindingEditBugModel() { Description = "Bomba", Status = "Closed" })
              .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> 404 Not found
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditExistingBug_NoDataSend_ShouldReturn400BadRequest()
        {
            // Arrange -> create a new bug
            var data = new BugTrackerDataMock();
            var bug = new Bug() { Id = 1, Title = "test", Status = Status.Open };
            data.Bugs.Add(bug);

            var controller = new BugsController(data);
            this.SetupControllerForTesting(controller, "bugs");

            // Act -> edit the above created bug
            var httpResponse = controller.PatchEditBug(1, null)
              .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> 404 Not found
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }


        private void SetupControllerForTesting(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }
    }
}
