using System;

namespace DepartmentsPassby.Models
{
    public class Rule
    {
        private string _type;

        public string Type
        {
            get => _type;
            set
            {
                if (value is "conditional" or "unconditional")
                    _type = value;
                else
                    throw new ArgumentException("Type must be 'conditional' or 'unconditional'");
            }
        }
        
        private string _action;
        public string Action
        {
            get => _action;
            set
            {
                if (value is "put" or "delete" or "goto")
                    _action = value;
                else
                    throw new ArgumentException("Action must be 'put', 'delete' or 'goto'");
            }
        }

        public string ConditionalPrint { get; set; }
        
        public string Param { get; set; }

        public string ElseAction { get; set; }

        public string ElseParam { get; set; }
        
    }
}