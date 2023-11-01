using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, InteractableObject
{
    public GameObject prompt;
    public float waterAmount = 50f; // ���ӵ�ˮ��ֵ
    public CurrentWater water;
    public string confirmMessage = "Do you want to get 50L water? Water out of your capacity will be wasted.";
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
            if (water.currentWater+waterAmount <= water.maxWater)
            {
                water.ChangeWater(waterAmount);

                //status.currentWater = Mathf.Clamp(status.currentWater, 0f, status.maxWater);
                if (prompt != null)
                {
                    Destroy(prompt);
                }
            }
            else
            {
                Debug.Log(water.currentWater);
                water.ChangeWater(water.maxWater - water.currentWater);
                Debug.Log(water.currentWater);
                if (prompt != null)
                {
                    Destroy(prompt);
                }
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