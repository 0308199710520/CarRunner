using ObstacleManager;
using UnityEngine;

namespace GameStateManager
{
    public class PlayerStatsManager : MonoBehaviour, IDamageable
    {

        [SerializeField] private float health = 20;

        void IDamageable.DamageHealth(int damage)
        {

            health -= damage;
        }
    }
}
