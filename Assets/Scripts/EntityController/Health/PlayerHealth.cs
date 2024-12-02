using UnityEngine;
public class PlayerHealth : EntityHealth
{
    [Header("internal Settings")]
    [SerializeField] Vector3 healthBarPosOffset;

    [Space(10)]
    [SerializeField] RSO_MainCamera rsoMainCam;
    RSO_HealthBar healthBar;

    [Space(10)]
    [SerializeField] RSE_CreateHealthBar rseCreateHealthBar;
    [SerializeField] RSE_OnPlayerDeath rseOnplayerDeath;

    public override void OnStart()
    {
        SetupHealthBar();
    }
    void SetupHealthBar()
    {
        healthBar = ScriptableObject.CreateInstance<RSO_HealthBar>();
        rseCreateHealthBar.Call(healthBar);
    }


    public override void OnUpdate()
    {
        healthBar.Value.UpdatePosition(rsoMainCam.Value.WorldToScreenPoint(transform.position + healthBarPosOffset));
    }

    public override void OnTakeDamage(int currentHealth, int maxHealth)
    {
        healthBar.Value.UpdateVisual(currentHealth, maxHealth);
    }

    public override void OnDie()
    {
        rseOnplayerDeath.Call();
    }
}