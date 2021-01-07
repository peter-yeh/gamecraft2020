using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RecipeImage : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] GameObject recipe;
    [SerializeField] private TextMeshProUGUI pun;
    [SerializeField] private string punLine;

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
        pun.text = punLine;
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = imageColor;
        recipe.SetActive(false);
        pun.text = "";
        Debug.Log("Mouse Exit");
    }
}
