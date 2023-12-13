using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;  // �۾����ʳt��
    public float rotationSpeed = 2f;  // �۾�����t��

    void Update()
    {
        // �۾�����
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // �۾�����
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed;
        transform.eulerAngles += rotation;

        // ����W�U���ਤ�צb -90 �� 90 ����
        float currentXRotation = transform.eulerAngles.x;
        if (currentXRotation > 180f)
        {
            currentXRotation -= 360f;
        }
        float clampedXRotation = Mathf.Clamp(currentXRotation, -90f, 90f);
        transform.eulerAngles = new Vector3(clampedXRotation, transform.eulerAngles.y, 0f);
    }
}
