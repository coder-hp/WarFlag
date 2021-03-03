using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    public CellScript standCellScript = null;

    private void Awake()
    {
        MapItemManager.list_item.Add(this);
    }

    void Start()
    {
        
    }

    public void setPos(CellScript _cellScript)
    {
        standCellScript = _cellScript;
        standCellScript.setCellType(CellType.DisAble);
        transform.position = new Vector3(standCellScript.transform.position.x, 1, standCellScript.transform.position.z);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Cell"))
    //    {
    //        other.GetComponent<Cell>().setCellType(CellType.Able);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.CompareTag("Cell"))
    //    {
    //        other.GetComponent<Cell>().setCellType(CellType.Null);
    //    }
    //}
}
