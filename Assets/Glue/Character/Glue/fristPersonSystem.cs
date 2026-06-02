using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    //firstPerson+ActionRader
    public class fristPersonSystem : MonoBehaviour
    {
        [SerializeField] FristPersonalData _fristPersonalData;//第一人称数据
        [SerializeField] ActionRader _actionRader;//动作读取器
        [SerializeField] fristPerson _fristPerson;//第一人称
        void Awake()
        {
            _fristPerson.LoadData(_fristPersonalData);
        }
        private void Update()
        {
            Vector3 lookAction = _actionRader.Look;
            _fristPerson.BodyMove(lookAction);
        }
    }
}