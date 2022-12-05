using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEnemyPosition : MonoBehaviour
{
    public Transform target;
    public GameManager manager;
    public Transform head;


    void Update()
    {
        if(manager.gameState == GameManager.GameState.Stop)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
            if(transform.parent)
            {
                transform.SetParent(null);
            }
        }        
    }
}
