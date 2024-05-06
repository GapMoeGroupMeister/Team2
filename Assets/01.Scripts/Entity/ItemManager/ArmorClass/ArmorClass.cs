using UnityEngine;
using UnityEngine.UI;

public class ArmorClass : MonoBehaviour
{
    [SerializeField] private Slider _armorBar;
    private int _armor;
    private float restoreBar = 0.7f;
    private bool _attackDelay = false;

    public int armor
    {
        get => _armor;
        private set => _armor = Mathf.Clamp(value, 0, _armor);
    }

    private void Awake()
    {
        _armor = 100;
        SetMaxArmor(_armor);
        _armorBar.value += restoreBar * Time.deltaTime;
    }

    private void SetMaxArmor(float armor)
    {
        _armorBar.maxValue = armor;
        _armorBar.value = armor;
    }

    public void GetDamage(int damage)
    {
        int getDamageArmor = armor - damage;
        armor = getDamageArmor;
        _armorBar.value = armor;
    }

    public void Update()
    {
        armor = 100;
        _armorBar.value += restoreBar * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) GetDamage(20);
    }
}