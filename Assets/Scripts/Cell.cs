using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public CellType cellType  = CellType.Null;

    void Start()
    {
        
    }

    public void setCellType(CellType _cellType)
    {
        cellType = _cellType;

        switch(cellType)
        {
            case CellType.Null:
                {
                    Material _Material = CommonUtil.GetMaterial("Materials/cell_yellow");
                    GetComponent<MeshRenderer>().material = _Material;
                    break;
                }

            case CellType.Able:
                {
                    Material _Material = CommonUtil.GetMaterial("Materials/cell_blue");
                    GetComponent<MeshRenderer>().material = _Material;
                    break;
                }

            case CellType.DisAble:
                {
                    Material _Material = CommonUtil.GetMaterial("Materials/cell_red");
                    GetComponent<MeshRenderer>().material = _Material;
                    break;
                }
        }
    }

    void OnMouseEnter()
    {
        setCellType(CellType.Able);
    }

    void OnMouseExit()
    {
        setCellType(CellType.Null);
    }
}
