using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpUI : Enemy
{
    protected Slider HpSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        
        HpSlider = GetComponent<Slider>();
        Instantiate(HpSlider);
    }

    // Update is called once per frame
    void Update()
    {// -960, -540 : 0, 0
        transform.position = Camera.main.WorldToScreenPoint(Owner.transform.position + new Vector3(0, 0.8f, 0));
        
        HpSlider.value = EnemyHealth.HP / 100;
    }
}
