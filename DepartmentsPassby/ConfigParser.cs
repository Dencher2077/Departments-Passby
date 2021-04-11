using System.IO;
using System.Text.Json;
using DepartmentsPassby.Models;

namespace DepartmentsPassby
{
    public class ConfigParser
    {
        private record DepartmentsList(Department[] Departments);
        
        public static DepartmentsManager Parse(string configPath)
        {
            string jsonConfig = File.ReadAllText(configPath);
            Department[] departments = JsonSerializer.Deserialize<DepartmentsList>(jsonConfig).Departments;
            return new DepartmentsManager(departments);
        }
    }
}