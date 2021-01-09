using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlobCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    void Start()
    {
        countText.text = Storage.GetStorage().getBlobCount().ToString();
    }
}
