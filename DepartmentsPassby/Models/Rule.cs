using System;

namespace DepartmentsPassby.Models
{
    public class Rule
    {
        public string Type { get; set; }
        public string Action { get; set; }

        public string ConditionalSeal { get; set; }
        
        public string Param { get; set; }

        public string ElseAction { get; set; }

        public string ElseParam { get; set; }
        
    }
}