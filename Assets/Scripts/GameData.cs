using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameData
    {
        public static int CurrentLevel;
        public static HashSet<int> LevelsCompleted = new HashSet<int>{0};
        
        public static int CashCollected;

        public static int AttackPower = 0;
        public static int AttackSpeed = 0;
        public static int MoveSpeed = 0;
        public static int Health = 0;
        public static int DoubleShot = 0;
    }
}
