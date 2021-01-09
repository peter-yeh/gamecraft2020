using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;

    private int count1;
    private int count2;
    private int count3;
    private int count4;
    private int count5;

    // Start is called before the first frame update
    void Start()
    {
        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        count5 = 0;
    }

    public void add(int foodId)
    {
        switch (foodId)
        {
            case 1: // Orange, Rice, Bun, Flour
                count1++;
                text1.text = "x" + count1.ToString();
                break;
            case 2: // Chocolate, Seaweed, Lettuce, Egg
                count2++;
                text2.text = "x" + count2.ToString();
                break;
            case 3: // Milk, Cucumber, Meat, Chocolate
                count3++;
                text3.text = "x" + count3.ToString();
                break;
            case 4: // Ice, Salmon, Ketchup, Milk
                count4++;
                text4.text = "x" + count4.ToString();
                break;
            case 5: // Strawberry, Avocado, Cheese, Butter
                count5++;
                text5.text = "x" + count5.ToString();
                break;
        }
    }
}
