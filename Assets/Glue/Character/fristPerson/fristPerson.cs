using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{

    public class fristPerson : MonoBehaviour
    {
        FristPersonalData _firstPersonalData;
        float rotation = 0;

        public void LoadData(FristPersonalData data)
        {
            _firstPersonalData = data;//º”‘ÿ ˝æ›
        }
        public void HeadMove()
        {

        }

        public void BodyMove(Vector2 lookAction)
        {
            rotation += _firstPersonalData.sensitivyty * lookAction.x;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void BodyRotate()
        {

        }
    }//end of class
}//end of UD
