namespace InterfaceSegregationPrinciple
{
    // instead of implementing all these methods, a few more interfaces can be created, by segregating, so it's violating the 4ISP
    // so thise will be commented and new interfaces will be created and new classes
    public class BackendDev : ITeamActivities
    {
        void ITeamActivities.Plan()
        {
            throw new NotImplementedException();
        }

        void ITeamActivities.Comunicate()
        {
            throw new NotImplementedException();
        }

        void ITeamActivities.Design()
        {
            throw new NotImplementedException();
        }

        void ITeamActivities.Develop()
        {
            throw new NotImplementedException();
        }

        void ITeamActivities.Test()
        {
            throw new NotImplementedException();
        }
    }
}