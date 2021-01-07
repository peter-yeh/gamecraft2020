using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSelect : MonoBehaviour
{
    [SerializeField] private Image bg;
    [SerializeField] private Sprite level1Passed;
    [SerializeField] private Sprite level2Passed;
    [SerializeField] private Sprite level3Passed;
    [SerializeField] private Sprite level4Passed; //bonus level

    // Update is called once per frame
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
