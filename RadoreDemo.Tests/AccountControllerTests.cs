using Business.Abstract;
using Dto.Account;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RadoreDemo.Controllers;
using System.Collections.Generic;
using Xunit;

namespace RadoreDemo.Tests
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountApiService> _mockService;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockService = new Mock<IAccountApiService>();
            _controller = new AccountController(_mockService.Object);
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForAdd()
        {
            var result = _controller.Add();

            Assert.IsType<ViewResult>(result);
        }       


    }
}
