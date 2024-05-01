using UnityEngine;
using UnityEngine.UI;

public class PlayerHpUi : MonoBehaviour
{
    protected float fullHp = 20f;
    protected float currentHp = 20f;
    public Slider hpUi;
    
     
    
    void Start()
    {
        
    }

    private void Update()
    {
        CheckHp();
    }
    
    public void CheckHp()
    {
        hpUi.value = currentHp / fullHp;
    }
}
