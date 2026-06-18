using UnityEngine;
namespace GLUE
{
    [RequireComponent(typeof(PauseMenuView))]
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] PauseMenuView _pauseMenuView;

        public void Show()
        {
            _pauseMenuView.Show();
        }
        
        public void Hide()
        {
            _pauseMenuView.Hide();
        }
    }
}