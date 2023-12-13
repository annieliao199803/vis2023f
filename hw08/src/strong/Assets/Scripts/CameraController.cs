using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;  // 相機移動速度
    public float rotationSpeed = 2f;  // 相機旋轉速度

    void Update()
    {
        // 相機移動
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // 相機旋轉
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed;
        transform.eulerAngles += rotation;

        // 限制上下旋轉角度在 -90 到 90 之間
        float currentXRotation = transform.eulerAngles.x;
        if (currentXRotation > 180f)
        {
            currentXRotation -= 360f;
        }
        float clampedXRotation = Mathf.Clamp(currentXRotation, -90f, 90f);
        transform.eulerAngles = new Vector3(clampedXRotation, transform.eulerAngles.y, 0f);
    }
}
