using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [Header("References")]
    [SerializeField] HorizontalLayoutGroup container;
    List<Image> hearts = new();
    
    [Header("Input")]
    [SerializeField] private RSE_CreateHealthBar rseCreateHealthBar;

    /// <summary>
    /// Update visual Hearts, link to current health
    /// </summary>
    /// <param name="currentValue"></param>
    /// <param name="maxValue"></param>
    public void UpdateVisual(int currentValue, int maxValue)
    {
       
        SetupVisual(ref maxValue);
        
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].sprite = i+1 <= currentValue ? fullHeart : emptyHeart;
        }
    }

    /// <summary>
    /// Instantiate hearts image if missings or remove, link to max health target
    /// </summary>
    /// <param name="maxValue"></param>
    private void SetupVisual(ref int maxValue)
    {
        if (hearts.Count < maxValue)
        {
            int ecartSize = maxValue - hearts.Count;
            for (int i = 0; i < ecartSize ; i++)
            {
                Image image = new GameObject("Heart").AddComponent<Image>().GetComponent<Image>();
                image.preserveAspect = true;
                image.gameObject.transform.SetParent(container.transform);
                image.transform.localScale = Vector3.one;
                hearts.Add(image);
            }
        }
        else if (hearts.Count > maxValue)
        {
            int ecartSize = hearts.Count - maxValue;
            for (int i = 0; i < ecartSize; i++)
            {
                Destroy(hearts[i].gameObject);
                hearts.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Setup itself into the container of player health for visuel
    /// </summary>
    /// <param name="rsoHealthBar"></param>
    private void Setup(RSO_HealthBar rsoHealthBar) => rsoHealthBar.Value = this;
    private void OnEnable() => rseCreateHealthBar.action += Setup;
    private void OnDisable() => rseCreateHealthBar.action -= Setup;
}