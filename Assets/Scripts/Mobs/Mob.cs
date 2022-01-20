using UnityEngine;

namespace Assets.Scripts.Mobs
{
    public abstract class Mob : MonoBehaviour, IHitble
    {

        [SerializeField] protected int maxHp = 100;
        [SerializeField] protected int currentHp;

        protected virtual void Awake()
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

        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
