using System;

namespace VirusSurvival.Engine
{
    public interface IGameEntity
    {
        InfectedState State { get; }
        Boolean Infected { get; }
        void SpreadInfection(IGameEntity from);
    }
}
