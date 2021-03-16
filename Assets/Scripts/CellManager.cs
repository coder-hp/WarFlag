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
    public static CellManager s_instance = null;

    public GameObject demo_cell;
    public int ground_w = 0;
    public int ground_h = 0;
    
    public Dictionary<string, CellScript> dic_cell = new Dictionary<string, CellScript>();

    private void Awake()
    {
        s_instance = this;
    }

    void Start()
    {
        if (ground_w < 1 || ground_h < 1)
        {
            return;
        }

        for (int i = 0; i < ground_h; i++)
        {
            for (int j = 0; j < ground_w; j++)
            {
                GameObject obj = Instantiate(demo_cell, transform);
                obj.transform.localPosition = new Vector3(j - ground_w / 2 + 0.5f, 0.5f, ground_h / 2 - 0.5f - i);
                obj.GetComponent<CellScript>().init(i,j);
                dic_cell.Add(i+"_"+j, obj.GetComponent<CellScript>());
            }
        }

        HeroScript.s_instance.setPos(dic_cell["25_25"]);
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

    public CellScript getCell(int index_x,int index_z)
    {
        string key = index_x + "_" + index_z;
        if (dic_cell.ContainsKey(key))
        {
            return dic_cell[key];
        }
        Debug.Log("key=" + key);
        return null;
    }
}
