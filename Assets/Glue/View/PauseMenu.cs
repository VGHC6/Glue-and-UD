using UnityEngine;
namespace GLUE
{
    [RequireComponent(typeof(PauseMenuView))]
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] PauseMenuView _pauseMenuView;


        private void Awake()
        {
            //¶©ÔÄ
            _pauseMenuView.OnResumeClick += Resume;
            _pauseMenuView.OnSettingClick += Setting;
            _pauseMenuView.OnMainMuneClick += MainMune;
            _pauseMenuView.OnQuitClick += Quit;

        }

        public void Show()
        {
            _pauseMenuView.Show();
        }

        public void Hide()
        {
            _pauseMenuView.Hide();
        }

        void Resume()
        {
            Debug.Log("Resume");
        }

        void Setting()
        {
            Debug.Log("Setting");
        }

        void MainMune()
        {
            Debug.Log("MainMune");
        }

        void Quit()
        {
            Debug.Log("Quit");
        }
    }
}