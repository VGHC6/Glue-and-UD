using UnityEngine;
using UnityEngine.TextCore.Text;

namespace UD
{
    public class ScenceController : MonoBehaviour
    {
        [SerializeField] DamageTrigger[] _damageTriggers;

        private void Awake()
        {
            _damageTriggers = FindObjectsOfType<DamageTrigger>();//²éÕÒ×é¼þ

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