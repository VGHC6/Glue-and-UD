using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UD
{
    [RequireComponent(typeof(PauseMune))]
    public class PauseMuneController : MonoBehaviour
    {
        [SerializeField] PauseMune _pauseMune;

        public async void Show()
        {
            _pauseMune.Show();
        }

        public void Hide()
        {
            _pauseMune.Hide();
        }
    }
}