using UnityEngine;

public class Storage
{
    private static Storage Instance;
    public int[] ingredientBasket = new int[5];

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
    // Salmon Nigiri(4), California Roll(5), Burger(6), Hotdog(7), Sandwich(8), bonus recipe(9)]
    public bool getRecipeUnlocked(int key) // key range from 0 to 9 only
    {
        return PlayerPrefs.GetInt("RecipeUnlocked" + key, 0) == 0 ? false : true;
    }

    public void SetReceipeUnlocked(int key)
    {
        PlayerPrefs.SetInt("RecipeUnlocked" + key, 1);
    }

    public bool IsLevelUnlocked(int i)
    {
        return PlayerPrefs.GetInt("LevelUnlocked" + i, 0) == 0 ? false : true;
    }

    public void SetLevelUnlocked(int i)
    {
        PlayerPrefs.SetInt("LevelUnlocked" + i, 1);
    }

    public bool hasCompleted9Recipes()
    {
        return PlayerPrefs.GetInt("TotalRecipes", 0) == 1;
    }

    public void setCompleted9Recipes()
    {
        PlayerPrefs.SetInt("TotalRecipes", 1);
    }

    public bool hasVideoPlayed()
    {
        return PlayerPrefs.GetInt("VideoPlayed", 0) == 1;
    }

    public void setVideoPlayed()
    {
        PlayerPrefs.SetInt("VideoPlayed", 1);
    }
}
