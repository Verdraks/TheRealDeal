using UnityEngine;
public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float moveTime;
    [SerializeField] Vector3 posOffset;
    Vector3 velocity;

    [Header("References")]
    [SerializeField] Camera cam;
    [SerializeField] Transform target;

    [Space(10)]
    // RSO
    [SerializeField] RSO_MainCamera rsoMainCam;
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void Awake()
    {
        rsoMainCam.Value = cam;
    }

    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + posOffset, ref velocity, moveTime);
    }
}