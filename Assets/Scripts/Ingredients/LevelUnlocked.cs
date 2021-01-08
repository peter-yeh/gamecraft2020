using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocked
{

    private int multiple = 3;

    private LevelUnlocked() { }

    /// Returns a list of integers, 0,1,2,3,4,5,6,7,8
    /// Each int corresponds to recipe unlocked for that particular level
    public static List<int> Unlock(int[] ingredientsBasket, int currLevel)
    {
        switch (currLevel)
        {
            case 1:
                return new LevelUnlocked().UnlockLevel1(ingredientsBasket);
            case 2:
                return new LevelUnlocked().UnlockLevel2(ingredientsBasket);
            case 3:
                return new LevelUnlocked().UnlockLevel3(ingredientsBasket);
            case 4:
                return new LevelUnlocked().UnlockLevel4(ingredientsBasket);
            default:
                Debug.LogError("Wrong level given in Scripts/LevelUnlocked");
                return null;
        }
    }

    // Orange, Chocolate, Milk, Ice, Strawberry
    private List<int> UnlockLevel1(int[] ingredientsBasket) // drinks theme
    {
        Storage s = Storage.GetStorage();
        List<int> l = new List<int>();

        if (!s.getRecipeUnlocked(0)) // if orange juice is not unlocked
        {
            // checks if there's enogh ingredients to unlock orange juice
            if (ingredientsBasket[0] >= multiple && // orange
             ingredientsBasket[3] >= multiple) // ice
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[3] -= multiple;
                s.SetReceipeUnlocked(0); // unlocked orange juice
                l.Add(0);
                s.AddBlobCount();
            }
            else
            { // do nothing since not enough ingredients
            }
        }

        if (!s.getRecipeUnlocked(1))
        {
            if (ingredientsBasket[1] >= multiple && // chocolate
                ingredientsBasket[2] >= multiple) // milk
            {
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[2] -= multiple;
                s.SetReceipeUnlocked(1); // unlocked hot chocolate
                s.AddBlobCount();
                l.Add(1);
            }
        }

        if (!s.getRecipeUnlocked(2))
        {
            if (ingredientsBasket[2] >= multiple && // milk
                ingredientsBasket[3] >= multiple && // ice
                ingredientsBasket[4] >= 5) // strawberry
            {
                ingredientsBasket[2] -= multiple;
                ingredientsBasket[3] -= multiple;
                ingredientsBasket[4] -= 5;
                s.SetReceipeUnlocked(2); // unlocked strawberry smoothie
                s.AddBlobCount();
                l.Add(2);
            }
        }

        return l;
    }

    // Rice, seaweed, cucumber, salmon, avocado
    private List<int> UnlockLevel2(int[] ingredientsBasket) // sushi theme
    {
        Storage s = Storage.GetStorage();
        List<int> l = new List<int>();

        if (!s.getRecipeUnlocked(3)) // if orange juice is not unlocked
        {
            // checks if there's enogh ingredients to unlock orange juice
            if (ingredientsBasket[0] >= multiple && // rice
             ingredientsBasket[1] >= multiple && // seaweed
             ingredientsBasket[2] >= multiple) // cucumber
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[2] -= multiple;
                s.SetReceipeUnlocked(3); // unlocked cucumber maki
                s.AddBlobCount();
                l.Add(3);
            }
            else
            { // do nothing since not enough ingredients
            }
        }

        if (!s.getRecipeUnlocked(4))
        {
            if (ingredientsBasket[0] >= multiple && // rice
                ingredientsBasket[1] >= multiple && // seaweed
                ingredientsBasket[3] >= multiple) // salmon
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[3] -= multiple;
                s.SetReceipeUnlocked(4); // unlocked salmon gunkan
                s.AddBlobCount();
                l.Add(4);
            }
        }

        if (!s.getRecipeUnlocked(5))
        {
            if (ingredientsBasket[0] >= multiple && // rice
                ingredientsBasket[1] >= multiple && // seaweed
                ingredientsBasket[3] >= multiple && // salmon
                ingredientsBasket[4] >= 5) // avocado
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[3] -= multiple;
                ingredientsBasket[4] -= 5;
                s.SetReceipeUnlocked(5); // unlocked california roll
                s.AddBlobCount();
                l.Add(5);
            }
        }

        return l;
    }

    // Bun, Lettuce, Meat, Ketchup, Cheese
    private List<int> UnlockLevel3(int[] ingredientsBasket) // burger theme
    {
        Storage s = Storage.GetStorage();
        List<int> l = new List<int>();

        if (!s.getRecipeUnlocked(6)) // if orange juice is not unlocked
        {
            // checks if there's enogh ingredients to unlock orange juice
            if (ingredientsBasket[0] >= multiple && // Bun
             ingredientsBasket[1] >= multiple && // Lettuce
             ingredientsBasket[2] >= multiple && // Meat
             ingredientsBasket[3] >= multiple && // Ketchup
             ingredientsBasket[4] >= 5) //  Cheese
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[2] -= multiple;
                ingredientsBasket[3] -= multiple;
                ingredientsBasket[4] -= 5;

                s.SetReceipeUnlocked(6); // unlocked burger
                s.AddBlobCount();
                l.Add(6);
            }
            else
            { // do nothing since not enough ingredients
            }
        }

        if (!s.getRecipeUnlocked(7))
        {
            if (ingredientsBasket[0] >= multiple && // bun
                ingredientsBasket[2] >= multiple && // meat
                ingredientsBasket[3] >= multiple) // ketchup
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[2] -= multiple;
                ingredientsBasket[3] -= multiple;
                s.SetReceipeUnlocked(7); // unlocked hotdog
                s.AddBlobCount();
                l.Add(7);
            }
        }

        if (!s.getRecipeUnlocked(8))
        {
            if (ingredientsBasket[0] >= multiple && // bun
                ingredientsBasket[1] >= multiple && // lettuce
                ingredientsBasket[3] >= multiple && // ketchup
                ingredientsBasket[4] >= 5) // cheese
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[3] -= multiple;
                ingredientsBasket[4] -= 5;
                s.SetReceipeUnlocked(8); // unlocked sandwich
                s.AddBlobCount();
                l.Add(8);
            }
        }

        return l;
    }

    // Flour, Egg, Chocolate, Milk, Butter
    private List<int> UnlockLevel4(int[] ingredientsBasket) // cake theme
    {
        Storage s = Storage.GetStorage();
        List<int> l = new List<int>();

        if (!s.getRecipeUnlocked(9)) // if cake is not unlocked
        {
            // checks if there's enogh ingredients to unlock cake
            if (ingredientsBasket[0] >= multiple && // Flour
             ingredientsBasket[1] >= multiple && // Egg
             ingredientsBasket[2] >= multiple && // Chocolate
             ingredientsBasket[3] >= multiple && // Milk
             ingredientsBasket[4] >= multiple) //  Butter
            {
                ingredientsBasket[0] -= multiple;
                ingredientsBasket[1] -= multiple;
                ingredientsBasket[2] -= multiple;
                ingredientsBasket[3] -= multiple;
                ingredientsBasket[4] -= multiple;

                s.SetReceipeUnlocked(9); // unlocked cake
                s.AddBlobCount();
                l.Add(9);
            }
            else
            { // do nothing since not enough ingredients
            }
        }

        return l;
    }

}
