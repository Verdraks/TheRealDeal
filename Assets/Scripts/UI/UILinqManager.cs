using UnityEngine;
public class UILinqManager : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] Transform healthBarContent;

    [Space(10)]
    [SerializeField] HealthBar healthBarPrefab;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    [Header("Input")]
    [SerializeField] RSE_CreateHealthBar rseCreatehealthBar;

    //[Header("Output")]

    private void OnEnable()
    {
        rseCreatehealthBar.action += CreateHealthBar;
    }
    private void OnDisable()
    {
        rseCreatehealthBar.action -= CreateHealthBar;
    }

    public void CreateHealthBar(RSO_HealthBar rsoHealthBar)
    {
        rsoHealthBar.Value = Instantiate(healthBarPrefab, healthBarContent);
    }
}