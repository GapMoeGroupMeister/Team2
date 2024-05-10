using UnityEngine;

public class WeaponAttackable : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy;
    private Weapon _parent;

    private void OnEnable()
    {
        _parent = GetComponentInParent<Weapon>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("공격");
            if (other.TryGetComponent(out DefaultHealthSystem healthSystem))
            {
                healthSystem.Hp -= _parent.attackValue;
            }
        }
    }
}
