using UnityEngine;
using UnityEngine.UI;
public class PlayerStaminaUI : PlayerMovement
{

    public Slider staminaUi;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        staminaUi.value = currentStamina / fullStamina;
    }
}
