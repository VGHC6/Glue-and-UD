using System;
using UnityEngine;
namespace UD
{
    [Serializable]
    public class CharacterMovement
    {
        CharacterMoveData _characterMoveData;
        Transform _bodyTransForm;
        float rotationY = 0;
        float rotationX = 0;
        public CharacterMovement(CharacterMoveData characterMoveData, Transform bodyTransForm)
        {
            _characterMoveData = characterMoveData;
            _bodyTransForm = bodyTransForm;
        }
        public void HeadMove(Vector2 lookAction, Transform headTransform)
        {
            rotationX -= lookAction.y * _characterMoveData.SENCITIVITY;
            rotationX = Mathf.Clamp(rotationX, -90, 90);//限制旋转角度
            headTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);//设置旋转
        }

        public void BodyRotate(Vector2 lookAction)
        {
            rotationY += lookAction.x * _characterMoveData.SENCITIVITY;
            _bodyTransForm.rotation = Quaternion.Euler(0, rotationY, 0);//设置旋转

        }

        public void BodyMove(Vector2 moveAction, Rigidbody rigidbody)
        {
            float yVelocity = rigidbody.velocity.y;//获取y轴速度
            Vector3 moveDirection = rigidbody.transform.right * moveAction.x + rigidbody.transform.forward * moveAction.y;
            moveDirection.y = yVelocity;
            Vector3 normalDirection = moveDirection.normalized * _characterMoveData.SPEED;//设置速度
            rigidbody.velocity = normalDirection;
        }
    }
}