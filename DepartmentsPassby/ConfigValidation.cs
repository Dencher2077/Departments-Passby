using DepartmentsPassby.Models;

namespace DepartmentsPassby
{
    public class ConfigValidation
    {
        public static string Validate(DepartmentsManager departmentsManager)
        {
            foreach (var department in departmentsManager.Departments)
            {
                Rule rule = department.Rule;
                
                if (rule.Type is not ("conditional" or "unconditional"))
                    return $"Type is not 'conditional' or 'unconditional' in '{department.Title}' department";

                if (rule.Action is not ("put" or "delete" or "goto"))
                    return $"Action is not 'put', 'delete' or 'goto' in '{department.Title}' department";

                if (rule.Type is "conditional" && (rule.ElseAction is null || rule.ElseParam is null) )
                    return $"'ElseAction' or 'ElseParam' is null in conditional rule in '{department.Title}' department";

                if (rule.Type is "unconditional" && (rule.ElseAction is not null || rule.ElseParam is not null) )
                    return $"'ElseAction' or 'ElseParam' is not null in unconditional rule in '{department.Title}' department";

                if (rule.Action is "goto" && !departmentsManager.DepartmentsMapper.ContainsKey(rule.Param))
                    return $"'Goto param isn't valid in '{department.Title}' department";

                if (
                    rule.Type is "conditional" &&
                    rule.Action is "goto" &&
                    !departmentsManager.DepartmentsMapper.ContainsKey(rule.ElseParam)
                )
                {
                    return $"'Goto param isn't valid in else case in '{department.Title}' department";
                }
            }
            
            return "OK";
        }
    }
}