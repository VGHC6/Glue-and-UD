using UnityEngine;
using UnityEngine.UI;
using System;

namespace GLUE
{
    public class SettingMuneView : MonoBehaviour
    {
        [SerializeField] GameObject _settingMune;
        [SerializeField] Button _saveButton;
        [SerializeField] Slider _sliderMaster;

        public event Action OnSaveClick;
        public event Action<float> OnSliderChange;
        public void Awake()
        {
            _saveButton.onClick.AddListener(TriggerSaveButton);//Ìí¼Ó±£´æ°´Å¥¼àÌý
            _sliderMaster.onValueChanged.AddListener(TriggerSliderChange);//Ìí¼Ó»¬¶¯Ìõ¼àÌý
        }

        public void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(TriggerSaveButton);//ÒÆ³ý±£´æ°´Å¥¼àÌý
            _sliderMaster.onValueChanged.RemoveListener(TriggerSliderChange);//ÒÆ³ý»¬¶¯Ìõ¼àÌý
        }
        public void Show()
        {
            _settingMune.SetActive(true);
        }

        public void Hide()
        {
            _settingMune.SetActive(false);
        }


        public void TriggerSaveButton() => OnSaveClick?.Invoke();//´¥·¢±£´æ°´Å¥
        public void TriggerSliderChange(float newValue) => OnSliderChange?.Invoke(newValue);
    }
}