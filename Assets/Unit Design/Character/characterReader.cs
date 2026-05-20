using System;
using UnityEngine;

namespace UD
{
    public class characterReader
    {
        [SerializeField] GameControl _gameControl;
        void Awake()
        {
            _gameControl = new GameControl();
        }


        void OnEnable()
        {
            _gameControl.Enable();
        }

        void OnDisable()
        {
            _gameControl.Disable();
        }
    }
}