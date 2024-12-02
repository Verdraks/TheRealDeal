using UnityEngine;
public class EntityMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    
    [Header("References")]
    [SerializeField] Rigidbody rb;

    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    public void Move(Vector3 input)
    {
        rb.velocity = input * moveSpeed;
    }

    public void LockMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}