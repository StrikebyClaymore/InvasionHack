using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GUI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager; 
        
        public void OnStartPressed()
        {
            SceneManager.LoadScene("Level");
        }
        
    }
}
