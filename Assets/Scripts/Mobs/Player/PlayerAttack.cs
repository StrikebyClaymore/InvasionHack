using System.Timers;
using Assets.Scripts.Factory;
using Assets.Scripts.Managers;
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
            GameManager.ProjectilesManager.SpawnProjectile(aim.position, transform.rotation, projectileData);
            _isAttackCooldown = true;
            _attackCooldownTimer.Start();
        }

        private void OnAttackCooldownTimeOut(object source, ElapsedEventArgs e)
        {
            _isAttackCooldown = false;
        }

        private void SetAttackCooldownTimer()
        {
            _attackCooldownTimer = new Timer(attackCooldownTime * 1000f);
            _attackCooldownTimer.Elapsed += OnAttackCooldownTimeOut;
        }

        public void ApplyUpgrades(GameData gameData)
        {
            
        }
    }
}
