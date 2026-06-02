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

        public CharacterMovement(CharacterMoveData characterMoveData, Transform bodyTransForm)
        {
            _characterMoveData = characterMoveData;
            _bodyTransForm = bodyTransForm;
        }
        public void HeadMove()
        {

        }

        public void BodyRotate(Vector2 lookAction)
        {
            rotationY += lookAction.x * _characterMoveData.SENCITIVITY;
            _bodyTransForm.rotation = Quaternion.Euler(0, rotationY, 0);//ÉèÖÃÐý×ª

        }

        public void BodyMove()
        {

        }
    }
}