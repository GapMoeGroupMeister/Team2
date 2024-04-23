using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : Enemy
{
    protected Slider HpSlider;
    public HealthSytem healthSytem;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        
        
        HpSlider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {// -960, -540 : 0, 0
        
        
        HpSlider.value = healthSytem.HP / 100;
    }
}
