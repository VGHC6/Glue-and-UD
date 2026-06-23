using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    public class SettingMuneView : MonoBehaviour
    {
        [SerializeField] GameObject _settingMune;

        public void Show()
        {
            _settingMune.SetActive(true);
        }

        public void Hide()
        {
            _settingMune.SetActive(false);
        }
    }
}