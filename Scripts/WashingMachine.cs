using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : MonoBehaviour, InteractableObject
{
    public GameObject prompt;
    public float waterAmount = -20f; // ���ӵ�ˮ��ֵ
    public float requiredWater = 20f;
    public CurrentWater water;
    public CurrentDirtyWater dirtyWater;
    public string confirmMessage = "Do you want to spend 20L water washing your clothes?";
    public ErrorWarning warning;
    public string ConfirmMessage
    {
        get { return confirmMessage; }
    }
    public void Interact(GameObject player)
    {
        // �������ˮ��������ˮԴ����

        SimpleSampleCharacterControl status = player.GetComponent<SimpleSampleCharacterControl>();
        if (status != null)
        {
            if (water.currentWater >= requiredWater)
            {
                water.ChangeWater(waterAmount);
                dirtyWater.ChangeWater(-waterAmount);
                //status.currentWater = Mathf.Clamp(status.currentWater, 0f, status.maxWater);
                if (prompt != null)
                {
                    Destroy(prompt);
                }
            }
            else
            {
                warning.showError();
                Debug.Log("No Enough Water");
            }
        }
    }
    public void Show(GameObject prompt)
    {
        //������ĳ�����弤����ǽ��ã�������prompt��Ҳ�����Ǹ�ͼ��
        //����ʱ���������������嶼����ã���������Ľű���������ܷ���
        if (prompt != null)
        {
            prompt.SetActive(true);
        }

    }
    public void Hide(GameObject prompt)
    {
        if (prompt != null)
        {
            prompt.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)//�Ӵ�ʱ�������������
    {
        Show(prompt);
    }
    void OnTriggerStay(Collider other)    //ÿ֡����һ��OnTriggerStay()����
    {

    }
    void OnTriggerExit(Collider other)
    {
        Hide(prompt);
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide(prompt);
    }

    // Update is called once per frame
    void Update()
    {

    }
}