using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UD
{
    public class TimeOfNight
    {
        [SerializeField] public DayOfNight _dayOfNight { get; private set; }

        public void UpDate(float DeltaTime)
        {
            _dayOfNight.UpDate(DeltaTime);
        }
    }
}