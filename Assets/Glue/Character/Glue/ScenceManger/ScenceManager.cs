using UnityEngine;
using static GLUE.ScenceManager;

namespace GLUE
{
    public class ScenceManager : MonoBehaviour
    {
        [SerializeField] fristPersonSystem _fristPersonSystem;
        [SerializeField] ActionRader _actionRader;
        [SerializeField] PauseMenu _pauseMenu;
        public enum SceneState { Playing, Pause };
        public SceneState _sceneState;
        private void Start()
        {
            _sceneState = SceneState.Playing;
            _actionRader.OnPausePression += TogglePause;
            _fristPersonSystem.init(_actionRader);

            _actionRader.OnEnablePlayerInput();

        }

        void TogglePause()
        {
            if (_sceneState == SceneState.Playing)
            {
                Pause();
            }
            else if (_sceneState == SceneState.Pause)
            {
                Resume();
            }
        }


        void Resume()
        {
            // Debug.Log("Resume");
            _sceneState = SceneState.Playing;
            Time.timeScale = 1;
            _actionRader.OnEnablePlayerInput();
            _pauseMenu.Hide();
        }

        void Pause()
        {
            // Debug.Log("Pause");
            _sceneState = SceneState.Pause;
            Time.timeScale = 0;
            _actionRader.OnDisablePlayerInput();
            _pauseMenu.Show();
        }
    }
}