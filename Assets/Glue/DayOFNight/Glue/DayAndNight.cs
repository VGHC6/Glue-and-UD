using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    public class DayAndNight : MonoBehaviour
    {
        [SerializeField] TimeOfDay _timeOfDay;
        [SerializeField] SkyBlender _skyBlender;

        private void Awake()
        {
            _timeOfDay.OnSunrise += Sunrise;
            _timeOfDay.OnSunset += Sunset;
        }

        private void OnDisable()
        {
            _timeOfDay.OnSunrise -= Sunrise;
            _timeOfDay.OnSunset -= Sunset;
        }

        void Sunrise()
        {
            _skyBlender.SetBlend(0);
        }

        void Sunset()
        {
            _skyBlender.SetBlend(1);
        }
    }
}