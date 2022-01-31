using System;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject main;
        [SerializeField] private GameObject levels;

        private void Awake()
        {
            if(!GameData.Loaded)
                SaveManager.LoadGame();
            OpenLevels();
        }

        private void OpenLevels()
        {
            foreach (var i in GameData.LevelsCompleted)
            {
                levels.transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
        }
        
        public void OnStartPressed()
        {
            main.SetActive(false);
            levels.SetActive(true);
        }
        
        public void OnLevelPressed(int level)
        {
            GameData.CurrentLevel = level;
            SceneManager.LoadScene("Level");
        }
        
        public void OnBackPressed()
        {
            main.SetActive(true);
            levels.SetActive(false);
        }

        private void OnApplicationQuit()
        {
            SaveManager.SaveGame();
        }
    }
}
