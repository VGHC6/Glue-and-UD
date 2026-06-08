using System;
using UnityEngine;
namespace UD
{
    public class DamageTrigger : MonoBehaviour
    {
        public float _damage=5;
        public event Action<character, DamageTrigger> OnCharacterEnter;//事件

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<character>(out character target))
            {
                OnCharacterEnter?.Invoke(target,this);//触发事件
            }
        }
    }
}