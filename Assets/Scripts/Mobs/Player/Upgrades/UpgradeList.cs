using UnityEngine;

namespace Assets.Scripts.Mobs.Player.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeList", order = 51)]
    public class UpgradeList : ScriptableObject
    {
        public UpgradeConfig[] List;
    }
}
