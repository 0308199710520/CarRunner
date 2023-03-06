using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    private int _damageValue = 5;
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
