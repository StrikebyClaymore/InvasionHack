using System;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GUI
{
    public class PauseMenu: MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            Close();
        }

        public void OnContinuePressed()
        {
            Close();
        }
        
        public void OnToMenuPressed()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Open()
        {
            gameObject.SetActive(true);
            gameManager.SetPause(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
            gameManager.SetPause(false);
        }
        
    }
}
