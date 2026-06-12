using System;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class TimeOfNight
    {
        [SerializeField] DayOfNight _dayOfNight;

        [SerializeField] SkyBlender _skyBlender;
        public TimeOfNight(Material sykBox, MonoBehaviour owner)
        {
            _dayOfNight = new DayOfNight();
            _skyBlender = new SkyBlender(sykBox, owner);

            DayOfNight.OnSunrise += OnSunrise;
            DayOfNight.OnSunset += OnSunset;
        }

        private void OnSunrise()
        {
            _skyBlender.TranslateSky(0, 2f);
        }

        private void OnSunset()
        {
            _skyBlender.TranslateSky(1, 2f);
        }

        public void OnDestroy()
        {
            DayOfNight.OnSunrise -= OnSunrise;
            DayOfNight.OnSunset -= OnSunset;
        }


        public void UpDate(float DeltaTime)
        {
            _dayOfNight.UpDate(DeltaTime);
            _skyBlender.Update();
        }
    }
}