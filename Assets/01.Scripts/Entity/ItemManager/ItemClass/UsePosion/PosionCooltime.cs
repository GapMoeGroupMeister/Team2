using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosionCooltime : MonoBehaviour
{
    [SerializeField] private GameObject hideimg;
    [SerializeField] private float hideimageFill;
    private bool isUsed;
    private float cooltime;

    public void Start()
    {
        hideimageFill = GetComponent<Image>().fillAmount;
        hideimageFill = 0;
        cooltime = GetComponent<PosionUsing>().coolTime;
        hideimg.SetActive(false);
    }


    private void Update()
    {
        if (isUsed == true)
        {
            if(cooltime > 0)
            {
                hideimageFill += Time.deltaTime / cooltime;
            }
            if(cooltime <= 0)
            {
                isUsed = false;
                hideimg.SetActive(false);
                cooltime = 0;
            }
            
        }


    }
    private void ClickBtn()
    {
        hideimg.SetActive(true);
        isUsed = true;
        hideimageFill = 0;
    }
}