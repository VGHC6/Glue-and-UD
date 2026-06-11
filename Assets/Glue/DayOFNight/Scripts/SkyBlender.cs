using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    public class SkyBlender : MonoBehaviour
    {
        [SerializeField] Material _sykBox;
        [SerializeField,Range(0,1)] float blend=0f;

        private void Update()
        {
            _sykBox.SetFloat("_Blend", blend);
        }

        public void SetBlend(float blend)
        {
            this.blend = blend;
        }
    }
}