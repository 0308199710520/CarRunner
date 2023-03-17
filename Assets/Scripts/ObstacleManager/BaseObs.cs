using UnityEngine;

namespace ObstacleManager
{
    public class BaseObs : MonoBehaviour
    {
        private const int DAMAGE_VALUE = 5;
        private ObsManager _obstacleManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IDamageable>() is null) return;

            other.gameObject.GetComponent<IDamageable>().DamageHealth(DAMAGE_VALUE);

            _obstacleManager.MarkedForDeath(gameObject);
            Debug.Log("Destroyed");
        }

        public void SetObsManager(ObsManager obsManager)
        {
            _obstacleManager = obsManager;
        }
    }
}