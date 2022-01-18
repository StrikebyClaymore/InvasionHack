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
        }

        public void OnUpgradePressed()
        {
            root.OpenMenu(RootMenu.MenuType.Upgrade);
        }

        public void OnRestartPressed()
        {
            SceneManager.LoadScene("Level");
        }
        
        public override void Open()
        {
            base.Open();
            var c = root.gameManager.LevelData.Cash;
            cash.text = $"Cash: {c.ToString()}$";
        }
    }
}
