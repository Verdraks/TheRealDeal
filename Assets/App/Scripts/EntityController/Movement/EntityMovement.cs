using UnityEngine;
public class EntityMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveSpeed;
    
    [Header("References")]
    [SerializeField] Rigidbody rb;

    private RigidbodyConstraints constraints;
    
    //[Space(10)]
    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void Start()
    {
        constraints = rb.constraints;
    }

    public void Move(Vector3 input)
    {
        rb.velocity = input * moveSpeed;
    }

    public void LockMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    public void UnLockMovement()
    {
        rb.constraints = constraints;
    }

    public void Teleport()
    {
        rb.position = new Vector3(0, 1, 0);
    }
}