using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;
namespace UD
{
    [RequireComponent(typeof(SettingMuneView))]
    public class SettingMune : MonoBehaviour
    {
        [SerializeField] SettingMuneView _settingMuneView;
        [SerializeField] AudioMixer _audioMixer;
        float _currentMasterVolume=0;

        public event Action OnSave;//定义事件
        //任务
        TaskCompletionSource<SettingMuneViewData> _showTaskCompletionSource;
        public struct SettingMuneViewData
        {
            public float masterVolume;
        }
        public void Awake()
        {
            _settingMuneView.OnSaveClick += OnSaveClick;//注册事件
            _settingMuneView.OnSliderMasterChange+= OnSliderMasterChange;
        }

        public void OnDestroy()
        {
            _settingMuneView.OnSaveClick -= OnSaveClick;//注销事件
            _settingMuneView.OnSliderMasterChange -= OnSliderMasterChange;

        }
        public Task<SettingMuneViewData> Show()
        {
            _settingMuneView.Show();
            _showTaskCompletionSource= new TaskCompletionSource<SettingMuneViewData>();
            return _showTaskCompletionSource.Task;
        }

        public void Hide()
        {
            _settingMuneView.Hide();
        }

        void OnSaveClick()
        {
            Hide();
            SettingMuneViewData result = new SettingMuneViewData
            {
                masterVolume = _currentMasterVolume
            };

            _showTaskCompletionSource.SetResult(result);
        }
       void OnSliderMasterChange(float newValue)
        {
            Debug.Log("Slider changed");
            float minDb = -80;
            float maxDb = 0;
            float mixValue = minDb + (maxDb - minDb) * newValue;
            _audioMixer.SetFloat("Master", mixValue);
            _currentMasterVolume = newValue;
        }

    }
}