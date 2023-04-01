using ObstacleManager;
using UnityEngine;

namespace GameStateManager
{
    public class PlayerStatsManager : MonoBehaviour, IDamageable
    {
        private int health = 20;
        private int turnSpeed = 10;
        [SerializeField, Range(0.01f, 100f)] private float speed = 0;

        void IDamageable.DamageHealth(int damage)
        {
            health -= damage;
        }

        public float GetSpeed()
        {
            return speed;
        }
    }
}