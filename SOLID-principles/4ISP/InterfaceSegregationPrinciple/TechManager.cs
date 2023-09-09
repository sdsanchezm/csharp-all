using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class TechManager : IAllTechTasks
    {
        void IProjectManagerTasks.Communicate()
        {
            throw new NotImplementedException();
        }

        void IBackendDevTasks.CreateAPI()
        {
            throw new NotImplementedException();
        }

        void IFrontEndDevTasks.CreateUI()
        {
            throw new NotImplementedException();
        }

        void IBackendDevTasks.MaintainAPI()
        {
            throw new NotImplementedException();
        }

        void IProjectManagerTasks.Plan()
        {
            throw new NotImplementedException();
        }

        void ITesterTasks.TestSoftware()
        {
            throw new NotImplementedException();
        }
    }
}