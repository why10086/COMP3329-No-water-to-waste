using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour, InteractableObject
{
    public GameObject prompt;
    public float waterAmount = -10f; // 增加的水量值
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
        // 增加玩家水量并销毁水源对象

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
        //用来将某个物体激活或是禁用（这里是prompt，也就是那个图标
        //禁用时这个物体和其子物体都会禁用，包括上面的脚本，在这里很方便
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
    void OnTriggerEnter(Collider other)//接触时触发，无需调用
    {
        Show(prompt);
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
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