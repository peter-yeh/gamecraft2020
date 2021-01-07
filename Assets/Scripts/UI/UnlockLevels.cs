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

    [SerializeField] private Button level4Button;

    [SerializeField] private GameObject[] foods;

    [SerializeField] private Image bg;
    [SerializeField] private Sprite level1Passed;
    [SerializeField] private Sprite level2Passed;
    [SerializeField] private Sprite level3Passed;
    [SerializeField] private Sprite level4Passed; //bonus level

    public void Start()
    {
        if (Storage.GetStorage().IsLevelUnlocked(2))
        {
            UnlockLevel2();
            UpdateBackground(1);
        }
        if (Storage.GetStorage().IsLevelUnlocked(3))
        {
            UnlockLevel3();
            UpdateBackground(2);
        }
        if (Storage.GetStorage().IsLevelUnlocked(4))
        {
            UpdateBackground(3);
            if (Storage.GetStorage().hasCompleted8Recipes())
            {
                UnlockLevel4();
            }
        }
        if (Storage.GetStorage().IsLevelUnlocked(5))
        {
            UpdateBackground(4);
        }
        InitialiseFoods();
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

    public void UnlockLevel4()
    {
        level4Button.gameObject.SetActive(true);
    }

    private void InitialiseFoods()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Storage.GetStorage().getRecipeUnlocked(i))
            {
                foods[i].GetComponent<Image>().color = new Color(255, 255, 255);
            }
        }
    }

    public void UpdateBackground(int level)
    {
        switch (level)
        {
            case 1:
                bg.sprite = level1Passed;
                break;
            case 2:
                bg.sprite = level2Passed;
                break;
            case 3:
                bg.sprite = level3Passed;
                break;
            case 4:
                bg.sprite = level4Passed;
                break;
        }
    }
}
