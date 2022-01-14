using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [CreateAssetMenu(fileName = "EnemiesWave", menuName = "EnemiesWave", order = 51)]
    public class EnemiesWave : ScriptableObject
    {
        public List<int> enemies;
    }
}
