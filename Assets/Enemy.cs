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
    public bool Couple;
    public GameObject Boy, Girl, Points;
    public float MoveSpeed;
    public NpcType npc;
    bool canMove;

    public WpPatrol Wp_Patrol;
    public Collider colliders;
    public float Speration =6 ;
    void Start()
    {
        Wp_Patrol = GetComponent<WpPatrol>();
        colliders = GetComponentInChildren<Collider>();
        if (npc == NpcType.CoupleBoy || npc == NpcType.CoupleGirl)
        {
            if(Girl != null)
            Girl = GameObject.FindGameObjectWithTag("Girl");
            if (Boy != null)
            Boy = GameObject.FindGameObjectWithTag("Boy");

            transform.GetChild(0).GetComponent<Animator>().Play("Walking");



        }
        if (npc == NpcType.Workers)
        {
            transform.GetChild(0).GetComponent<Animator>().Play("Walking");
            Points = GameObject.FindGameObjectWithTag("Labour");
        }



    }


    private void Update()
    {
        if(npc == NpcType.CoupleBoy && !canMove && GM.Instance.StartGame)
        {
            transform.LookAt(Girl.transform);
            float step = MoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Girl.transform.position, step);
        }
        if (npc == NpcType.CoupleGirl  && !canMove &&GM.Instance.StartGame)
        {
            transform.LookAt(Boy.transform);
            float step = MoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, Boy.transform.position, step);
        }


        if (npc == NpcType.Workers && !canMove && GM.Instance.StartGame)
        {
            transform.LookAt(Points.transform);
            float step = MoveSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards( transform.position, Points.transform.position, step);
        }
    }

    public IEnumerator StartPatrol()
    {
        
        
            yield return new WaitForSeconds(2.5f);

            Wp_Patrol.enabled = true;
        
        
    }
    public IEnumerator ColliderDisable()
    {
        canMove = true;
        yield return new WaitForSeconds(1.5f);
        colliders.enabled = false;
    }
    public IEnumerator StartWalk()
    {
        yield return new WaitForSeconds(2.4f);
        GetComponentInChildren<Animator>().Play("Walking");
    }
}
