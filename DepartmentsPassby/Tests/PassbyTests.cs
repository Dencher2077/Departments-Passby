using System.Collections.Generic;
using NUnit.Framework;

namespace DepartmentsPassby.Tests
{
    [TestFixture]
    public class PassbyTests
    {
 
        private static readonly object[] SourceLists1 = 
        {
            new object[] 
            {
                "config1.json",
                "Department 3", 
                new List<List<string>>
                {
                    new() {"A", "B"},
                    new() {"A", "B", "C"}
                },
                new List<string>() { "Infinite loop detected" }
            },
            
            new object[] 
            {
                "config2.json",
                "Department 2", 
                new List<List<string>>(),
                new List<string>()
                {
                    "Infinite loop detected",
                    "There was no entrance to the target department"
                }
            }
        };


        [TestCaseSource(nameof(SourceLists1))]
        public void Start(string configPath, string targetDepartmentName, List<List<string>> expectedSeals, List<string> expectedMessages)
        {
            PassbyResult result = new Passby(configPath).Start(targetDepartmentName);
            
            Assert.AreEqual(expectedSeals, result.SealsSnapshots);
            Assert.AreEqual(expectedMessages, result.Messages);
        }
    }
}