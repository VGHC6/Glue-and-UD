using UnityEngine;
using UnityEngine.UI;
using System;
namespace UD
{
    public class SettingMuneView : MonoBehaviour
    {
        [SerializeField] GameObject _view;
        [SerializeField] Button _saveButton;

        public event Action OnSaveClick;

        public void Awake()
        {
            _saveButton.onClick.AddListener(TriggerSaveButton);//Ìí¼Ó±£´æ°´Å¥¼àÌý
        }

        public void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(TriggerSaveButton);//ÒÆ³ý±£´æ°´Å¥¼àÌý
        }
        public void Show()
        {
            _view.SetActive(true);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }

        public void TriggerSaveButton() => OnSaveClick?.Invoke();//´¥·¢±£´æ°´Å¥

    }
}