using UnityEngine;
public class PlayerMotor : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] EntityMovement movement;
    [SerializeField] PlayerHealth playerHealth;

    [Space(10)]
    // RSO
    [SerializeField] RSO_MainCamera rsoCam;
    // RSF
    // RSP

    [Header("Input")]
    [SerializeField] RSE_ResetLevel rseResetLevel;
    //[Header("Output")]

    Vector3 moveInput;

    private void OnEnable()
    {
        rseResetLevel.action += ResetPlayer;
    }
    private void OnDisable()
    {
        rseResetLevel.action -= ResetPlayer;
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

    void ResetPlayer()
    {
        Debug.Log("Reset Player");
        movement.UnLockMovement();
        movement.Teleport();
        playerHealth.SetupHealth();
    }
}