using System;

namespace VirusSurvival.Engine
{
    public abstract class Square : IGameEntity
    {
        protected InfectedState _state;
        public virtual InfectedState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != InfectedState.Immune && _state != InfectedState.Sanatizer)
                {
                    _state = value;
                }
            }
        }

        public Boolean Infected { get; internal set; }

        public virtual void SpreadInfection(IGameEntity from)
        {
            if (State != InfectedState.Immune && State != InfectedState.Sanatizer)
            {
                Infected = other.Infected;
            }
            else
            {
                return;
            }

            if (other.State == InfectedState.Sanatizer)
            {
                Infected = false;
            }
        }
    }
}
