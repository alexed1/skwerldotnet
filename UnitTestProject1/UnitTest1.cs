using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skwerl.Controllers;
using Skwerl.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Text;
using Skwerl;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TaskList_Index_Returns_ViewResult()
        {
            //Arrange
           TaskListsController controller = new TaskListsController();

            //Act
          ViewResult result  = controller.Index() as ViewResult;

            //Assert
          Assert.IsNotNull(result);
        }



    }
}
