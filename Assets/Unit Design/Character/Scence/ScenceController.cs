using System;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class ScenceController : MonoBehaviour
    {
        [SerializeField] DamageTrigger[] _damageTriggers;
        [SerializeField] character _character;
        [SerializeField] HealthView _health;

        [SerializeField] TimeOfNight _timeOfNight;

        //依赖
        [SerializeField] Material _sykBox;
        private void Awake()
        {
            _damageTriggers = FindObjectsOfType<DamageTrigger>();//查找组件
            //给每个组件的OnCharacterEnter事件添加方法
            for (int i = 0; i < _damageTriggers.Length; i++)
            {
                _damageTriggers[i].OnCharacterEnter += OnTriggerDamageEnter;
            }
            _health.Bind(_character);

            _timeOfNight = new TimeOfNight(_sykBox);
        }

        private void Update()
        {
            _timeOfNight.UpDate(Time.deltaTime);
        }

        private void OnTriggerDamageEnter(character character, DamageTrigger damageTrigger)
        {
            Debug.Log("OnTriggerDamageEnter");
            character.ReceiveDamage(damageTrigger._damage);
        }
    }
}