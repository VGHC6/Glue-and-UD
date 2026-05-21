using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    //firstPerson+ActionRader
    public class fristPersonSystem : MonoBehaviour
    {
        [SerializeField] ActionRader _actionRader;//动作读取器
        [SerializeField] fristPerson _fristPerson;//第一人称

        private void Update()
        {
            Vector3 lookAction = _actionRader.Look;
            _fristPerson.BodyMove(lookAction);
        }
    }
}