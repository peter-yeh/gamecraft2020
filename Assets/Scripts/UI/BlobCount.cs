using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlobCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    // Update is called once per frame
    void Update()
    {
        countText.text = Storage.GetStorage().getBlobCount().ToString();
    }
}
