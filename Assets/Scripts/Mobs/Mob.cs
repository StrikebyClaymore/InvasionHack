using UnityEngine;

namespace Assets.Scripts.Mobs
{
    public abstract class Mob : MonoBehaviour, IHitble
    {

        [SerializeField] protected int maxHp = 100;
        [SerializeField] protected int currentHp;

        private void Awake()
        {
            if (currentHp == 0)
                currentHp = maxHp;
        }

        public virtual void GetHit(int damage)
        {
            currentHp = Mathf.Max(currentHp - damage, 0);
            if (currentHp == 0)
                Die();
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
