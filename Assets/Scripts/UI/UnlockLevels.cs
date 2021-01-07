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
    [SerializeField] private GameObject[] foods;


    public void Start()
    {

        if (Storage.GetStorage().IsLevelUnlocked(2))
        {
            UnlockLevel2();
        }
        if (Storage.GetStorage().IsLevelUnlocked(3))
        {
            UnlockLevel3();
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


}
