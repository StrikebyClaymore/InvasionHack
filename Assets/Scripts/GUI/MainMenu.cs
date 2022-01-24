using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GUI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject main;
        [SerializeField] private GameObject levels;

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
        
    }
}
