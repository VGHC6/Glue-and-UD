using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    public class ColisionDamage : MonoBehaviour
    {
        [field: SerializeField] float _damage = 5;

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<Health>(out Health target))
            {
                target.ReceiveDamage(_damage);
            }
        }
    }
}
