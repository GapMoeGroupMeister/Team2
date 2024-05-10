using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager _gameManager;
    private DefaultHealthSystem _defaultHealthSystem;
    [SerializeField] private GameObject _hp;
    

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _defaultHealthSystem = GetComponent<DefaultHealthSystem>();
        _defaultHealthSystem.hpChangeEvent.AddListener(HPCheck);
    }
    
    private void HPCheck()
    {
        _hp.transform.localScale = new Vector3(_defaultHealthSystem.Hp / _defaultHealthSystem.maxHp, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (_defaultHealthSystem.Hp <= 0)
                SceneManager.LoadScene("DieScene");
            _defaultHealthSystem.Hp -= enemy._damage;
        }
    }
}
