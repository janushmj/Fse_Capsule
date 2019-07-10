using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class Project
    {
        public int Project_Id { get; set; }
        public string Name { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public int Priority { get; set; }
    }
}