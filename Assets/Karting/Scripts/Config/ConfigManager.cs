using Karting.Utilities;
using UnityEngine;

namespace Karting.Config
{
    public class ConfigManager : PersistentSingleton<ConfigManager>
    {
        [SerializeField] private EnergyConfig _energyConfig;

        public EnergyConfig EnergyConfig { get { return _energyConfig; } }
    }
}