using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class ClearLevelMenu : BaseMenu
    {
        [SerializeField] private Text grade;
        [SerializeField] private Text cash;
        
        public void OnNextPressed()
        {
            
        }

        public void OnUpgradePressed()
        {
            
        }
        
        public void Open(int c)
        {
            base.Open();
            cash.text = $"Cash: {c.ToString()}$";
        }
    }
}
