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
            var list = new[] {upgradeList.attackPower, upgradeList.attackSpeed, upgradeList.moveSpeed, upgradeList.health, upgradeList.doubleShot};
            for (int i = 0; i < list.Length; i++)
            {
                var upgrade = list[i];
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
            var data = new[] {GameData.AttackPower, GameData.AttackSpeed, GameData.MoveSpeed, GameData.Health, GameData.DoubleShot};
            var list = new[] {upgradeList.attackPower, upgradeList.attackSpeed, upgradeList.moveSpeed, upgradeList.health, upgradeList.doubleShot};
            var maxGrade = list[row].cost.Length;
            var nextGrade = data[row] + 1;

            if (nextGrade > maxGrade)
                return;

            var cost = list[row].cost[nextGrade - 1];
            if(GameData.CashCollected < cost)
                return;
            GameData.CashCollected -= cost;
            cashText.text = "Cash: " + GameData.CashCollected + "$";
            
            if (nextGrade == maxGrade)
                UpdateButton(row, nextGrade, 0, true);
            else
                UpdateButton(row, nextGrade, list[row].cost[nextGrade]);   
            
            data[row] = nextGrade;
            SetData(data);
            GameManager.Player.ApplyUpgrades(upgradeList);
        }

        private void SetData(int[] data)
        {
            GameData.AttackPower = data[0];
            GameData.AttackSpeed = data[1];
            GameData.MoveSpeed = data[2];
            GameData.Health = data[3];
            GameData.DoubleShot = data[4];
        }
        
        public void OnBackPressed()
        {
            Close();
            root.OpenMenu(RootMenu.MenuType.EndLevel);
        }

        public override void Open()
        {
            base.Open();
            cashText.text = "Cash: " + GameData.CashCollected + "$";
        }
    }
}
