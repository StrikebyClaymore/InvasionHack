using Assets.Scripts.Mobs.Player;
using UnityEngine;

namespace Assets.Scripts.GUI
{
    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerAttack playerAttack;

        public void OnNitroDown()
        {
            
        }

        public void OnNitroUp()
        {
            
        }
        
        public void OnAttackDown()
        {
            playerAttack.IsFireOn = true;
        }

        public void OnAttackUp()
        {
            playerAttack.IsFireOn = false;
        }
    }
}
