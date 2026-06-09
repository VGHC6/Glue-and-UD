using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GLUE
{
    public class TimeOfDay : MonoBehaviour
    {
        [Range(0, 24)]
        [SerializeField] float _time;
        [Range(0, 1)]
        [SerializeField] float _daySpeed;
        private void Update()
        {
            _time+= Time.deltaTime* _daySpeed;
            if(_time >= 24)
            {
                _time = 0;
            }
        }
    }
}