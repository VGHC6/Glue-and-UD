using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class CharacterHealth
    {
        [field: SerializeField] public float CurrentHealth { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }


        public CharacterHealth(float currentHealth, float maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        public void ReceiveDamage(float damage)
        {

        }

        public void Heal(float heal)
        {

        }

        public void Revive(float precent = 1f)
        {

        }
    }
}