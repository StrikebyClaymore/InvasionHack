using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [CreateAssetMenu(fileName = "LevelEnemies", menuName = "LevelEnemies", order = 51)]
    public class LevelEnemies : ScriptableObject
    {
        public List<EnemiesWave> waves;
    }
}
