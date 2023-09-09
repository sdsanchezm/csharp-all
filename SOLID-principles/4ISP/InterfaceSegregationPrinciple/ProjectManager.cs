using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple
{
    public class ProjectManager : IProjectManagerTasks
    {
        public void Communicate()
        {
            throw new NotImplementedException();
        }

        public void Plan()
        {
            throw new NotImplementedException();
        }
    }

    public class Architect : ITesterTasks, IBackendDevTasks, IFrontEndDevTasks, IProjectManagerTasks
    {
        public void Communicate()
        {
            throw new NotImplementedException();
        }

        public void CreateAPI()
        {
            throw new NotImplementedException();
        }

        public void CreateUI()
        {
            throw new NotImplementedException();
        }

        public void MainteinAPI()
        {
            throw new NotImplementedException();
        }

        public void Plan()
        {
            throw new NotImplementedException();
        }

        public void TestSoftware()
        {
            throw new NotImplementedException();
        }
    }
}