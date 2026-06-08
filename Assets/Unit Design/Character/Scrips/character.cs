using System;
using UnityEngine;

namespace UD
{
    public class character : MonoBehaviour
    {
        //子部件
        [field: SerializeField] public CharacterData _characterdata { get; private set; }
        [field: SerializeField] public CharacterMovement CharacterMovement { get; private set; }
        [field: SerializeField] public characterReader characterReader { get; private set; }

        [field:SerializeField] public CharacterHealth CharacterHealth { get; private set; }

        //依赖
        [SerializeField] public Transform headTransfrom;//头部相机
        [SerializeField] public Rigidbody rigidbodyMove;//身体
        private void Awake()
        {
            characterReader = new characterReader();//创建动作读取器
            CharacterMovement = new CharacterMovement(_characterdata._charaterMoveData, this.transform);//创建动作
            characterReader.OnAwake();//动作读取器初始化
            CharacterHealth=new CharacterHealth(_characterdata._characterHealthData);
        }

        private void OnEnable()
        {
            characterReader.OnEnable();//动作读取器启用
        }

        private void Update()
        {
            CharacterMovement.BodyRotate(characterReader.Look);//动作
            CharacterMovement.HeadMove(characterReader.Look, headTransfrom);//动作
        }

        private void OnDisable()
        {
            characterReader.OnDisable();//动作读取器禁用
        }

        private void FixedUpdate()
        {
            CharacterMovement.BodyMove(characterReader.Move, rigidbodyMove);//动作
        }


        //UD的角色方法
        public void ReceiveDamage(float damageAmont)
        {
            CharacterHealth.ReceiveDamage(damageAmont);
        }

        public void Heal(float healAmont)
        {
            CharacterHealth.Heal(healAmont);
        }
    }//end of class
}//end of UD
