using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Null,
    Able,
    DisAble,
}

public class CellManager : MonoBehaviour
{
    public GameObject demo_cell;
    public int ground_w = 0;
    public int ground_h = 0;

    void Start()
    {
        if (ground_w < 10 || ground_h < 10)
        {
            return;
        }

        for (int i = 0; i < ground_w / 10; i++)
        {
            for (int j = 0; j < ground_h / 10; j++)
            {
                GameObject obj = Instantiate(demo_cell, transform);
                obj.transform.localPosition = new Vector3(i * 10 - ground_w / 2 + 5, 0.501f, ground_h / 2 - 5 - j * 10);
                obj.transform.name = i + " " + j;
            }
        }
    }

    void Update()
    {
        //Vector3 pos = Camera.main.WorldToScreenPoint(GameObject.Find("Main Camera").transform.position);//将对象坐标换成屏幕坐标
        //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);//让鼠标的屏幕坐标与对象坐标一致
        ////transform.position = Camera.main.ScreenToWorldPoint(mousePos);//将正确的鼠标屏幕坐标换成世界坐标交给物体
        //Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
    }

    private void OnValidate()
    {
        //if(ground_w < 10 || ground_h < 10)
        //{
        //    return;
        //}

        //for(int i = 0; i < ground_w / 10; i++)
        //{
        //    for (int j = 0; j < ground_h / 10; j++)
        //    {
        //        GameObject obj = Instantiate(demo_cell, transform);
        //        obj.transform.localPosition = new Vector3(i * 10 - ground_w / 2 + 5, 0.501f, ground_h / 2 - 5 - j * 10);
        //    }
        //}
    }
}
