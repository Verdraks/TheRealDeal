using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] Slider healthSlider;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    public void UpdateVisual(int currentValue, int maxValue)
    {
        healthSlider.maxValue = maxValue;
        healthSlider.value = currentValue;
    }

    public void UpdatePosition(Vector2 position)
    {
        transform.position = position;
    }
}