using NUnit.Framework;
using CollectionsLib;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new EmployeeManager();
        }

        // Scenario 1: Ensure that there is no null value in the collection
        [Test]
        public void GetEmployees_NoNullValues_ClassicAndConstraintModel()
        {
            List<Employee> list = _manager.GetEmployees();

            // Classic Model
            CollectionAssert.AllItemsAreNotNull(list);

            // Constraint Model
            Assert.That(list, Is.All.Not.Null);
        }

        // Scenario 2: Verify whether the employee having his/her id 100 exists in the collection
        [Test]
        public void GetEmployees_EmployeeId100Exists_ClassicAndConstraintModel()
        {
            List<Employee> list = _manager.GetEmployees();

            // Classic Model
            bool exists = list.Any(x => x.EmpId == 100);
            Assert.IsTrue(exists);

            // Constraint Model (Using overridden Equals on Employee)
            var expectedEmployee = new Employee { EmpId = 100 };
            Assert.That(list, Contains.Item(expectedEmployee));
        }

        // Scenario 3: Check whether the GetEmployees function returns only unique employees
        [Test]
        public void GetEmployees_AllItemsAreUnique_ClassicAndConstraintModel()
        {
            List<Employee> list = _manager.GetEmployees();

            // Classic Model
            CollectionAssert.AllItemsAreUnique(list);

            // Constraint Model
            Assert.That(list, Is.Unique);
        }

        // Scenario 4: Both GetEmployees() and GetEmployeesWhoJoinedInPreviousYears() return same collection
        [Test]
        public void GetEmployees_CompareCollections_ClassicAndConstraintModel()
        {
            List<Employee> allEmployees = _manager.GetEmployees();
            List<Employee> joinedPrevious = _manager.GetEmployeesWhoJoinedInPreviousYears();

            // Classic Model
            CollectionAssert.AreEqual(allEmployees, joinedPrevious);

            // Constraint Model
            Assert.That(allEmployees, Is.EqualTo(joinedPrevious));
        }
    }
}
