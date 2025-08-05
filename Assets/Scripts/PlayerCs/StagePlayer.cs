using UnityEngine;

public class StagePlayer : MonoBehaviour
{
    public float rotationSpeed = 90f; // �ʴ� ȸ�� �ӵ�
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float currentY = transform.eulerAngles.y;
        float initialY = initialRotation.eulerAngles.y;

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
                
            }
        }
    }
}
