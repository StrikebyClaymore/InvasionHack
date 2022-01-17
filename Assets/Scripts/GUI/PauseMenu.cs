using System;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GUI
{
    public class PauseMenu: BaseMenu
    {
        public void OnContinuePressed()
        {
            Close();
        }
        
        public void OnToMenuPressed()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
