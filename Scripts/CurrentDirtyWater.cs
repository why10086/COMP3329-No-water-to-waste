using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentDirtyWater : MonoBehaviour
{
    public float currentDirtyWater = 0.0f;
    public float maxDirtyWater = 100.0f;
    public Image dirtyWater;
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
        currentDirtyWater += amount;
        Amount();
    }
    public void Amount()
    {
        dirtyWater.fillAmount = currentDirtyWater / maxDirtyWater;
    }

}
