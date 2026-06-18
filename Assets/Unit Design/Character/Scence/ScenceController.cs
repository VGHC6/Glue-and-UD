using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace UD
{
    [Serializable]
    public class ScenceController : MonoBehaviour
    {
        public enum ScenceState { Play, Pause }
        [SerializeField] DamageTrigger[] _damageTriggers;
        [SerializeField] character _character;
        [SerializeField] HealthView _health;
        [SerializeField] characterReader _characterReader;
        [SerializeField] TimeOfNight _timeOfNight;
        [SerializeField] Material _sykBox;

        [Header("必须填写")]
        [SerializeField] PauseMuneController _pauseMuneControllerfabs;
        [SerializeField] Transform _pauseMuneTransfrom;

        [Header("运行时参数")]
        [SerializeField] ScenceState _scenceState;
        [SerializeField] PauseMuneController _pauseMune;

        private void Awake()
        {
            _characterReader = new characterReader();
            _characterReader.OnAwake();
            _character.Init(_characterReader);
            _damageTriggers = FindObjectsOfType<DamageTrigger>();
            for (int i = 0; i < _damageTriggers.Length; i++)
            {
                _damageTriggers[i].OnCharacterEnter += OnTriggerDamageEnter;
            }
            _health.Bind(_character);

            _timeOfNight = new TimeOfNight(_sykBox, this);
        }

        private void Start()
        {
            _characterReader.OnPausePression += TrigglePause;
            _characterReader.OnEnablePlayerInput();

        }

        private void Update()
        {
            _timeOfNight.UpDate(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _timeOfNight.OnDestroy();
        }

        private void OnEnable()
        {
            _characterReader.OnEnable();//动作读取器启用
        }

        private void OnDisable()
        {
            _characterReader.OnDisable();//动作读取器禁用
        }

        //单元状态

        void TrigglePause()
        {
            if (_scenceState == ScenceState.Pause)
            {
                Resume();
            }
            else if (_scenceState == ScenceState.Play)
            {
                Pause();
            }
        }
        public void Pause()
        {
            _scenceState = ScenceState.Pause;
            Time.timeScale = 0;
            _characterReader.OnDisablePlayerInput();
            if (_pauseMune == null) _pauseMune = Instantiate(_pauseMuneControllerfabs, _pauseMuneTransfrom);
            _pauseMune.Show();
        }
        public void Resume()
        {
            _scenceState = ScenceState.Play;
            Time.timeScale = 1;
            _characterReader.OnEnablePlayerInput();
            _pauseMune.Hide();
        }

        private void OnTriggerDamageEnter(character character, DamageTrigger damageTrigger)
        {
            Debug.Log("OnTriggerDamageEnter");
            character.ReceiveDamage(damageTrigger._damage);
        }
    }
}