using UnityEngine;
using System;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] GameObject _gameControl;
    [SerializeField] Button _resume;
    [SerializeField] Button _setting;
    [SerializeField] Button _mainMune;
    [SerializeField] Button _quit;

    public event Action OnResumeClick;
    public event Action OnSettingClick;
    public event Action OnMainMuneClick;
    public event Action OnQuitClick;

    private void Awake()
    {
        //注册,点击时
        _resume.onClick.AddListener(TriggerResumeClick);//+=是强制类型注册的方法签名必须完全匹配。AddListener 仅支持无参或极少数特定参数。+= (顺序不确定)，通过链表存储，AddListener (顺序确定)，方法会被依次添加到 List 中
        _setting.onClick.AddListener(TriggerSettingClick);
        _mainMune.onClick.AddListener(TriggerMainMuneClick);
        _quit.onClick.AddListener(TriggerQuitClick);
    }

    private void OnDestroy()
    {
        _resume.onClick.RemoveListener(TriggerResumeClick);
    }

    public void Show()
    {
        _gameControl.SetActive(true);
    }

    public void Hide()
    {
        _gameControl.SetActive(false);
    }

    void TriggerResumeClick() => OnResumeClick?.Invoke();
    void TriggerSettingClick() => OnSettingClick?.Invoke();
    void TriggerMainMuneClick() => OnMainMuneClick?.Invoke();
    void TriggerQuitClick() => OnQuitClick?.Invoke();

}
