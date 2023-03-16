using UnityEngine;

namespace ObstacleManager
{
    public class BaseObs : MonoBehaviour
    {
        
        private readonly int _damageValue = 5;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<IDamageable>() is null) return;
            
            other.gameObject.GetComponent<IDamageable>().DamageHealth(_damageValue);
            if (other.gameObject.GetComponent<IDamageable>() != null) 
            {
                Destroy(gameObject);
                Debug.Log("Destroyed");
            }
        }

        private void Update()
        {
            transform.position += Vector3.back * Time.deltaTime * 100;
        }
    }
}