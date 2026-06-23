using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GLUE
{
    [RequireComponent(typeof(SettingMuneView))]
    public class SettingMune : MonoBehaviour
    {
        [SerializeField] SettingMuneView _settingMuneView;

       public void Show()
        {
            _settingMuneView.Show();
        }

        public void Hide()
        {
            _settingMuneView.Hide();
        }
    }
}