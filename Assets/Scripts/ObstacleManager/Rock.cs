using UnityEngine;

namespace ObstacleManager
{
    public class Rock : MonoBehaviour
    {

        private readonly int _damageValue = 5;
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IDamageable>().DamageHealth(_damageValue);
            if (other.gameObject.GetComponent<IDamageable>() != null) 
            { 
        
                Destroy(this.gameObject);
                Debug.Log("Destroyed");
            }
        
        
        }

    }
}
