using UnityEngine;
namespace UD
{
    [CreateAssetMenu(fileName = "CharacterHealthData", menuName = "Character/HealthData")]
    public class CharacterHealthData : ScriptableObject
    {
        public float CurrentHealth = 10;
        public float MaxHealth = 10;
    }
}