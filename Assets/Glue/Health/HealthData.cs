using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "Health/HealthData")]
    public class HealthData : ScriptableObject
    {
        public float CurrentHealth = 10;
        public float MaxHealth = 10;
    }
}