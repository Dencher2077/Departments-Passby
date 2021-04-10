using System.IO;
using System.Text.Json;
using DepartmentsPassby.Models;

namespace DepartmentsPassby
{
    public class ConfigParser
    {
        private record DepartmentsList(Department[] Departments);
        
        public static Department[] Parse(string configPath)
        {
            string jsonConfig = File.ReadAllText(configPath);
            return JsonSerializer.Deserialize<DepartmentsList>(jsonConfig)?.Departments;
        }
    }
}