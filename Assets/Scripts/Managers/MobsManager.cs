using System;
using System.Timers;
using UnityEngine;
using Assets.Scripts.Factory;
using Assets.Scripts.LevelDesign;
using Assets.Scripts.Mobs.Enemies;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class MobsManager : MonoBehaviour
    {
        private GameManager _gameManager;
        [SerializeField] private EnemyFactory enemyFactory = default;
        [SerializeField] private LevelEnemies[] levelEnemies;
        //[SerializeField, Range(0.1f, 10f)] private float spawnSpeed = 1f;
        private float _spawnProgress;

        public int currentLevel = 0;
        private int _currentWave = 0;
        private int _currentWaveEnemiesCount;

        private Timer _gradeTimer;
        
        private void Awake()
        {
            _gameManager = transform.root.GetComponent<GameManager>();
            enemyFactory.transform = transform;
            currentLevel = GameData.CurrentLevel;

            _gradeTimer = new Timer(levelEnemies[currentLevel].gradeLevelTime * 1000) {AutoReset = false};
        }

        private void Start()
        {
            SpawnWave();
        }

        private void Update()
        {
            /*if (Input.GetButtonDown("Jump"))
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var e = transform.GetChild(i).GetComponent<Enemy>();
                    e.GetHit(200);
                }
            }*/
            /*_spawnProgress += spawnSpeed * Time.deltaTime;
            if (_spawnProgress >= 1f)
            {
                _spawnProgress = 0;
                SpawnEnemy();
            }*/
        }

        public void SetNextLevel()
        {
            try
            {
               currentLevel++;
               SpawnWave();
            }
            catch
            {
                // ignored
            }
        }
        
        private void SpawnWave()
        {
            var waveEnemies = levelEnemies[currentLevel].waves[_currentWave].enemies;
            _currentWaveEnemiesCount = waveEnemies.Count;
            for (int i = 0; i < waveEnemies.Count; i++)
            {
                SpawnEnemy(waveEnemies[i]);
            }
            _gradeTimer.Start();
        }

        public void UpdateEnemiesCounter(int cash)
        {
            _currentWaveEnemiesCount--;
            _gameManager.AddCash(cash);
            if (_currentWave == levelEnemies[currentLevel].waves.Count - 1 && _currentWaveEnemiesCount == 0)
            {
                _gameManager.WaitLevelComplete();
                return;
            }
            if (_currentWaveEnemiesCount == 0)
            {
                _currentWave++;
                SpawnWave();
            }
        }
        
        private void SpawnEnemy(int type)
        {
            var spawnPoint = new Vector3();

            if (Random.Range(0, 2) == 0)
            {
                if (Random.Range(0, 2) == 0)
                    spawnPoint.x = -14.0f;
                else
                    spawnPoint.x = 14.0f;
                spawnPoint.z = Random.Range(-14, 15);
            }
            else
            {
                if (Random.Range(0, 3) == 0)
                    spawnPoint.z = -14;
                else
                    spawnPoint.z = 14;
                spawnPoint.x = Random.Range(-14, 15);
            }
            
            Enemy enemy = enemyFactory.Get(type);
            enemy.Spawn(spawnPoint);
        }

        private void SpawnEnemy(EnemyFactory.Enemies type, Vector3 pos)
        {
            Enemy enemy = enemyFactory.Get(type); // EnemyFactory.Enemies.Base
            enemy.Spawn(pos);
        }

        public int GetGrade() => _gradeTimer.Enabled ? 1 : 0;
    }
}
