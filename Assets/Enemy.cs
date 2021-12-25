using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcType
{
    CoupleBoy ,
    CoupleGirl,
    Family ,
    Workers ,
    Infected
}

public class Enemy : MonoBehaviour
{
    public GameObject Boy, Girl;
    public float MoveSpeed;
    public NpcType npc;
    

    public WpPatrol Wp_Patrol;
    public Collider colliders;
    void Start()
    {
        Wp_Patrol = GetComponent<WpPatrol>();
        colliders = GetComponentInChildren<Collider>();
        if (npc == NpcType.CoupleBoy || npc == NpcType.CoupleGirl)
        {
            Girl = GameObject.FindGameObjectWithTag("Girl");
            Boy = GameObject.FindGameObjectWithTag("Boy");
        }
    }


    private void Update()
    {
        if(npc == NpcType.CoupleBoy)
        {
            transform.LookAt(Girl.transform);
            float step = MoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Girl.transform.position, step);
        }
        if (npc == NpcType.CoupleGirl)
        {
            transform.LookAt(Boy.transform);
            float step = MoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Boy.transform.position, step);
        }
    }

    public IEnumerator StartPatrol()
    {
        yield return new WaitForSeconds(2.5f);
        Wp_Patrol.enabled = true;
    }
    public IEnumerator ColliderDisable()
    {
        yield return new WaitForSeconds(1.5f);
        colliders.enabled = false;
    }
    public IEnumerator StartWalk()
    {
        yield return new WaitForSeconds(2.4f);
        GetComponentInChildren<Animator>().Play("Walking");
    }
}
