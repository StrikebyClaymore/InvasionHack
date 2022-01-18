using System;
using System.Timers;
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
        public GameData gameData = new GameData();
        public LevelData levelData = new LevelData();
        public bool isPaused = false;

        private void Awake()
        {
            MobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
            Player = transform.Find("Player").GetComponent<Player>();
        }

        public void AddCash(int cash)
        {
            levelData.Cash += cash;
        }
        
        public void LevelComplete()
        {
            // Grade points
            // 1 point for no get hits or hp > 80%
            // 1 point for time
            // 1 point for level complete
            gameData.CashCollected += levelData.Cash;
            RootMenu.OpenMenu(RootMenu.MenuType.EndLevel);
        }

        public void SetPause()
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        
    }
}
