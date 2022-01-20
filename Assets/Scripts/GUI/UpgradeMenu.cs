using System;
using Assets.Scripts.Managers;
using Assets.Scripts.Mobs.Player.Upgrades;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GUI
{
    public class UpgradeMenu : BaseMenu
    {
        [SerializeField] private UpgradeList upgradeList;
        [SerializeField] private GameObject upgradesBox;
        [SerializeField] private Text cashText;
        [SerializeField] private Color upgradeColor;

        private void Start()
        {
            for (int i = 0; i < upgradeList.List.Length; i++)
            {
                var upgrade = upgradeList.List[i];
                UpdateCost(i, upgrade.cost[0]);
            }
        }

        private void UpdateButton(int child, int grade, int cost, bool max = false)
        {
            var button = upgradesBox.transform.GetChild(child);
            var gradeObj = button.Find(grade.ToString()).GetComponent<Image>();
            gradeObj.color = upgradeColor;
            var textObj = button.Find("Cost").GetComponent<Text>();
            textObj.text = max ? textObj.text = "MAX" : "Cost: " + cost + "$";
        }

        private void UpdateGrade(int child, int grade)
        {
            var button = upgradesBox.transform.GetChild(child);
            var gradeObj = button.Find(grade.ToString()).GetComponent<Image>();
            gradeObj.color = upgradeColor;
        }

        private void UpdateCost(int child, int cost, bool max = false)
        {
            var button = upgradesBox.transform.GetChild(child);
            var textObj = button.Find("Cost").GetComponent<Text>();
            textObj.text = max ? textObj.text = "MAX" : "Cost: " + cost + "$";
        }
        
        public void OnUpgradePressed(int row)
        {
            var gd = root.gameManager.GameData;
            var data = new[] {gd.AttackPower, gd.AttackSpeed, gd.MoveSpeed, gd.Health, gd.DoubleShot};
            var maxGrade = upgradeList.List[row].cost.Length;
            var nextGrade = data[row] + 1;

            if (nextGrade > maxGrade)
                return;

            var cost = upgradeList.List[row].cost[nextGrade - 1];
            if(gd.CashCollected < cost)
                return;
            gd.CashCollected -= cost;
            cashText.text = "Cash: " + gd.CashCollected + "$";
            
            if (nextGrade == maxGrade)
                UpdateButton(row, nextGrade, 0, true);
            else
                UpdateButton(row, nextGrade, upgradeList.List[row].cost[nextGrade]);   
            
            data[row] = nextGrade;
            SetData(data);
            GameManager.Player.ApplyUpgrades(gd);
        }

        private void SetData(int[] data)
        {
            var gd = root.gameManager.GameData;
            gd.AttackPower = data[0];
            gd.AttackSpeed = data[1];
            gd.MoveSpeed = data[2];
            gd.Health = data[3];
            gd.DoubleShot = data[4];
        }
        
        public void OnBackPressed()
        {
            Close();
            root.OpenMenu(RootMenu.MenuType.EndLevel);
        }

        public override void Open()
        {
            base.Open();
            cashText.text = "Cash: " + root.gameManager.GameData.CashCollected + "$";
        }
    }
}
