﻿using System;
using UnityEngine;
using Assets.Scripts.Factory;
using Assets.Scripts.Mobs.Enemies;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class MobsManager : MonoBehaviour
    {
        
        [SerializeField]
        private EnemyFactory enemyFactory = default;
        [SerializeField, Range(0.1f, 10f)]
        float spawnSpeed = 1f;
        private float _spawnProgress;

        private void Awake()
        {
            enemyFactory.transform = transform;
        }

        private void Update()
        {
            _spawnProgress += spawnSpeed * Time.deltaTime;
            if (_spawnProgress >= 1f)
            {
                _spawnProgress = 0;
                SpawnEnemy();
            }
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void SpawnEnemy()
        {
            var spawnPoint = new Vector3(Random.Range(-5, 5), 0.0f, Random.Range(-5, 5));
            int dice = Random.Range(0, 2);
            Enemy enemy = enemyFactory.Get(dice);//EnemyFactory.Enemies.Base
            enemy.Spawn(spawnPoint);
        }
        
        private void SpawnEnemy(EnemyFactory.Enemies type, Vector3 pos)
        {
            Enemy enemy = enemyFactory.Get(type); // EnemyFactory.Enemies.Base
            enemy.Spawn(pos);
        }
    }
}
