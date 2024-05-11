using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameManager _gameManager;
    private UIManager _uiManager;
    private DefaultHealthSystem _defaultHealthSystem;

    private void Awake()
    {
        //Managements
        _gameManager = GameManager.Instance;
        _uiManager = UIManager.Instance;
        
        //Components        
        _defaultHealthSystem = GetComponent<DefaultHealthSystem>();
        _defaultHealthSystem.hpChangeEvent.AddListener(HPCheck);
    }
    
    private void HPCheck()
    {
        _uiManager.SetHpIcon((int)_defaultHealthSystem.Hp, (int)_defaultHealthSystem.maxHp);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            _defaultHealthSystem.Hp -= enemy._damage;
            if (_defaultHealthSystem.Hp <= 0)
                SceneManager.LoadScene("DieScene");
        }
    }
}
