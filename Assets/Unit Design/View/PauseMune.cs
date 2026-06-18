using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UD
{
    public class PauseMune : MonoBehaviour
    {
        [SerializeField] GameObject _gameControl;

        public void Show()
        {
            _gameControl.SetActive(true);
        }

        public void Hide()
        {
            _gameControl.SetActive(false);
        }
    }
}