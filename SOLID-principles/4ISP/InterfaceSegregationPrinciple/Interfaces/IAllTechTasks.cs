namespace InterfaceSegregationPrinciple.Interfaces
{
    public interface IAllTechTasks : IBackendDevTasks, IFrontEndDevTasks, ITesterTasks, IProjectManagerTasks
    {

    }
}