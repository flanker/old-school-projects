using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using kaogu_0730.Module;
using MvcWeb.Models;
using Npgsql;
using NUnit.Framework;

namespace MvcWeb.Test.ModelTests
{
    [TestFixture]
    public class ProjectTest
    {
        private const string TestName = "testName";
        private const string TestIdentify = "testIdentify";
        private readonly XPQuery<Project> _projectQuery;
        private readonly ProjectRepository _repository;

        public ProjectTest()
        {
            EditModelPermission.AlwaysGranted = Debugger.IsAttached;
            const string connectionString = "Server=localhost; User Id=postgres;Password=postgres;Database=ais2011_UnitTest;Encoding=UNICODE;";
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                new NpgsqlConnection(connectionString),
                AutoCreateOption.DatabaseAndSchema);

            _projectQuery = new XPQuery<Project>(Session.DefaultSession);
            _repository = new ProjectRepository();
        }

        [SetUp]
        public void Init()
        {
            
        }

        [TearDown]
        public void Cleanup()
        {
            var projects = _projectQuery.ToList();
            foreach (var project in projects)
            {
                project.Delete();
            }
        }

        [Test]
        public void Should_return_all_projects()
        {
            var project = CreateProject();
            project.Save();

            var projects = _repository.GetAll();

            Assert.IsNotNull(projects);
            Assert.AreEqual(1, projects.Count);
            Assert.True(projects.Exists(p => p.Name == TestName));
            Assert.True(projects.Exists(p => p.Identify == TestIdentify));
        }

        [Test]
        public void Should_add_project()
        {
            var project = CreateProject();

            _repository.Add(project);

            var projects = _projectQuery.Where(p => p.Name == TestName).ToList();
            Assert.GreaterOrEqual(projects.Count, 1);
            Assert.AreEqual(projects[0].Identify, TestIdentify);
        }

        [Test]
        public void Should_return_project_by_id()
        {
            var expected = CreateProject();
            expected.Save();

            var id = expected.Oid.ToString();
            var project = _repository.FindById(id);

            Assert.AreEqual(expected, project);
        }

        [Test]
        public void Should_update_project()
        {
            var project = CreateProject();
            project.Save();
            const string changedname = "changedName";
            project.Name = changedname;

            _repository.Update(project);

            var changedProject = _projectQuery.SingleOrDefault(p => p.Oid == project.Oid);
            Assert.AreEqual(1, _projectQuery.Count());
            Assert.AreEqual(changedname, changedProject.Name);
            Assert.AreEqual(project.Identify, changedProject.Identify);
        }

        [Test]
        public void Should_delete_project()
        {
            var project = CreateProject();
            project.Save();

            _repository.Delete(project.Oid.ToString());

            Assert.False(_projectQuery.ToList().Exists(p => p.Oid == project.Oid));
        }

        private static Project CreateProject()
        {
            return new Project(Session.DefaultSession)
            {
                Name = TestName,
                Identify = TestIdentify,
                Start = DateTime.Today,
                End = DateTime.Today
            };
        }
    }
}