using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartMusic : MonoBehaviour
{
    void Start() {
        Destroy(GameObject.Find("BgMusic"));
    }
}
