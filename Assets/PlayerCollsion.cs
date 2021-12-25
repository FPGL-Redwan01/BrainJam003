using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCollsion : MonoBehaviour
{
    public float PushBackDelay = .5f;
    bool played;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Animation(other.gameObject));
            if (other.gameObject.GetComponentInParent<Enemy>().npc != NpcType.CoupleBoy || other.gameObject.GetComponentInParent<Enemy>().npc != NpcType.CoupleGirl)
            {
                other.gameObject.GetComponentInParent<Enemy>().StartCoroutine(other.gameObject.GetComponentInParent<Enemy>().StartPatrol());
            }
                other.gameObject.GetComponentInParent<Enemy>().StartCoroutine(other.gameObject.GetComponentInParent<Enemy>().ColliderDisable());
                other.gameObject.GetComponentInParent<Enemy>().StartCoroutine(other.gameObject.GetComponentInParent<Enemy>().StartWalk());
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            StartCoroutine(PushBckTime(other.gameObject));
            
          
          
        }
    }
    public IEnumerator Animation(GameObject g)
    {
        yield return new WaitForSeconds(.5f);
        g.GetComponent<Animator>().SetTrigger("GoBack");
    }

    public IEnumerator PushBckTime(GameObject g)
    {
        yield return new WaitForSeconds(PushBackDelay);
        g.transform.GetChild(0).gameObject.SetActive(false);
        g.transform.GetChild(01).gameObject.SetActive(true);
        g.transform.Translate(Vector3.back * 6 * Time.deltaTime);
    }

    public IEnumerator DisableCollidre(GameObject g)
    {
        yield return new WaitForSeconds(1.3f);       
        played = false;
        g.GetComponent<Collider>().enabled = false;
    }
    public  IEnumerator Okay(GameObject g)
    {
        yield return new WaitForSeconds(1.5f);
        g.transform.GetComponentInParent<Enemy>().Wp_Patrol.enabled = true;
    }

    public IEnumerator EnableWalk(GameObject g)
    {
        yield return new WaitForSeconds(1.2f);
        g.GetComponent<Animator>().Play("Walking");

    }
   
}
