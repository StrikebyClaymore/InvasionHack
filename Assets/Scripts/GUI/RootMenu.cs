using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class RootMenu : MonoBehaviour
    {
        public GameManager gameManager;
        [Header("Menus")]
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private RestartMenu restartMenu;
        [SerializeField] private ClearLevelMenu clearLevelMenu;
        public enum MenuType
        {
            Pause,
            Restart,
            ClearLevel
        }

        private void Start()
        {
            pauseMenu.root = this;
            clearLevelMenu.root = this;
            restartMenu.root = this;
        }

        public bool AnyMenuIsActive(BaseMenu menu)
        {
            var list = new List<BaseMenu>{ pauseMenu, restartMenu, clearLevelMenu };
            return list.Any(m => m.isActiveAndEnabled && m != menu);
        }
        
        public void OpenMenu(MenuType type)
        {
            switch (type)
            {
                case MenuType.Pause:
                    pauseMenu.Open();
                    break;
                case MenuType.Restart:
                    restartMenu.Open();
                    break;
                case MenuType.ClearLevel:
                    clearLevelMenu.Open();
                    break;
                default:
                    break;
            }
        }

        public void OnPausePressed()
        {
            if (!pauseMenu.isActiveAndEnabled)
                pauseMenu.Open();
            else
                pauseMenu.Close();
        }
    }
}
