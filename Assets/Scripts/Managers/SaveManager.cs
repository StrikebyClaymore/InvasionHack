using UnityEngine;
using  System.IO;
using  System.Runtime.Serialization.Formatters.Binary;



namespace Assets.Scripts.Managers
{
    [System.Serializable]
    public class SaveData
    {
        public int currentLevel;
        public int levelsCompleted;
        public int cashCollected;
        public int attackPower;
        public int attackSpeed;
        public int moveSpeed;
        public int health;
        public int doubleShot;

        public SaveData()
        {
            currentLevel = GameData.CurrentLevel;
            levelsCompleted = GameData.LevelsCompleted.Count;
            cashCollected = GameData.CashCollected;
            attackPower = GameData.AttackPower;
            attackSpeed = GameData.AttackSpeed;
            moveSpeed = GameData.MoveSpeed;
            health = GameData.Health;
            doubleShot = GameData.DoubleShot;
        }

        public void LoadInGame()
        {
            GameData.CurrentLevel = currentLevel;
            for (int i = 0; i < levelsCompleted; i++)
                GameData.LevelsCompleted.Add(i);
            GameData.CashCollected = cashCollected;
            GameData.AttackPower = attackPower;
            GameData.AttackSpeed = attackSpeed;
            GameData.MoveSpeed = moveSpeed;
            GameData.Health = health;
            GameData.DoubleShot = doubleShot;
        }
    }
    
    public static class SaveManager
    {
        public static void SaveGame()
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/save.save";
            var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, new SaveData());
            stream.Close();
            Debug.Log(path);
        }

        public static void LoadGame()
        {
            var path = Application.persistentDataPath + "/save.save";
            if (!File.Exists(path))
                return;
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var saveData = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            saveData.LoadInGame();
            GameData.Loaded = true;
        }
    }
}