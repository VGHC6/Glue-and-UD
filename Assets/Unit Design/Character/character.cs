using System;
using UnityEngine;

namespace UD
{

    public class character : MonoBehaviour
    {
        [field: SerializeField] public CharacterMovement CharacterMovement { get; private set; }
        [field: SerializeField] public characterReader characterReader { get; private set; }


       private void Awake()
        {
            characterReader = new characterReader();//创建动作读取器
            characterReader.OnAwake();//动作读取器初始化
        }

        private void OnEnable()
        {
            characterReader.OnEnable();//动作读取器启用
        }

        private void OnDisable()
        {
            characterReader.OnDisable();//动作读取器禁用
        }

    }//end of class
}//end of UD
