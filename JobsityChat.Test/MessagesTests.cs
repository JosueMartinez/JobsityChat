using JobsityChat.Data;
using JobsityChat.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace JobsityChat.Test
{
    public class MessagesTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var message = new Message { Content = "This is a test message" };
            var mockpersonRepository = new Mock<IMesssageRepository>();

            mockpersonRepository.Setup(x => x.GetAll())
            .Returns(new List<Message> { message }); //return Person
            Assert.True(mockpersonRepository.Object.GetAll().Count > 0); //Assert expected value equal to actual value

        }
    }
}