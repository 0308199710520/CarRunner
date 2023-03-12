using ObstacleManager;
using UnityEngine;

namespace GameStateManager
{
    public class PlayerStatsManager : MonoBehaviour, IDamageable
    {

        [SerializeField] private int health = 20;
        [SerializeField] private int turnSpeed = 10;

        void IDamageable.DamageHealth(int damage)
        {

            health -= damage;
        }
    }
}
