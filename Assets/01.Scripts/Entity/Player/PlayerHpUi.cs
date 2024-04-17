using UnityEngine.UI;

public class PlayerHpUi : Player
{

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
        hpUi.value = healthSytem.HP / fullHp;
    }
}
