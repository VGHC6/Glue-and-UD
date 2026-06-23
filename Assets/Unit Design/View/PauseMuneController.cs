using System.Threading.Tasks;
using UnityEngine;


namespace UD
{
    [RequireComponent(typeof(PauseMune))]
    public class PauseMuneController : MonoBehaviour
    {
        [SerializeField] PauseMune _pauseMune;

        [Header("依赖项")]
        [SerializeField] SettingMune _settingfabs;
        [Header("运行时变量")]
        [SerializeField] SettingMune _settingMune;

       public TaskCompletionSource<PauseMenu> _pauseMenuTask;
        public enum PauseMenu
        {
            resume,
            setting,
            mainMune,
            quit
        }

        private void Awake()
        {
            _pauseMune.OnResumeClick += Resume;
            _pauseMune.OnSettingClick += Setting;
            _pauseMune.OnMainMuneClick += MainMune;
            _pauseMune.OnQuitClick += Quit;
        }

        public Task<PauseMenu> Show()
        {
            _pauseMune.Show();

            _pauseMenuTask = new TaskCompletionSource<PauseMenu>();
            return _pauseMenuTask.Task;
        }

        public void Hide()
        {
            _pauseMune.Hide();
        }

        //事件
        void Resume()
        {
            _pauseMenuTask.SetResult(PauseMenu.resume);
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