using System.Text.Json.Serialization;

namespace DepartmentsPassby.Models
{
    public class Department
    {
        public string Title { get; set; }

        public Rule Rule { get; set; }

        [JsonIgnore]
        public string SealsSum { get; set; }

        [JsonIgnore]
        public bool IsTarget { get; set; }
    }
}