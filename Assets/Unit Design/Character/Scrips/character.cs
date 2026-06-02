using System;
using UnityEngine;

namespace UD
{

    public class character : MonoBehaviour
    {
        [field: SerializeField] public CharacterData _characterdata { get; private set; }
        [field: SerializeField] public CharacterMovement CharacterMovement { get; private set; }
        [field: SerializeField] public characterReader characterReader { get; private set; }


       private void Awake()
        {
            characterReader = new characterReader();//创建动作读取器
            CharacterMovement=new CharacterMovement(_characterdata._charaterMoveData, this.transform);//创建动作
            characterReader.OnAwake();//动作读取器初始化
        }

        private void OnEnable()
        {
            characterReader.OnEnable();//动作读取器启用
        }

        private void Update()
        {
            CharacterMovement.BodyRotate(characterReader.Look);//动作
        }

        private void OnDisable()
        {
            characterReader.OnDisable();//动作读取器禁用
        }

    }//end of class
}//end of UD
