using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���Ҫ�����Ŀ��
    public float distance = 5f; // �����Ŀ��ľ���
    public float height = 3f; // �������Ŀ��ĸ߶�
    public float rotationSpeed = 100f; // �ӽ�ת���ٶ�

    private float currentRotation = 0f;

    private void LateUpdate()
    {
        // ���������λ�ú���ת�Ƕ�
        float desiredRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        currentRotation += desiredRotation;

        Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);
        position.y = target.position.y + height;

        // ������ƶ�����ת����ȷ��λ�úͽǶ�
        transform.position = position;
        transform.rotation = rotation;
    }
}