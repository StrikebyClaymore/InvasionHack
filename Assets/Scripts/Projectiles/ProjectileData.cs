using Assets.Scripts.Factory;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "ProjectileData", order = 51)]
    public class ProjectileData: ScriptableObject
    {
        public GameObject prefab;
        public int attackPower;
        public int baseDamage;
        public float moveSpeed;
        public string[] ignoreCollisionTags;
        public ProjectileFactory.Projectiles type;
    }
}
