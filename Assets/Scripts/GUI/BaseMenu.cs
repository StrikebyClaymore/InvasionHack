using System;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public abstract class BaseMenu : MonoBehaviour
    {
        [HideInInspector] public RootMenu root;

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
