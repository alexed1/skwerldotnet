using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Skwerl.Controllers;
using Skwerl.Models;


namespace SkwerlUnitTester
{

    [TestFixture]
    class TaskListUnitTests
    {
        [Test]
        public void TaskList_Index_Returns_ViewResult()
        {
            //Arrange
            TaskListsController controller = new TaskListsController();

            //Act
            var actual = controller.Index();

            //Assert
            Assert.IsInstanceOf<ViewResult>(actual);
        }
    }
}
