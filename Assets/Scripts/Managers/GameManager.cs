using System;
using Assets.Scripts.GUI;
using Assets.Scripts.Mobs.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static Player Player;
        public static MobsManager MobsManager;
        public static RootMenu RootMenu;
        public static ProjectilesManager ProjectilesManager;
        [SerializeField] private GameData gameData;
        private BaseMenu _currentMenu;
        public bool isPaused = false;

        private void Awake()
        {
            MobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
            Player = transform.Find("Player").GetComponent<Player>();
        }

        public void AddCash(int cash)
        {
            gameData.cashCollected += cash;
        }
        
        public void LevelComplete()
        {
            //clearLevelMenu.Open();
        }
        
    }
}
