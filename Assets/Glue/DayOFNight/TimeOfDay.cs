using UnityEngine;
using System;

namespace GLUE
{
    public class TimeOfDay : MonoBehaviour
    {
        [Range(0, 24)]
        [SerializeField] float _time;
        [Range(0, 1)]
        [SerializeField] float _daySpeed;

        public event Action OnSunrise;
        public event Action OnNoon;
        public event Action OnSunset;
        public event Action OnMidnight;

        private void Update()
        {
            float oldTime = _time;
            _time+= Time.deltaTime* _daySpeed;
            if(_time > 24)
            {
                _time = 0;
            }
            CheckEvent(oldTime, _time);
        }

        private void CheckEvent(float oldTime, float newTime){
            if (oldTime < 6 && newTime >= 6)
            {
                OnSunrise?.Invoke();//激活触发事件
            }
            if (oldTime < 12 && newTime >= 12)
            {
                OnSunrise?.Invoke();//激活触发事件
            }
            if (oldTime < 18 && newTime >= 18)
            {
                OnSunrise?.Invoke();//激活触发事件
            }
            if (oldTime < 24 && newTime >= 24)
            {
                OnSunrise?.Invoke();//激活触发事件
            }
        }
    }
}