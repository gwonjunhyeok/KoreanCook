using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    public float rotationSpeed = 270f; // 초당 회전 속도
    private Quaternion initialRotation;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        Vector3 moveDir = Vector3.zero;
        float currentY = transform.eulerAngles.y;
        float initialY = initialRotation.eulerAngles.y;
        moveDir = transform.forward;
        // 현재 회전량 (-180 ~ 180)
        float deltaY = Mathf.DeltaAngle(initialY, currentY);

        // 오른쪽 회전
        if (Input.GetKey(KeyCode.D))
        {
            if (deltaY < 90f)
            {
                transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }
            else
            {
                Vector3 newPosition = rb.position + moveDir.normalized * 3f * Time.fixedDeltaTime;
                rb.MovePosition(newPosition);
            }
        }

        // 왼쪽 회전
        if (Input.GetKey(KeyCode.A))
        {
            if (deltaY > -90f)
            {
                transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
            }
            else
            {
                Vector3 newPosition = rb.position + moveDir.normalized * 3f * Time.fixedDeltaTime;
                rb.MovePosition(newPosition);
            }
        }
    }
}
