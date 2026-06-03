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
            rotationX -= lookAction.y*_characterMoveData.SENCITIVITY;
            rotationX = Mathf.Clamp(rotationX, -90, 90);//限制旋转角度
            headTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);//设置旋转
        }

        public void BodyRotate(Vector2 lookAction)
        {
            rotationY += lookAction.x * _characterMoveData.SENCITIVITY;
            _bodyTransForm.rotation = Quaternion.Euler(0, rotationY, 0);//设置旋转

        }

        public void BodyMove()
        {

        }
    }
}