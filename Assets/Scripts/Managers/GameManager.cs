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
        [SerializeField] private GameObject playerControls;
        public static ProjectilesManager ProjectilesManager;
        public LevelData LevelData = new LevelData();
        public bool isPaused = false;
        private const float LevelCompleteWaitTime = 3f;

        private void Awake()
        {
            mobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
            Player = transform.Find("Player").GetComponent<Player>();
        }

        private void Start()
        {
            Time.timeScale = 1f;
        }

        public void AddCash(int cash)
        {
            LevelData.Cash += cash * 10;
        }

        public void WaitLevelComplete()
        {
            Invoke(nameof(LevelComplete), LevelCompleteWaitTime);
        }
        
        public void LevelComplete()
        {
            // Grade points
            // 1 point for no get hits or hp >= 80%
            // 1 point for time
            // 1 point for level complete
            LevelData.Grade += 1;
            LevelData.Grade += mobsManager.GetGrade();
            LevelData.Grade += Player.GetGrade();
            GameData.CashCollected += LevelData.Cash;
            rootMenu.OpenMenu(RootMenu.MenuType.EndLevel);
            LevelData.Grade = 0;
            LevelData.Cash = 0;
            ClearScene();
        }

        private void ClearScene()
        {
            for (var i = 0; i < ProjectilesManager.transform.childCount; i++)
            {
                Destroy(ProjectilesManager.transform.GetChild(i).gameObject);
            }
        }
        
        public void SetPause()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            Player.GetComponent<PlayerControl>().LockInput();
            playerControls.SetActive(!isPaused);
        }
        
    }
}
