using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skwerl.Models
{
    public class TaskList
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public Task Task { get; set; }
    }

}