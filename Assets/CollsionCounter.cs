using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionCounter : MonoBehaviour
{
    public Enemy enemy;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
         if(collision.gameObject.CompareTag("Enemy"))
        {
           
            GM.Instance.Count++;
   
            if(GM.Instance.Count == 2 && enemy.npc == NpcType.Workers)
            {
                
                collision.gameObject.GetComponent<Collider>().enabled = false;
                GM.Instance.IncreaePoints();
                Instantiate(GM.Instance.ThreeLabour, collision.gameObject.transform.position, Quaternion.identity);
               
                GM.Instance.Count = 0;
                GM.Instance.LoosePnel.SetActive(true);
                Destroy(enemy.transform.root.gameObject);
            }
            if (GM.Instance.Count == 2 && enemy.npc == NpcType.CoupleBoy || enemy.npc == NpcType.CoupleGirl)
            {
               
                collision.gameObject.GetComponent<Collider>().enabled = false;
                GM.Instance.IncreaePoints();
                Instantiate(GM.Instance.Lover, collision.gameObject.transform.position, Quaternion.identity);
                GM.Instance.Count = 0;
                GM.Instance.LoosePnel.SetActive(true);
                Destroy(enemy.transform.root.gameObject);

            }
        }
      
    }
}
