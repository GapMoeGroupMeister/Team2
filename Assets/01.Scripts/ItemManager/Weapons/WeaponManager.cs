using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    //Managers
    private GameManager _gameManager;
    
    [SerializeField] private List<Weapon> _weaponPrefabs = new List<Weapon>();
    [SerializeField] private List<Weapon> _weaponObjList = new List<Weapon>();
    [SerializeField] private Weapon _curWeapon;
    public int currentWeapon;
    public Transform WeaponTrm { get; private set; }
    
    private PlayerController player;

    public void Init(Transform weaponTrm)
    {
        _gameManager = GameManager.Instance;
        player = _gameManager.PlayerController;
        WeaponTrm = weaponTrm;
        WeaponInit();
    }

    private void WeaponInit()
    {
        for (int i = 0; i < _weaponPrefabs.Count; ++i)
        {
            Weapon weapon = Instantiate(_weaponPrefabs[i]);
            _weaponObjList.Add(weapon);
            weapon.transform.SetParent(WeaponTrm);
            weapon.transform.localPosition = Vector3.zero;
            weapon.gameObject.SetActive(i==0);
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
