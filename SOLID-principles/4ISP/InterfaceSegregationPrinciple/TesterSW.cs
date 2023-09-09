using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class TesterSW : ITesterTasks
    {
        public void TestSoftware()
        {
            throw new NotImplementedException();
        }

        void IBackendDevTasks.CreateAPI()
        {
            throw new NotImplementedException();
        }

        void IBackendDevTasks.MaintainAPI()
        {
            throw new NotImplementedException();
        }

        void ITesterTasks.TestSoftware()
        {
            throw new NotImplementedException();
        }
    }
}