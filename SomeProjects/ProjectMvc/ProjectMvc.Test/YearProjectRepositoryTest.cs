using DevExpress.Xpo;
using NUnit.Framework;
using ProjectMvc.Models;
using ProjectXAF.Module;
using System.Linq;

namespace ProjectMvc.Test
{
    [TestFixture]
    public class YearProjectRepositoryTest
    {
        [TearDown]
        public void Cleanup()
        {
            var yearProjects = new XPQuery<YearProject>(Session.DefaultSession);
            yearProjects.ForEach(y => y.Delete());

            var projects = new XPQuery<Project>(Session.DefaultSession);
            projects.ForEach(p => p.Delete());
        }

        [Test]
        public void Should_return_its_all_year_projects_given_project_code()
        {
            const string projectCode = "testCode";
            const string testyearcode1 = "testYearCode1";
            const string testyearcode2 = "testYearCode2";

            var project = new Project {Code = projectCode};
            project.Save();

            InsertYearProject(project, testyearcode1);
            InsertYearProject(project, testyearcode2);

            var repository = new YearProjectRepository();
            var yearProjects = repository.GetYearProjects(projectCode);

            Assert.AreEqual(2, yearProjects.Count);
            yearProjects = yearProjects.OrderBy(y => y.Code).ToList();
            Assert.AreEqual(testyearcode1, yearProjects[0].Code);
            Assert.AreEqual(testyearcode2, yearProjects[1].Code);
        }

        private static void InsertYearProject(Project project, string code)
        {
            var yearProject1 = new YearProject {Code = code, Project = project};
            yearProject1.Save();
        }
    }
}
