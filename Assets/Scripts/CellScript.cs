using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public CellType cellType  = CellType.Null;
    public int index_x = 0;
    public int index_z = 0;
    public bool isGrass = false;

    void Start()
    {
        
    }

    public void init(int _index_x,int _index_z)
    {
        index_x = _index_x;
        index_z = _index_z;
        transform.name = index_x + " " + index_z;
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

    private void OnMouseDown()
    {
        if(cellType == CellType.Able)
        {
            HeroScript.s_instance.clearAbleStandCell();
            HeroScript.s_instance.setPos(this);
            HeroScript.s_instance.showAbleStandCell();
        }
    }

    //void OnMouseEnter()
    //{
    //    setCellType(CellType.Able);
    //}

    //void OnMouseExit()
    //{
    //    setCellType(CellType.Null);
    //}
}
