using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class EndLevelMenu : BaseMenu
    {
        [SerializeField] private Text grade;
        [SerializeField] private Text cash;
        
        public void OnNextPressed()
        {
            Close();
            root.gameManager.mobsManager.SetNextLevel();
        }

        public void OnUpgradePressed()
        {
            root.OpenMenu(RootMenu.MenuType.Upgrade);
        }

        public void OnRestartPressed()
        {
            Close();
            SceneManager.LoadScene("Level");
        }
        
        public override void Open()
        {
            base.Open();
            var c = root.gameManager.LevelData.Cash;
            var d = root.gameManager.LevelData.Grade;
            grade.text = $"Grade: {d.ToString()}/3";
            cash.text = $"Cash: {c.ToString()}$";
        }
    }
}
