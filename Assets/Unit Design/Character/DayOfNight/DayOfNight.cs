using System;
using UnityEngine;
namespace UD
{
    [Serializable]
    public class DayOfNight
    {
        [Range(0, 24)]
        [SerializeField] float _time;

        public event Action OnSunrise;
        public event Action OnNoon;
        public event Action OnSunset;
        public event Action OnMidnight;

        public event Action<int> ChangeHourTime;
        public void UpDate(float deltaTime)
        {
            float oldTime = _time;
            _time += deltaTime;
            if (_time >= 24) _time = 0;
            CheckEvent(oldTime, _time);
        }

        private void CheckEvent(float oldTime, float newTime)
        {
            if (oldTime < 6 && newTime >= 6)
            {
                //Debug.Log("Sunrise");
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


            if (Mathf.FloorToInt(oldTime) != Mathf.FloorToInt(newTime))
            {
                Debug.Log($"{GetTime()}");
                ChangeHourTime?.Invoke(Mathf.FloorToInt(newTime));
            }
        }


        public (int, int, int) GetTime()
        {
            int hour = Mathf.FloorToInt(_time);
            float raminHours = _time - hour;
            int minutes = Mathf.FloorToInt(raminHours * 60);
            float raminMinutes = (raminHours * 60) - minutes;
            int seconds = Mathf.FloorToInt(raminMinutes * 60);
            return (hour, minutes, seconds);
        }
    }
}