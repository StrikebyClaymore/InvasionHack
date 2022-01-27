using System;
using System.Timers;
using Assets.Scripts.Factory;
using Assets.Scripts.Managers;
using Assets.Scripts.Mobs.Player.Upgrades;
using Assets.Scripts.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Mobs.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        private Transform aim;
        [SerializeField]
        private ProjectileData projectileData;
        private bool _isFireOn = false;
        public bool IsFireOn
        {
            get => _isFireOn;
            set => _isFireOn = value;
        }
        private Timer _attackCooldownTimer;
        [SerializeField]
        private float attackCooldownTime = 1f;
        private bool _isAttackCooldown;
        private int _attackPower;

        [SerializeField] private Transform[] doubleShotAim;
        private bool _doubleShot;
        
        private void Awake()
        {
            SetAttackCooldownTimer();
        }

        private void Update()
        {
            Shoot();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Shoot()
        {
            if(!_isFireOn || _isAttackCooldown)
                return;
            _isAttackCooldown = true;
            if (!_doubleShot)
            {
                GameManager.ProjectilesManager.SpawnProjectile(aim.position, transform.rotation, projectileData);
            }
            else
            {
                GameManager.ProjectilesManager.SpawnProjectile(doubleShotAim[0].position, transform.rotation, projectileData);
                GameManager.ProjectilesManager.SpawnProjectile(doubleShotAim[1].position, transform.rotation, projectileData);
            }
            _attackCooldownTimer.Start();
        }

        private void OnAttackCooldownTimeOut(object source, ElapsedEventArgs e)
        {
            _isAttackCooldown = false;
        }

        private void SetAttackCooldownTimer()
        {
            _attackCooldownTimer = new Timer(attackCooldownTime * 1000f) {AutoReset = false};
            _attackCooldownTimer.Elapsed += OnAttackCooldownTimeOut;
        }

        public void ApplyUpgrades(UpgradeList upgradeList)
        {
            _attackPower = (int) upgradeList.attackPower.scale[GameData.AttackPower];
            _attackCooldownTimer.Interval = (attackCooldownTime - upgradeList.attackSpeed.scale[GameData.AttackSpeed]) * 1000f;
            _doubleShot = GameData.DoubleShot == 1;
            projectileData.attackPower = _attackPower;
        }
    }
}
