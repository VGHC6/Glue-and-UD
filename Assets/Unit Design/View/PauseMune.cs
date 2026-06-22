using UnityEngine;
using UnityEngine.UI;
using System;
namespace UD
{
    public class PauseMune : MonoBehaviour
    {
        [SerializeField] GameObject _gameControl;

        [SerializeField] Button _resumeButton;
        [SerializeField] Button _settingButton;
        [SerializeField] Button _mainMuneButton;
        [SerializeField] Button _quitButton;

        public event Action OnResumeClick;
        public event Action OnSettingClick;
        public event Action OnMainMuneClick;
        public event Action OnQuitClick;

        void Awake()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
            _settingButton.onClick.AddListener(OnSettingButtonClick);
            _mainMuneButton.onClick.AddListener(OnMainMuneButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        private void OnDestroy()
        {
            _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
            _settingButton.onClick.RemoveListener(OnSettingButtonClick);
            _mainMuneButton.onClick.RemoveListener(OnMainMuneButtonClick);
            _quitButton.onClick.RemoveListener(OnQuitButtonClick);
        }

        public void Show()
        {
            _gameControl.SetActive(true);
        }

        public void Hide()
        {
            _gameControl.SetActive(false);
        }

        void OnResumeButtonClick() => OnResumeClick?.Invoke();
        void OnSettingButtonClick() => OnSettingClick?.Invoke();
        void OnMainMuneButtonClick() => OnMainMuneClick?.Invoke();
        void OnQuitButtonClick() => OnQuitClick?.Invoke();

    }
}