using System;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class SkyBlender
    {
        [SerializeField] Material _sykBox;
        [SerializeField, Range(0, 1)] float blend = 0f;

        public SkyBlender(Material sykBox)
        {
            _sykBox = sykBox;
        }

        public void Update()
        {
            _sykBox.SetFloat("_Blend", blend);
        }
    }
}