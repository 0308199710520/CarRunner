using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour, IDamageable
{

 [SerializeField] private float Health = 20;

    void IDamageable.DamageHealth(int damage)
    {

        Health -= damage;
    }
}
