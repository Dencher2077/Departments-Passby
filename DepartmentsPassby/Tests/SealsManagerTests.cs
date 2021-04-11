using NUnit.Framework;

namespace DepartmentsPassby.Tests
{
    [TestFixture]
    public class SealsManagerTests
    {
        [TestCase]
        public void Init()
        {
            SealsManager m = new SealsManager();
            Assert.AreEqual(0, m.Seals.Count);
            Assert.AreEqual(0, m.SealsSnapshots.Count);
        }
        
        [TestCase]
        public void PutSeal()
        {
            SealsManager m = new SealsManager();
            Assert.AreEqual(0, m.Seals.Count);
            
            m.PutSeal("F");
            Assert.AreEqual("F", m.Seals[0]);
        }
        
        [TestCase]
        public void DeeteSeal()
        {
            SealsManager m = new SealsManager();
            
            m.PutSeal("F");
            Assert.AreEqual("F", m.Seals[0]);
            
            m.DeleteSeal("F");
            Assert.AreEqual(0, m.Seals.Count);
        }

        [TestCase]
        public void GetSealsSum()
        {
            SealsManager m = new SealsManager();
            m.PutSeal("A");
            m.PutSeal("B");
            m.PutSeal("F");
            
            Assert.AreEqual("ABF", m.GetSealsSum());
        }
        
        [TestCase]
        public void MakeSealsSnapshot()
        {
            SealsManager m = new SealsManager();
            m.PutSeal("A");
            m.PutSeal("B");
            m.PutSeal("F");
            
            Assert.AreEqual(0, m.SealsSnapshots.Count);
            
            m.MakeSealsSnapshot();
            
            Assert.AreEqual("B", m.SealsSnapshots[0][1]);
        }
        
    }
}