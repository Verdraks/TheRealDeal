using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] EntityMovement movement;

    [Space(10)]
    // RSO
    [SerializeField] RSO_MainCamera rsoCam;
    // RSF
    // RSP

    [Header("Input")]
    [SerializeField] RSE_OnPlayerDeath rseOnPlayerDeath;
    //[Header("Output")]

    Vector3 moveInput;

    private void OnEnable()
    {
        rseOnPlayerDeath.action += OnPlayerDeath;
    }
    private void OnDisable()
    {
        rseOnPlayerDeath.action -= OnPlayerDeath;
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        movement.Move(moveInput);
    }

    void GetInput()
    {
        moveInput = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical"));

        // Rotate input with the camera rotation
        if (moveInput.magnitude > .1f)
        {
            float targetAngle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg + (rsoCam.Value.transform.eulerAngles.y);
            moveInput = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        }
        else
        {
            moveInput = Vector3.zero;
        }
    }

    void OnPlayerDeath()
    {
        movement.LockMovement();
    }
}