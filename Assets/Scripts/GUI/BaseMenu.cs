using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public abstract class BaseMenu : MonoBehaviour
    {
        private GameManager _gameManager;
    
        protected virtual void Awake()
        {
            _gameManager = transform.root.GetComponent<GameManager>();
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
            _gameManager.SetPause(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
            _gameManager.SetPause(false);
        }
    }
}
