using UnityEngine;
using UnityEngine.UI;
using System;
namespace UD
{
    public class SettingMuneView : MonoBehaviour
    {
        [SerializeField] GameObject _view;
        [SerializeField] Button _saveButton;
        [SerializeField] Slider _sliderMaster;

        //事件
        public event Action OnSaveClick;
        public event Action<float> OnSliderMasterChange;




        public void Awake()
        {
            _saveButton.onClick.AddListener(TriggerSaveButton);//添加保存按钮监听
            _sliderMaster.onValueChanged.AddListener(TriggerSliderMasterChange);//添加音量改变监听
        }



        public void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(TriggerSaveButton);//移除保存按钮监听
        }
        public void Show()
        {
            _view.SetActive(true);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }

        public void TriggerSaveButton() => OnSaveClick?.Invoke();//触发保存按钮
        public void TriggerSliderMasterChange(float value) => OnSliderMasterChange?.Invoke(value);//触发音量改变
    }
}