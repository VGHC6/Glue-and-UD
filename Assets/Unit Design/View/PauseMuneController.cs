using GLUE;
using System.Threading.Tasks;
using UnityEngine;


namespace UD
{
    [RequireComponent(typeof(PauseMune))]
    public class PauseMuneController : MonoBehaviour
    {
        [SerializeField] PauseMune _pauseMune;

        [SerializeField] SettingMune _settingfabs;
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
            _settingMune?.Hide();
            _pauseMune.Hide();
        }

        //�¼�
        void Resume()
        {
            _pauseMenuTask.SetResult(PauseMenu.resume);
        }

        async void Setting()
        {
            if (_settingMune == null)
                _settingMune = Instantiate(_settingfabs, transform);
            SettingMune.SettingMuneViewData result = await _settingMune.Show();
            _pauseMenuTask.SetResult(PauseMenu.setting);
            _settingMune.Hide();
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