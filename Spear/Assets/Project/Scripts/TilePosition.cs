using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePosition : MonoBehaviour
{
    public SpearHead spearHead;

    private Transform tile;
    void Start()
    {
        tile = transform.GetChild(0);
    }

    void FixedUpdate()
    {

        if (GetChildCount > 3 && spearHead.Collide("Gate"))
        {
            tile.position = new Vector3(tile.position.x, tile.position.y, GetLastChild.position.z + 0.5f);
        }
    }
    
    public void SpearOutLastChildPosition()
    {
        tile.position = new Vector3(tile.position.x, tile.position.y, GetLastChild.position.z + 0.5f);
    }
    public int GetChildCount
    {
        get
        {
            return transform.childCount;
        }
    }
    public Transform GetLastChild
    {
        get
        {
            return transform.GetChild(GetChildCount - 1);
        }
    }

}
