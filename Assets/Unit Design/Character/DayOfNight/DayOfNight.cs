using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UD
{
    [Serializable]
    public class DayOfNight
    {
        [Range(0, 24)]
        [SerializeField] float _time;

       public void UpDate(float deltaTime)
        {
            _time+= deltaTime;
            if(_time >= 24)_time = 0;
        }
    }
}