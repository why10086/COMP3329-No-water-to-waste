using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bathtub : MonoBehaviour, InteractableObject
{
    public GameObject prompt;
    public float waterAmount = -20f; // 增加的水量值
    public float requiredWater = 20f;
    public CurrentWater water;
    public string confirmMessage = "Do you want to spend 20L water taking a shower?";
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
            if (water.currentWater >= requiredWater)
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
                warning.showError();
                Debug.Log("No Enough Water");
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
        if (prompt != null)
        {
            Show(prompt);
        }
    }
    void OnTriggerStay(Collider other)    //每帧调用一次OnTriggerStay()函数
    {

    }
    void OnTriggerExit(Collider other)
    {
        if (prompt != null)
        {
            Hide(prompt);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (prompt != null)
        {
            Hide(prompt);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}