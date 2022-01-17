﻿using System;
using Assets.Scripts.GUI;
using Assets.Scripts.Mobs.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static MobsManager MobsManager;
        public static ProjectilesManager ProjectilesManager;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private ClearLevelMenu clearLevelMenu;

        public static Player Player;

        private void Awake()
        {
            MobsManager = transform.Find("Mobs").GetComponent<MobsManager>();
            ProjectilesManager = transform.Find("Projectiles").GetComponent<ProjectilesManager>();
            Player = transform.Find("Player").GetComponent<Player>();
        }

        public void SetPause(bool pause)
        {
            if (pause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1f;
        }

        public void OnPausePressed()
        {
            pauseMenu.Open();
        }

        public void LevelComplete()
        {
            clearLevelMenu.Open();
        }
    }
}
