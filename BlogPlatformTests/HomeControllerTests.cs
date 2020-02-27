using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Controllers;

namespace BlogPlatformTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_A_View()
        {
            var underTest = new HomeController();
            var result = underTest.Index();
            Assert.IsType<ViewResult>(result);
        }

    }
}
