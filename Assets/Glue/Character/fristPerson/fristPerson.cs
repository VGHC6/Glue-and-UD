using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{

    public class fristPerson : MonoBehaviour
    {

        float rotation = 0;
        const float sensitivyty = 0.5f;
        public void HeadMove()
        {

        }

        public void BodyMove(Vector2 lookAction)
        {
            rotation += sensitivyty * lookAction.x;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }

        public void BodyRotate()
        {

        }
    }//end of class
}//end of UD
