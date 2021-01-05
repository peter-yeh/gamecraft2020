using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    [SerializeField] private Button level2Button;
    [SerializeField] private Image level2Lock;

    [SerializeField] private Button level3Button;
    [SerializeField] private Image level3Lock;

    public void UnlockLevel2()
    {
        level2Button.interactable = true;
        level2Lock.enabled = false;
    }

    public void UnlockLevel3()
    {
        level3Button.interactable = true;
        level3Lock.enabled = false;
    }
}
