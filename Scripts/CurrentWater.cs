using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentWater : MonoBehaviour
{
    public float currentWater = 10.0f;
    public float maxWater = 100.0f;
    public Image water;
    // Start is called before the first frame update
    void Start()
    {
        Amount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeWater(float amount)
    {
        currentWater += amount;
        Amount();
    }
    public void Amount()
    {
        water.fillAmount = currentWater / maxWater;
    }

}
