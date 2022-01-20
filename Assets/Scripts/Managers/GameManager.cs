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
        public MobsManager mobsManager;
        public RootMenu rootMenu;
        public static ProjectilesManager ProjectilesManager;
        public GameData GameData = new GameData();
        public LevelData LevelData = new LevelData();
        public bool isPaused = false;

        private void Awake()
        {
            mobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
            Player = transform.Find("Player").GetComponent<Player>();
        }

        public void AddCash(int cash)
        {
            LevelData.Cash += cash * 10;
        }
        
        public void LevelComplete()
        {
            // Grade points
            // 1 point for no get hits or hp > 80%
            // 1 point for time
            // 1 point for level complete
            GameData.CashCollected += LevelData.Cash;
            rootMenu.OpenMenu(RootMenu.MenuType.EndLevel);
        }

        public void SetPause()
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                isPaused = false;
                Player.GetComponent<PlayerControl>().LockInput();
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
                Player.GetComponent<PlayerControl>().LockInput();
            }
        }
        
    }
}
