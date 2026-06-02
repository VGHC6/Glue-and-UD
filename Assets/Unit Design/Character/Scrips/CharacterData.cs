using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UD
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "CharacterData")]//创建配置文件
    public class CharacterData : ScriptableObject
    {
        public CharacterMoveData _charaterMoveData;
    }
}