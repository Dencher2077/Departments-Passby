using System.Collections.Generic;
using System.Text;

namespace DepartmentsPassby
{
    public class SealsManager
    {
        public List<string> Seals { get; } = new();
        
        public static List<List<string>> SealsSnapshots { get; } = new();
        
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