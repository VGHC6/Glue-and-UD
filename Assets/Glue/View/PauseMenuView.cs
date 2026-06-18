using UnityEngine;

public class PauseMenuView : MonoBehaviour
{
    [SerializeField] GameObject _gameControl;

    public void Show()
    {
        _gameControl.SetActive(true);
    }

    public void Hide()
    {
        _gameControl.SetActive(false);
    }
}
