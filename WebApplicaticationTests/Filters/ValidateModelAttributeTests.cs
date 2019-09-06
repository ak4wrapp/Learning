using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicatication.Controllers;
using WebApplicatication.Filters;

namespace WebApplicaticationTests.Filters
{
    [TestClass]
    public class ValidateModelAttributeTests
    {
        [TestMethod]
        public void Test_Default() {

            var validationFilter = new ValidateModelAttribute();
            var modelState = new ModelStateDictionary();
            modelState.AddModelError("name", "invalid");

            var actionContext = new ActionContext(
                Mock.Of<HttpContext>(),
                Mock.Of<RouteData>(),
                Mock.Of<ActionDescriptor>(),
                modelState
            );

            var actionExecutingContext = new ActionExecutingContext(
                actionContext,
                new List<IFilterMetadata>(),
                new Dictionary<string, object>(),
                Mock.Of<Controller>()
            );

            validationFilter.OnActionExecuting(actionExecutingContext);

            Assert.IsInstanceOfType(actionExecutingContext.Result, typeof(BadRequestObjectResult));
        }
    }
}
