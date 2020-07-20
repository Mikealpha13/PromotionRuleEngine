using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RuleEngineAPI.Application.ViewModels.Movies;
using RuleEngineAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineAPITest.ControllerTest
{
    [TestClass]
    public class RuleEngineControllerTest
    {

        Mock<IMediator> _mediatorObject = new Mock<IMediator>();
        Mock<PromotionRequestViewModel> _requestObject = new Mock<PromotionRequestViewModel>();

        [TestMethod]
        public void ControllerTest()
        {
            var controller = new RuleEngineController(_mediatorObject.Object);
            var result = controller.ApplicablePromotion(_requestObject.Object).GetAwaiter().GetResult();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IActionResult));

        }
    }
}
