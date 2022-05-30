using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _currentHealth;
    private int _minHealth = 0;
    private int _maxHealth = 100;
    private int _treatment = 10;
    private int _damage = 10;

    public event UnityAction<int, int> HealthChanged;

    public void AddHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _treatment, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage()
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, _minHealth, _maxHealth);

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
