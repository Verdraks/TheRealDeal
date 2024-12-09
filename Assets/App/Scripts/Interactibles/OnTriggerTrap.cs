using UnityEngine;
public class OnTriggerTrap : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITakeDamage takeDamage))
        {
            gameObject.SetActive(false);
            takeDamage.TakeDamage(damage);
        }
    }

    public void ResetTrap()
    {
        gameObject.SetActive(true);
    }
}