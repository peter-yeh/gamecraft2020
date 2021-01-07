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


    public void Start()
    {
        // if level 2 unlocked, Unlockleve2()
        // if level 3 unlocke, UnlockLevel3()

        if (Storage.GetStorage().IsLevelUnlocked(2))
        {
            UnlockLevel2();
        }
        if (Storage.GetStorage().IsLevelUnlocked(3))
        {
            UnlockLevel3();
        }
    }

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
