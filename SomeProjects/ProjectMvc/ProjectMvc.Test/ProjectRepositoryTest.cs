using System.Diagnostics;
using System.Linq;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Npgsql;
using NUnit.Framework;
using ProjectMvc.Models;
using ProjectXAF.Module;

namespace ProjectMvc.Test
{
    [TestFixture]
    public class ProjectRepositoryTest
    {
        private const string TestCode = "testCode";
        private const string TestTitle = "testTitle";
        private readonly XPQuery<Project> _xpQuery;
        private readonly ProjectRepository _projectRepository;

        public ProjectRepositoryTest()
        {
            EditModelPermission.AlwaysGranted = Debugger.IsAttached;
            const string connectionString = "Server=localhost; User Id=postgres;Password=postgres;Database=ProjectXAF_UnitTest;Encoding=UNICODE;";
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                new NpgsqlConnection(connectionString),
                AutoCreateOption.DatabaseAndSchema);

            _xpQuery = new XPQuery<Project>(Session.DefaultSession);
            _projectRepository = new ProjectRepository();
        }

        [SetUp]
        public void Init()
        {
            var project = new Project { Code = TestCode, Title = TestTitle };
            project.Save();
        }

        [TearDown]
        public void Clearup()
        {
            foreach (Project project in _xpQuery)
            {
                project.Delete();
            }
        }

        [Test]
        public void Should_return_all_projects_in_database()
        {
            var projects = _projectRepository.GetAll();

            Assert.AreEqual(1, projects.Count);
            Assert.AreEqual(TestCode, projects.First().Code);
            Assert.AreEqual(TestTitle, projects.First().Title);
        }

        [Test]
        public void Should_return_project_given_code()
        {
            var project = _projectRepository.GetByCode(TestCode);

            Assert.AreEqual(TestCode, project.Code);
            Assert.AreEqual(TestTitle, project.Title);
        }

        [Test]
        public void Should_return_empty_gevin_unexist_project_code()
        {
            var project = _projectRepository.GetByCode("unexist_project_code");

            Assert.IsNull(project);
        }
    }
}
