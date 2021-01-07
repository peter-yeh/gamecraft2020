using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Range(0, 60)]
    [SerializeField] private int timeLeft = 60;

    [SerializeField] TextMeshProUGUI countdownText;

    private void Start()
    {
        StartCoroutine(CountDown());
        countdownText.text = "01:00"; //hardcoded value, for timer to start with timeLeft instead of 00:00
    }

    private IEnumerator CountDown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1f);
            timeLeft--;

            if (timeLeft <= 9)
            {
                countdownText.text = "00:0" + timeLeft;
            }
            else
            {
                countdownText.text = "00:" + timeLeft;
            }
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().TimeUp();

    }

}
