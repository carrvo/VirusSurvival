using System;
using System.Collections;
using System.Collections.Generic;
using System.Random;

namespace VirusSurvival.Engine
{
    public static class InfectionLogic
    {
        private static IDictionary<(InfectedState, InfectedState), InfectedState> Mapping
        { get; } = new Dictionary<(InfectedState, InfectedState), InfectedState>()
        {
            {(InfectedState.Safe, InfectedState.Safe), InfectedState.Safe},
            {(InfectedState.Safe, InfectedState.Potential), InfectedState.Potential},
            {(InfectedState.Safe, InfectedState.Infected), InfectedState.Infected},
            {(InfectedState.Safe, InfectedState.Sanatizer), InfectedState.Safe},
            {(InfectedState.Safe, InfectedState.Immune), InfectedState.Safe},

            {(InfectedState.Potential, InfectedState.Safe), InfectedState.Potential},
            {(InfectedState.Potential, InfectedState.Potential), InfectedState.Potential},
            {(InfectedState.Potential, InfectedState.Infected), InfectedState.Infected},
            {(InfectedState.Potential, InfectedState.Sanatizer), InfectedState.Safe},
            {(InfectedState.Potential, InfectedState.Immune), InfectedState.Potential},

            {(InfectedState.Infected, InfectedState.Safe), InfectedState.Infected},
            {(InfectedState.Infected, InfectedState.Potential), InfectedState.Infected},
            {(InfectedState.Infected, InfectedState.Infected), InfectedState.Infected},
            {(InfectedState.Infected, InfectedState.Sanatizer), InfectedState.Safe},
            {(InfectedState.Infected, InfectedState.Immune), InfectedState.Infected},

            {(InfectedState.Sanatizer, InfectedState.Safe), InfectedState.Safe},
            {(InfectedState.Sanatizer, InfectedState.Potential), InfectedState.Safe},
            {(InfectedState.Sanatizer, InfectedState.Infected), InfectedState.Safe},
            {(InfectedState.Sanatizer, InfectedState.Sanatizer), InfectedState.Safe},
            {(InfectedState.Sanatizer, InfectedState.Immune), InfectedState.Safe},

            {(InfectedState.Immune, InfectedState.Safe), InfectedState.Safe},
            {(InfectedState.Immune, InfectedState.Potential), InfectedState.Safe},
            {(InfectedState.Immune, InfectedState.Infected), InfectedState.Safe},
            {(InfectedState.Immune, InfectedState.Sanatizer), InfectedState.Safe},
            {(InfectedState.Immune, InfectedState.Immune), InfectedState.Safe},
        };

        public static void CalculateInfection(this IMobileEntity mobile, IGameEntity stationary)
        {
            Mapping.TryGetValue((mobile.State, stationary.State), out InfectedState newState);
            mobile.State = newState;
            stationary.State = newState;
        }

        public static Boolean DieAtLevelEnd(this IPlayer mobile, Int32 tuningProbability = 10)
        {
            if (mobile.Infected)
            {
                return new Random().Next(tuningProbability) == 0;
            }
            else
            {
                return false;
            }
        }
    }
}
