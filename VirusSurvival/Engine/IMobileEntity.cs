using System;

namespace VirusSurvival.Engine
{
    public interface IMobileEntity : IGameEntity
    {
        Int32 SanatizingSteps { get; }
        void TakeStep(IBoard context);
    }
}
