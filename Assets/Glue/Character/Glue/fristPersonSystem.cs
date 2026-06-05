using UnityEngine;

namespace GLUE
{
    //firstPerson+ActionRader
    public class fristPersonSystem : MonoBehaviour
    {
        [SerializeField] Transform _headTransform;//头部
        [SerializeField] Rigidbody _rigbody;//刚体
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
            _fristPerson.BodyRotate(lookAction);
            _fristPerson.HeadMove(lookAction, _headTransform);
        }

        private void FixedUpdate()
        {
            Vector3 moveAction = _actionRader.Move;
            _fristPerson.BodyMove(moveAction, _rigbody);
        }
    }
}