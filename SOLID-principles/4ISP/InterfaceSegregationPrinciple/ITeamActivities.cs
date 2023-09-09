

namespace InterfaceSegregationPrinciple
{

    // All function are in here, so this is not maintainable and is iun violation of the 4ISP
    interface ITeamActivities
    {
        void Plan();
        void Comunicate();
        void Design();
        void Develop();
        void Test();
    }
}