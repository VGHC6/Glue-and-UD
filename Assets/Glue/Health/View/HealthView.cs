using UnityEngine;
using UnityEngine.UI;

namespace GLUE
{
    public class HealthView : MonoBehaviour
    {
        public Health _health;
        public Image _fill;

        private void Start()
        {
            _health.OnHealthChanged += UpDateBar;
        }

        public void UpDateBar(float amontChange)
        {
            float precent = _health.CurrentHealth / _health.MaxHealth;
            _fill.fillAmount = precent;
        }
    }
}