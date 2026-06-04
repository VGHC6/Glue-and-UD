using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float CurrentHealth { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }


    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void ReceiveDamage(float damage)
    {

    }

    public void Heal(float heal)
    {

    }

    public void Revive(float precent)
    {
        precent -= 1;
    }
}
