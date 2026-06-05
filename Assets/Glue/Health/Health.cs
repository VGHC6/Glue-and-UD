using System;
using UnityEngine;

namespace GLUE
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public float CurrentHealth { get; private set; }
        [field: SerializeField] public float MaxHealth { get; private set; }

        //公共事件
        public event Action<float> OnHealthChanged;
        public event Action OnDead;
        public event Action<float> OnRevive;

        private void Awake()
        {
            CurrentHealth = MaxHealth;
        }

        public void ReceiveDamage(float damage)
        {
            if (damage == 0) return;
            if (damage > CurrentHealth|| CurrentHealth == 0)
            {
                CurrentHealth = 0;
                OnHealthChanged?.Invoke(-damage);
                OnDead?.Invoke();
                Debug.Log("You are dead");
                return;
            }
            CurrentHealth -= damage;
            OnHealthChanged?.Invoke(-damage);
        }

        public void Heal(float heal)
        {

        }

        public void Revive(float precent=1)
        {
            OnRevive?.Invoke(precent);
        }
    }
}