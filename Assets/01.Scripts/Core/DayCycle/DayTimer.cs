using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayTimer : MonoBehaviour
{
    private Slider Timer;
    private float remainTime;

    private void Start()
    {
        Timer = GetComponent<Slider>();
    }

    private void Update()
    {
        remainTime += Time.deltaTime;
        Timer.value = remainTime;

        if (remainTime == 5)
        {
            Time.timeScale = 0f;
        }
    }
}
