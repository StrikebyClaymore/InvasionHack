using System.Collections;
using Assets.Scripts.Managers;
using Assets.Scripts.Projectiles;
using UnityEngine;

namespace Assets.Scripts.Mobs.Enemies.SimpleCube
{
    public class SimpleCubeAttack : EnemyAttack
    {
        [SerializeField]
        private ProjectileData projectileData;
        private bool _isStartedCollapse = false;
        private int _collapseMultiplier = 1;
        
        public void StartCollapse(EnemyAttack body)
        {
            if (gameObject.GetInstanceID() < body.gameObject.GetInstanceID())
            {
                Destroy(gameObject);
                return;
            }

            if (_isStartedCollapse)
            {
                _collapseMultiplier++;
                return;
            }

            _isStartedCollapse = true;
            Movement.AllowMove(false);
            Invoke(nameof(Attack), 0.1f);
        }

        protected override void Attack()
        {
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            
            for (int i = 0; i < _collapseMultiplier; i++)
            {
                Invoke(nameof(CreateExplosion), i);
            }

            StartCoroutine(LateDestroy());
        }

        IEnumerator LateDestroy()
        {
            yield return new WaitForSeconds(_collapseMultiplier);
            Destroy(gameObject);
        }
        
        private void CreateExplosion()
        {
            for (int j = 0; j < 18; j++)
            {
                var rot = Quaternion.Euler(0f, j * 20, 0f);
                GameManager.ProjectilesManager.SpawnProjectile(transform.position, rot, projectileData);
            }
        }
    }
}
