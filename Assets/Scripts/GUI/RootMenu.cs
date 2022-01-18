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
        [SerializeField] private EndLevelMenu endLevelMenu;
        public enum MenuType
        {
            Pause,
            EndLevel
        }

        private void Start()
        {
            pauseMenu.root = this;
            endLevelMenu.root = this;
        }

        public bool AnyMenuIsActive(BaseMenu menu)
        {
            var list = new List<BaseMenu>{ pauseMenu, endLevelMenu };
            return list.Any(m => m.isActiveAndEnabled && m != menu);
        }
        
        public void OpenMenu(MenuType type)
        {
            switch (type)
            {
                case MenuType.Pause:
                    pauseMenu.Open();
                    break;
                case MenuType.EndLevel:
                    endLevelMenu.Open();
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
