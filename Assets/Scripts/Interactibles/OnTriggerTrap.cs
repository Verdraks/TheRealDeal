using UnityEngine;
public class OnTriggerTrap : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int damage;

    //[Header("References")]

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITakeDamage takeDamage))
        {
            takeDamage.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}