using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearStub : MonoBehaviour
{
    public Transform enemy;
    public Transform hips;

    public ParticleSystem particle;

    public bool isStuck;

    private Transform player;
    private Transform t_tile;
    private Transform t_head;


    private bool isTarget = false;
    void Start()
    {
        if (particle != null)
        {
            particle.Stop();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SHead")
        {
            if (particle != null)
            {
                particle.Play();
                particle.transform.SetParent(null);
            }
            t_head = other.transform;
            EnemyAfterSpear(other.transform.parent.parent, t_head);

            player = other.transform.parent.parent;
            t_tile = player.GetChild(0);

        }

    }

    void FixedUpdate()
    {
        if (isStuck && !isTarget)
        {
            enemy.transform.position = Vector3.Lerp(enemy.transform.position, PositionAfterStabbing(t_tile.position.z), 0.1f);
            if(Vector3.Distance(enemy.position,t_tile.position)<=0.1f)
            {
                t_tile.position = new Vector3(t_tile.position.x, t_tile.position.y, transform.position.z + 0.5f);
                isTarget = true;
            }
        }

    }
    void EnemyAfterSpear(Transform t_player,Transform t_head)
    {
        enemy.GetComponent<Animator>().enabled = false;
        enemy.transform.parent = t_player;
        enemy.transform.position = PositionAfterStabbing(t_head.position.z);
        isStuck = true;

    }

    private Vector3 PositionAfterStabbing(float posZ)
    {
        return new Vector3(t_head.position.x, enemy.position.y, posZ);
    }

}
