using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DepartmentsPassby.Models;

namespace DepartmentsPassby
{
    /*
     * Основной класс библиотеки.
     * Обходит отделы и выполняет спцифические
     * задачи согласно конфигурации из JSON файла
     */
    public class Passby
    {   
        private DepartmentsManager DepartmentsManager { get; }

        private SealsManager SealsManager { get; } = new();

        // Вторым аргументом можно отключить валидацию, но тогда могут сыпаться исключения при работе метода Start
        public Passby(string configPath, bool withValidation = true)
        {
            DepartmentsManager = ConfigParser.Parse(configPath);
            if (withValidation)
            {
                string msg = ConfigValidation.Validate(DepartmentsManager);
                if (msg != "OK") throw new Exception(msg);
            }
        }

        // Реализация алгоритма обхода отдело. Ну тут нужна целая документация
        public PassbyResult Start(string targetDepartmentName)
        {
            DepartmentsManager[targetDepartmentName].IsTarget = true;
            PassbyResult result = new PassbyResult();
            
            for (int i = 0; i < DepartmentsManager.Length; )
            {
                var department = DepartmentsManager[i];
                var rule = department.Rule;

                switch (rule.Type)
                {
                    case "unconditional": 
                        i = CallAction(i, rule.Action, rule.Param);
                        break;
                    case "conditional":
                        if (SealsManager.Seals.Contains(rule.ConditionalSeal)) 
                            i = CallAction(i, rule.Action, rule.Param);
                        else
                            i = CallAction(i, rule.ElseAction, rule.ElseParam);
                        break;
                }

                string curtentSealsSum = SealsManager.GetSealsSum();
                if (IsInfiniteLoop(curtentSealsSum, department.SealsSum))
                {
                    result.Messages.Add("Infinite loop detected");
                    break;
                }

                department.SealsSum = curtentSealsSum;
                if (department.IsTarget) SealsManager.MakeSealsSnapshot();
            }

            if(SealsManager.SealsSnapshots.Count < 1)
                result.Messages.Add("There was no entrance to the target department");

            result.SealsSnapshots = SealsManager.SealsSnapshots;
            return result;
        }
        
        //Выбирает какое дейстие выполнить исходя из конфига. Возращает индекс отдела для перехода
        private int CallAction(int index, string actionName, string param )
        {
            switch (actionName)
            {
                case "put": 
                    SealsManager.PutSeal(param);
                    return ++index;
                case "delete": 
                    SealsManager.DeleteSeal(param);
                    return ++index;
                case "goto":
                    return DepartmentsManager.IndexOf(param);
                default: return index;
            }
        }

        // Обнаруживает бесконечный цикл исходя из текущей суммы печатей
        // и суммы печатей текущего отдела
        private bool IsInfiniteLoop(string currentSealsSum, string departmentSealsSum)
        {
            if (departmentSealsSum == null) return false;
            if (departmentSealsSum == currentSealsSum) return true;
            return false;
        }
    }
}