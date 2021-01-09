using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Punlines : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pun;

    // Start is called before the first frame update
    void Start()
    {
        pun.text = "";
    }

    public void setPun(string punLine)
    {
        pun.text = punLine;
    }
}
