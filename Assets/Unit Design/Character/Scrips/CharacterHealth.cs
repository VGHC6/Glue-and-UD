using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class CharacterHealth
    {
        [field: SerializeField] public float CurrentHealth { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }

        public event Action<float> OnHealthChanged;//血量改变事件
        public event Action OnDead;//死亡事件
        public event Action<float> OnRevive;//复活事件


        public CharacterHealth(float currentHealth, float maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        public void ReceiveDamage(float damage)
        {
            if (damage == 0) return;
            if (damage > CurrentHealth || CurrentHealth == 0)
            {
                CurrentHealth = 0;
                OnHealthChanged?.Invoke(-damage);
                Debug.Log("You are dead");
                OnDead?.Invoke();
                return;
            }
            CurrentHealth -= damage;
            OnHealthChanged?.Invoke(-damage);
        }

        public void Heal(float heal)
        {

        }

        public void Revive(float precent = 1f)
        {
            OnRevive?.Invoke(precent);
        }
    }
}