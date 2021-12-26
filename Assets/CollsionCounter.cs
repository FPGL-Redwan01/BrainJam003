using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionCounter : MonoBehaviour
{
   
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            GM.Instance.Count++;
   
            if(GM.Instance.Count == 2)
            {
            
                GM.Instance.IncreaePoints(50);
                Instantiate(GM.Instance.ThreeLabour, collision.gameObject.transform.position, Quaternion.identity);
              
            }
        }
    }
}
