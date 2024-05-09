using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowMuchDefeat : MonoBehaviour
{
    [SerializeField] public int defeat = 0;
    private PlayerHpUi nowHp;

    private void Awake()
    {
        nowHp = GetComponent<PlayerHpUi>();
        defeat = PlayDataManager.Instance.playData._losingStack;
    }

    public void pressBtn()
    {

        defeat++;
    }

    public void Reset()
    {
        defeat = 0;
    }

    private void Update()
    {
        if (nowHp.currentHp <= 0)
        {
            defeat++;
        }
        
    }
}
