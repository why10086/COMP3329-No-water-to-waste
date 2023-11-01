using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour, InteractableObject
{
    public GameObject prompt;
    public float waterAmount = -10f; // ���ӵ�ˮ��ֵ
    public float requiredWater = 10f;
    public CurrentWater water;
    public CurrentDirtyWater dirtyWater;
    public string confirmMessage = "Do you want to spend 10L dirty water cleaning the floor? Clean water will be used if you don't have enough dirty water.";
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
            if (dirtyWater.currentDirtyWater >= requiredWater)
            {
                dirtyWater.ChangeWater(waterAmount);
                //status.currentWater = Mathf.Clamp(status.currentWater, 0f, status.maxWater);
                if (prompt != null)
                {
                    Destroy(prompt);
                }
            }
            else if (dirtyWater.currentDirtyWater + water.currentWater >= requiredWater)
            {
                dirtyWater.ChangeWater(-dirtyWater.currentDirtyWater);
                water.ChangeWater(dirtyWater.currentDirtyWater - requiredWater);
                if (prompt != null)
                {
                    Destroy(prompt);
                }
            }
            else
            {
                warning.showError();
                Debug.Log("No enough water!");
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