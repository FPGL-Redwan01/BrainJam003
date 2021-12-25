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
            StartCoroutine(Animation(other.gameObject));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {                    
            StartCoroutine(PushBckTime(other.gameObject));
            StartCoroutine(DisableCollidre(other.gameObject));
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
}
