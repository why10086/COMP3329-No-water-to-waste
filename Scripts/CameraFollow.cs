using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 相机要跟随的目标
    public float distance = 5f; // 相机与目标的距离
    public float height = 3f; // 相机距离目标的高度
    public float rotationSpeed = 100f; // 视角转动速度

    private float currentRotation = 0f;

    private void LateUpdate()
    {
        // 计算相机的位置和旋转角度
        float desiredRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        currentRotation += desiredRotation;

        Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);
        position.y = target.position.y + height;

        // 将相机移动和旋转到正确的位置和角度
        transform.position = position;
        transform.rotation = rotation;
    }
}