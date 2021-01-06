using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecipeImage : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] GameObject recipe;

    private Image image;
    private Color imageColor;

    void Start()
    {
        image = GetComponent<Image>();
        imageColor = image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 1);
        recipe.SetActive(true);
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = imageColor;
        recipe.SetActive(false);
        Debug.Log("Mouse Exit");
    }
}
