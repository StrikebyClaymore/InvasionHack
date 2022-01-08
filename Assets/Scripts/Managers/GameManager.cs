using System;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static MobsManager MobsManager;
        public static ProjectilesManager ProjectilesManager;

        private void Awake()
        {
            MobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
        }
    }
}
