using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private float _duration = 1;
    private float _targetValue;


    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.value = 0;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _targetValue = (float)currentHealth / maxHealth;

        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        while (_targetValue != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
