using UnityEngine;
public abstract class EntityHealth : MonoBehaviour, ITakeDamage
{
    [Header("Settings")]
    [SerializeField] int maxHealth;
    int currentHealth;

    //[Header("References")]

    //[Space(10)]
    // RSO

    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    void Start()
    {
        SetupHealth();

        OnStart();
    }
    public abstract void OnStart();

    void Update()
    {
        OnUpdate();
    }
    public abstract void OnUpdate();

    void SetupHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }

        OnTakeDamage(currentHealth, maxHealth);
    }
    public abstract void OnTakeDamage(int currentHealth, int maxHealth);

    void Die()
    {
        OnDie();
    }
    public abstract void OnDie();
}