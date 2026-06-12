using System;
using UnityEngine;
using System.Collections;
namespace UD
{
    [Serializable]
    public class SkyBlender
    {
        [SerializeField] Material _sykBox;
        [SerializeField, Range(0, 1)] float blend = 0f;
        MonoBehaviour _owner;

        public SkyBlender(Material sykBox, MonoBehaviour owner)
        {
            _sykBox = sykBox;
            _owner = owner;
        }

        public void Update()
        {
            _sykBox.SetFloat("_Blend", blend);
        }


        public void TranslateSky(float finnalValue, float totalTime)
        {
            _owner.StartCoroutine(TranslateSkyCoroutine(finnalValue, totalTime));
        }

        IEnumerator TranslateSkyCoroutine(float finnalValue, float totalTime)
        {
            float startTime = blend;
            float elapsedTime = 0f;
            while (elapsedTime < totalTime)
            {
                elapsedTime += Time.deltaTime;
                blend = Mathf.Lerp(startTime, finnalValue, elapsedTime / totalTime);
                yield return null;
            }
            blend = finnalValue;
        }
    }
}