using UnityEngine;
using UnityEngine.UI;

namespace UD
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] character _character;
        [SerializeField] Image _image;

        public void Bind(character _character)
        {
            if (_character != null) _character.CharacterHealth.OnHealthChanged -= UpdateHealth;
            this._character = _character;
            _character.CharacterHealth.OnHealthChanged += UpdateHealth;
        }

        void UpdateHealth(float amountChange)
        {
            float precent = _character.CharacterHealth.CurrentHealth / _character.CharacterHealth.MaxHealth;
            _image.fillAmount = precent;
        }
    }
}