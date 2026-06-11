using System;
using UnityEngine;

namespace UD
{
    [Serializable]
    public class TimeOfNight
    {
        [SerializeField] public DayOfNight _dayOfNight { get; private set; }

        [SerializeField] SkyBlender _skyBlender;

        public TimeOfNight(Material sykBox)
        {
            _dayOfNight = new DayOfNight();
            _skyBlender = new SkyBlender(sykBox);
        }
        public void UpDate(float DeltaTime)
        {
            _dayOfNight.UpDate(DeltaTime);
            _skyBlender.Update();
        }
    }
}