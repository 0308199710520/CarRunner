using UnityEngine;

namespace ObstacleManager
{
    public class BaseObs : MonoBehaviour
    {
        
        private readonly int _damageValue = 5;
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IDamageable>().DamageHealth(_damageValue);
            if (other.gameObject.GetComponent<IDamageable>() != null) 
            {
                Destroy(gameObject);
                Debug.Log("Destroyed");
            }
        }
        
    }
}