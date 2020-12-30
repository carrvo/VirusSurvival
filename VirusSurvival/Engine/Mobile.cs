using System;

namespace VirusSurvival.Engine
{
    public abstract class Mobile : BaseEntity, IMobileEntity
    {
        public Int32 SanatizingSteps { get; protected set; }

        public override InfectedState State
        {
            get
            {
                if (SanatizingSteps > 0)
                {
                    return InfectedState.Sanatizer;
                }
                else
                {
                    return _state;
                }
            }
            set
            {
                if (_state != InfectedState.Immune && _state != InfectedState.Sanatizer)
                {
                    _state = value;
                }
            }
        }

        public virtual void TakeStep(IBoard context)
        {
            SanatizingSteps--;
        }
    }
}
