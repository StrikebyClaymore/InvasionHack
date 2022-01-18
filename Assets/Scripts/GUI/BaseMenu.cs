using System;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public abstract class BaseMenu : MonoBehaviour
    {
        [HideInInspector] public RootMenu root;

        public void Open()
        {
            if (!root.gameManager.isPaused)
                root.gameManager.SetPause();
            gameObject.SetActive(true);
        }

        public void Close()
        {
            if (!root.AnyMenuIsActive(this))
                root.gameManager.SetPause();
            gameObject.SetActive(false);
        }
    }
}
