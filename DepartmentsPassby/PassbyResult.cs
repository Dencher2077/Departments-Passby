using System.Collections.Generic;

namespace DepartmentsPassby
{
    public class PassbyResult
    {
        public List<List<string>> SealsSnapshots { get; set; }

        public List<string> Messages { get; } = new();
    }
}