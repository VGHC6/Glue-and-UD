using System;
using UnityEngine;

namespace UD
{

    public class character : MonoBehaviour
    {
        [field: SerializeField] public CharacterMovement CharacterMovement { get; private set; }
        [field: SerializeField] public characterReader characterReader { get; private set; }

    }//end of class
}//end of UD
