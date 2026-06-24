using UnityEngine;
using System;

namespace GLUE
{
    [RequireComponent(typeof(SettingMuneView))]
    public class SettingMune : MonoBehaviour
    {
        [SerializeField] SettingMuneView _settingMuneView;

       public event Action OnSave;//定义事件
        public void Awake()
        {
            _settingMuneView.OnSaveClick+= OnSaveClick;//注册事件
            _settingMuneView.OnSliderChange+= OnSliderChange;
        }
        public void Show()
        {
            _settingMuneView.Show();
        }

        public void Hide()
        {
            _settingMuneView.Hide();
            OnSave?.Invoke();//触发事件
        }

        void OnSaveClick()
        {
            Hide();
        }

        void OnSliderChange(float newValue)
        {
            Debug.Log("Slider changed");
        }
    }
}