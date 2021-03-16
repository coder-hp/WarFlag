using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public static HeroScript s_instance = null;

    public CellScript standCellScript = null;

    List<CellScript> list_ableStandCell = new List<CellScript>();

    private void Awake()
    {
        s_instance = this;
    }

    void Start()
    {
    }
    
    void Update()
    {
        
    }

    public void setPos(CellScript _cellScript)
    {
        standCellScript = _cellScript;
        //transform.position = new Vector3(standCellScript.transform.position.x, 0, standCellScript.transform.position.z);
        transform.position = standCellScript.transform.position;

        if(_cellScript.isGrass)
        {
            transform.Find("body111").GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.4f);
        }
        else
        {
            transform.Find("body111").GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }
    }

    private void OnMouseDown()
    {
        showAbleStandCell();
    }

    public void showAbleStandCell()
    {
        if (list_ableStandCell.Count > 0)
        {
            clearAbleStandCell();
            return;
        }

        // 找到周围四个可以行动的格子
        {
            int base_index_x = standCellScript.index_x;
            int base_index_z = standCellScript.index_z;

            int actionRange = 4;
            // 上
            {
                for (int i = 1; i <= actionRange; i++)
                {
                    CellScript script = CellManager.s_instance.getCell(base_index_x, base_index_z - i);
                    if (script && script.cellType == CellType.Null)
                    {
                        script.setCellType(CellType.Able);
                        list_ableStandCell.Add(script);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // 下
            {
                for (int i = 1; i <= actionRange; i++)
                {
                    CellScript script = CellManager.s_instance.getCell(base_index_x, base_index_z + i);
                    if (script && script.cellType == CellType.Null)
                    {
                        script.setCellType(CellType.Able);
                        list_ableStandCell.Add(script);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // 左
            {
                for (int i = 1; i <= actionRange; i++)
                {
                    CellScript script = CellManager.s_instance.getCell(base_index_x - i, base_index_z);
                    if (script && script.cellType == CellType.Null)
                    {
                        script.setCellType(CellType.Able);
                        list_ableStandCell.Add(script);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            // 右
            {
                for (int i = 1; i <= actionRange; i++)
                {
                    CellScript script = CellManager.s_instance.getCell(base_index_x + i, base_index_z);
                    if (script && script.cellType == CellType.Null)
                    {
                        script.setCellType(CellType.Able);
                        list_ableStandCell.Add(script);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    public void clearAbleStandCell()
    {
        for(int i = 0; i < list_ableStandCell.Count; i++)
        {
            list_ableStandCell[i].setCellType(CellType.Null);
        }
        list_ableStandCell.Clear();
    }
}
