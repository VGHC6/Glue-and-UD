using UnityEngine;

namespace UD
{
    public class ScenceController : MonoBehaviour
    {
        [SerializeField] DamageTrigger[] _damageTriggers;

        private void Awake()
        {
            _damageTriggers = FindObjectsOfType<DamageTrigger>();//查找组件
            //给每个组件的OnCharacterEnter事件添加方法
            for (int i = 0; i < _damageTriggers.Length; i++)
            {
                _damageTriggers[i].OnCharacterEnter += OnTriggerDamageEnter;
            }
        }

        private void OnTriggerDamageEnter(character character, DamageTrigger damageTrigger)
        {
            Debug.Log("OnTriggerDamageEnter");
            character.ReceiveDamage(damageTrigger._damage);
        }
    }
}