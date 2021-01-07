using UnityEngine;

public class Storage
{
    private static Storage Instance;

    private Storage() { }

    public static Storage GetStorage()
    {
        if (Instance == null)
        {
            Instance = new Storage();
        }

        return Instance;
    }

    public int getBlobCount()
    {
        return PlayerPrefs.GetInt("BlobCount", 0);
    }

    public void SetBlobCount(int c)
    {
        PlayerPrefs.SetInt("BlobCount", c);
    }

    public void AddBlobCount(int add)
    {
        int originalCount = getBlobCount();
        PlayerPrefs.SetInt("BlobCount", originalCount + add);
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    public void SetCurrentLevel(int l)
    {
        PlayerPrefs.SetInt("CurrentLevel", l);
    }

    // Recipes unlocked: [Orange Juice(0), Hot Chocolate(1), Strawberry Smoothie(2), Cucumber Maki(3),
    // Salmon Gunkan(4), California Roll(5), Burger(6), Hotdog(7), Sandwich(8), bonus recipe(9)]
    public bool getRecipeUnlocked(int key) // key range from 0 to 9 only
    {
        return PlayerPrefs.GetInt("RecipeUnlocked" + key, 0) == 0 ? false : true;
    }

    public void SetReceipeUnlocked(int key)
    {
        PlayerPrefs.SetInt("RecipeUnlocked" + key, 1);
    }
}
