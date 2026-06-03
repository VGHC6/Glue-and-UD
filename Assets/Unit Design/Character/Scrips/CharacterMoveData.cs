using UnityEngine;

namespace UD
{
    [CreateAssetMenu(fileName = "CharacterMoveData", menuName = "CharacterMoveData")]//创建配置文件
    public class CharacterMoveData : ScriptableObject
    {
        public float SENCITIVITY = 0.05f;
        public float VERTICALSENCITIVITY = 0.5f;
    }
}