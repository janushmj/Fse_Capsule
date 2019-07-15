using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerApi.Controllers;
using TaskManagerApi.Models;

namespace TaskManagerApi.Tests.Controllers
{
    [TestClass]
    public class TaskManagerControllerTest
    {
        [TestMethod]
        public void TestAdd()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "AddTask", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            Assert.IsNotNull(tasks.Where(t => t.Name == "AddTask").First());
        }

        [TestMethod]
        public void TestGet()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "GetTask1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            taskManagerController.AddTask(new Models.Task() { Name = "GetTask2", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            int taskId = tasks.FirstOrDefault().TaskId;
            Task task = taskManagerController.GetTask(taskId);
            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void TestGetParents()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            IEnumerable<ParentTask> tasks = taskManagerController.GetAllParentTasks();
            Assert.IsNotNull(tasks);
        }

        [TestMethod]
        public void TestDelete()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "TestDelete1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            int taskId = tasks.Where(t => t.Name == "TestDelete1").FirstOrDefault().TaskId;
            Task task = taskManagerController.GetTask(taskId);
            taskManagerController.DeleteTask(taskId);
            task = taskManagerController.GetTask(taskId);
            Assert.IsNull(task);
        }

        [TestMethod]
        public void TestUpdate()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddTask(new Models.Task() { Name = "TestUpdate1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), ParentId = 1, Priority = 10 });
            IEnumerable<Task> tasks = taskManagerController.GetAllTasks();
            Assert.IsNotNull(tasks);
            Task task = tasks.Where(t => t.Name == "TestUpdate1").FirstOrDefault();
            string newName = task.Name + "Renamed";
            task.Name = newName;
            task.StartDate = DateTime.ParseExact(task.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            task.EndDate = DateTime.ParseExact(task.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            taskManagerController.UpdateTask(task);
            task = taskManagerController.GetTask(task.TaskId);
            Assert.IsTrue(task.Name == newName);
        }

        [TestMethod]  
        public void TestAddUser()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddUser(new Models.User() { FirstName = "Janush", LastName = "P", EmployeeId = "681098" });
            IEnumerable<User> users = taskManagerController.GetAllUsers();
            Assert.IsNotNull(users);
            Assert.IsNotNull(users.Where(t => t.EmployeeId == "681098").First());
        }

        [TestMethod]
        public void TestGetUser()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddUser(new Models.User() { FirstName = "testUser", LastName = "trail", EmployeeId = "empId" });
            IEnumerable<User> users = taskManagerController.GetAllUsers();
            Assert.IsNotNull(users);
            int userId = users.FirstOrDefault().UserId;
            User user = taskManagerController.GetUser(userId);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            IEnumerable<User> users = taskManagerController.GetAllUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddUser(new Models.User() { FirstName = "TestDelete1", LastName = "TestData", EmployeeId = "test123" });
            IEnumerable<User> users = taskManagerController.GetAllUsers();
            Assert.IsNotNull(users);
            int userId = users.Where(t => t.FirstName == "TestDelete1").FirstOrDefault().UserId;
            User user = taskManagerController.GetUser(userId);
            taskManagerController.DeleteUser(userId);
            user = taskManagerController.GetUser(userId);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddUser(new Models.User() { FirstName = "updateUser", LastName = "test", EmployeeId = "empId" });
            IEnumerable<User> users = taskManagerController.GetAllUsers();
            Assert.IsNotNull(users);
            User user = users.Where(t => t.FirstName == "updateUser").FirstOrDefault();
            string newName = user.FirstName + "Renamed";
            user.FirstName = newName;
            taskManagerController.UpdateUser(user);
            user = taskManagerController.GetUser(user.UserId);
            Assert.IsTrue(user.FirstName == newName);
        }

        [TestMethod]
        public void TestAddProject()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddProject(new Models.Project() { Name = "AddProject", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), Priority = 10 });
            IEnumerable<Project> projects = taskManagerController.GetAllProjects();
            Assert.IsNotNull(projects);
            Assert.IsNotNull(projects.Where(t => t.Name == "AddProject").First());
        }

        [TestMethod]
        public void TestGetProject()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddProject(new Models.Project() { Name = "Pro1", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), Priority = 10 });
            taskManagerController.AddProject(new Models.Project() { Name = "Pro2", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), Priority = 10 });
            IEnumerable<Project> projects = taskManagerController.GetAllProjects();
            Assert.IsNotNull(projects);
            int projectId = projects.FirstOrDefault().ProjectId;
            Project project = taskManagerController.GetProject(projectId);
            Assert.IsNotNull(project);
        }

        [TestMethod]
        public void TestDeleteProject()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddProject(new Models.Project() { Name = "ProjectDelete", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), Priority = 10 });
            IEnumerable<Project> projects = taskManagerController.GetAllProjects();
            Assert.IsNotNull(projects);
            int projectId = projects.Where(p => p.Name == "ProjectDelete").FirstOrDefault().ProjectId;
            taskManagerController.DeleteProject(projectId);
            Project project = taskManagerController.GetProject(projectId);
            Assert.IsNull(project);
        }

        [TestMethod]
        public void TestUpdateProject()
        {
            TaskManagerController taskManagerController = new TaskManagerController();
            taskManagerController.AddProject(new Models.Project() { Name = "ProjectUpdated", StartDate = DateTime.Now.ToShortDateString(), EndDate = DateTime.Now.AddDays(10).ToShortDateString(), Priority = 10 });
            IEnumerable<Project> projects = taskManagerController.GetAllProjects();
            Assert.IsNotNull(projects);
            Project project = projects.Where(p => p.Name == "ProjectUpdated").FirstOrDefault();
            string newName = project.Name + "Renamed";
            project.Name = newName;
            project.StartDate = DateTime.ParseExact(project.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            project.EndDate = DateTime.ParseExact(project.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).ToString();
            taskManagerController.UpdateProject(project);
            project = taskManagerController.GetProject(project.ProjectId);
            Assert.IsTrue(project.Name == newName);
        }
    }
}