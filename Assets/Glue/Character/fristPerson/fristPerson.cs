using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{

    public class fristPerson : MonoBehaviour
    {
        FristPersonalData _firstPersonalData;
        float rotation = 0;
        float _rotationX;

        public void LoadData(FristPersonalData data)
        {
            _firstPersonalData = data;//加载数据
        }
        public void HeadMove(Vector2 lookAction,Transform HeadTransform)
        {
            _rotationX-=lookAction.y * _firstPersonalData.verticalsensitivity;
            _rotationX=Mathf.Clamp(_rotationX, -90, 90);//限制旋转角度
            HeadTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);//旋转
        }

        public void BodyRotate(Vector2 lookAction)
        {
            rotation += _firstPersonalData.sensitivyty * lookAction.x;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void BodyMove(Vector2 moveAction,Rigidbody rigidbody)
        {
            float  yVelocity = rigidbody.velocity.y;//获取y轴速度
            Vector3 moveDirection=transform.right* moveAction.x + transform.forward * moveAction.y;
            Vector3 targetVelocity= moveDirection.normalized * _firstPersonalData.rotationSpeed;
            targetVelocity.y = yVelocity;//
            rigidbody.velocity = targetVelocity;

        }
    }//end of class
}//end of UD
