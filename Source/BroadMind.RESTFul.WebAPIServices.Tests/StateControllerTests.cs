using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Controllers;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BroadMind.RESTFul.WebAPIServices.Tests
{
    [TestClass]
    public class StateControllerTests
    {
        private Mock<IStateService> _mockRepo;
        private string _locationUrl;
        private Mock<UrlHelper> _mockUrlHelper;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepo = new Mock<IStateService>();
            _mockUrlHelper = new Mock<UrlHelper>();
            _locationUrl = "http://localhost:51979/v1/State/";
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockRepo = null;
            _mockUrlHelper = null;
            _locationUrl = string.Empty;
        }

        [TestMethod, TestCategory("Happy Path")]
        public void Get_State_Returns_State() 
        {
            //Arrange
            var stateList = new List<State>
            {
                new State
                {
                    StateId = 1234,
                    StateCode = "TX",
                    StateName = "Texas"
                },
                new State
                {
                    StateId = 7874,
                    StateCode = "ID",
                    StateName = "Idaho"
                }
            };
            var mockStateService = new Mock<IStateService>();
            mockStateService.Setup(x => x.GetAll(null)).Returns(stateList);
            var controller = new StateController(mockStateService.Object);

            // Act
            IEnumerable<StateModel> states = controller.GetStates();

            //Assert
            Assert.IsNotNull(states);
            Assert.AreEqual(2, states.Count());
        }

        [TestMethod, TestCategory("Happy Path")]
        public void Post_State_Results_Success()
        {
            //Arrange
            var state = new State
            {
                StateId = 1234,
                StateCode = "TX",
                StateName = "Texas"
            };
            var stateModel = new StateModel
            {
                StateId = state.StateId,
                StateCode = state.StateCode,
                StateName = state.StateName
            };

            _mockRepo.Setup(x => x.Add(state));
            var stateController = new StateController(_mockRepo.Object)
            {
                Request = new HttpRequestMessage()
            };
            stateController.Request.SetConfiguration(new HttpConfiguration());
            _mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_locationUrl);
            stateController.Url = _mockUrlHelper.Object;
            //Act
            var response = stateController.PostState(stateModel);

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Accepted);
        }

        [TestMethod, TestCategory("Happy Path")]
        public void Post_State_Results_StateId_Success()
        {
            //Arrange
     
            var state = GetState();
           

            _mockRepo.Setup(x => x.Add(state));
            var stateController = new StateController(_mockRepo.Object)
            {
                Request = new HttpRequestMessage()
            };
            stateController.Request.SetConfiguration(new HttpConfiguration());
           
            _mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_locationUrl);
            stateController.Url = _mockUrlHelper.Object;
            //Act
            var stateModel = new StateModel
            {
                StateId = state.StateId,
                ModifiedDate = state.ModifiedDate,
                CreatedDate = state.CreatedDate,
                StateCode = state.StateCode,
                ModifiedBy = state.ModifiedBy
            };

            stateController.PostState(stateModel);

            //Assert
            Assert.AreEqual(stateController.PostState(stateModel).StatusCode, System.Net.HttpStatusCode.Accepted);
        }

        private static State GetState()
        {
            var state = new State
            {
                StateId = 7654321,
                CreatedDate = DateTime.Parse("12/23/2014"),
                ModifiedBy = "Maurice",
                ModifiedDate = null,
                StateCode = "PR",
                StateName = "Puerto Rico"
            };
            return state;
        }

        [TestMethod, TestCategory("Happy Path")]
        public void Post_State_Sets_LocationHeader()
        {
            //Arrange
            var state = new State
            {
                StateId = 1234,
                StateCode = "TX",
                StateName = "Texas",
                CreatedDate = DateTime.Parse("07/30/2016")
            };
            var stateModel = new StateModel
            {
                StateId = state.StateId,
                StateCode = state.StateCode,
                StateName = state.StateName,
                CreatedDate = DateTime.Parse("07/30/2016")
            };
            _mockRepo.Setup(x => x.Add(state));
            var stateController = new StateController(_mockRepo.Object)
            {
                Request = new HttpRequestMessage()
            };
            stateController.Request.SetConfiguration(new HttpConfiguration());
            _mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns(_locationUrl);
            stateController.Url = _mockUrlHelper.Object;

            //Act
            var response = stateController.PostState(stateModel);

            // Assert
            Assert.AreEqual(_locationUrl, response.Headers.Location.AbsoluteUri);
        }
    }
}
