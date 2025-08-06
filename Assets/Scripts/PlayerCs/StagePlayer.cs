using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    public float rotationSpeed = 270f; // �ʴ� ȸ�� �ӵ�
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
        // ���� ȸ���� (-180 ~ 180)
        float deltaY = Mathf.DeltaAngle(initialY, currentY);

        // ������ ȸ��
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

        // ���� ȸ��
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
