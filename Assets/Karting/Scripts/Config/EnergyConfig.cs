using UnityEngine;

namespace Karting.Config
{
    [CreateAssetMenu(menuName = "KartGame/Energy Config")]
    public class EnergyConfig : ScriptableObject
    {
        public int MaxEnergy = 100;
        public int EnergyRefillRateMs = 90 * 1000;
        public int EnergyRefillAmount = 1;
        public int RaceEnergyCost = 20;
    }
}