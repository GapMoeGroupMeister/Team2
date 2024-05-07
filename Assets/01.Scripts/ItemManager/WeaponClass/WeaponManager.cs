using System;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    //Managers
    private GameManager _gameManager;
    
    [SerializeField] protected Weapon[] weaponPrefabs;
    [SerializeField] protected Weapon[] weaponObjs = new Weapon[5];
    [SerializeField] private Weapon _curWeapon;
    public int currentWeapon;
    [SerializeField] private Transform _weaponTrm;
    
    private PlayerController player;

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        player = _gameManager.PlayerController;
    }

    private void WeaponInit()
    {
        weaponObjs = new Weapon[weaponPrefabs.Length];
        
        for (int i = 0; i < weaponPrefabs.Length; ++i)
        {
            weaponObjs[i] = Instantiate(weaponPrefabs[i], _weaponTrm);
            weaponObjs[i].gameObject.SetActive(i==0);
        }
    }
    
    public void ChangeWeapon()
    {
        currentWeapon++;
    }
    
    public Weapon GetCurrentWeapon()
    {
        return _curWeapon;
    }
}
