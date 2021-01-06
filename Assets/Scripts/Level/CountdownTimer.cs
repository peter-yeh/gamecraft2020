using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime;
    private float startingTime = 60f;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime == 60)
        {
            countdownText.text = "01:00";
            return;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        countdownText.text = "00:" + currentTime.ToString("0");
    }
}
