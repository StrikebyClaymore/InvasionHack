using UnityEngine;

namespace Assets.Scripts.Mobs.Player.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeConfig", order = 51)]
    public class UpgradeConfig : ScriptableObject
    {
        public int[] cost;
        public float[] scale;
    }
}
