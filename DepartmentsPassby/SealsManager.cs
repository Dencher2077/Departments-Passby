using System.Collections.Generic;
using System.Text;

namespace DepartmentsPassby
{
    /*
        Этот замечательный класс отвечает за работу с печатями и списком снапшотов печатей.
        Снашоп печатей это состояние печатей на момент выхода из целевого отдела, а по факту
        список списков печатей.
     */
    public class SealsManager
    {
        public List<string> Seals { get; } = new();
        
        public  List<List<string>> SealsSnapshots { get; } = new();
        
        public void PutSeal(string seal)
        {
            if (!Seals.Contains(seal))
                Seals.Add(seal);
        }

        public void DeleteSeal(string seal)
        {
            if (Seals.Contains(seal))
                Seals.Remove(seal);
        }

        // Cуммирует все печати ( нужно для определения бесконечного цикла )
        public string GetSealsSum()
        {
            StringBuilder sum = new StringBuilder();
            foreach (var seal in Seals)
            {
                sum.Append(seal);
            }
            return sum.ToString();
        }

        public void MakeSealsSnapshot()
        {
            SealsSnapshots.Add(new List<string>(Seals));
        }
        
    }
}