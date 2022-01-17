using System;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class RootMenu : MonoBehaviour
    {
        private GameManager _gameManager;
        [Header("Menus")]
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private ClearLevelMenu clearLevelMenu;
        [SerializeField] private RestartMenu restartMenu;
        [Header("")]
        [SerializeField] private GameObject backgroundPanel;

        private BaseMenu _currentMenu;
        
        private void Start()
        {
            pauseMenu.root = this;
            clearLevelMenu.root = this;
            restartMenu.root = this;
        }

        public void OnPausePressed()
        {
            // жмём кнопку паузу, появляется меню паузы
            // появялется поверх всех остальных менюшек
            // если открыта какая-то менюшка и нажали паузу, то она сохраняется
            // при отжатии паузы происходит возвращение в прошлое меню или в игру
            if (!pauseMenu.isActiveAndEnabled)
                pauseMenu.Open();
            else
                pauseMenu.Close();
            
        }

        private void HideAllMenu()
        {
            
        }
    }
}
