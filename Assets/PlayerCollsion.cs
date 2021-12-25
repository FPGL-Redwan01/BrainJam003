using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerCollsion : MonoBehaviour
{

    bool played;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            other.GetComponent<Animator>().SetTrigger("GoBack");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            
               other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(01).gameObject.SetActive(true);
            other.transform.Translate(Vector3.back * 3 * Time.deltaTime);
            StartCoroutine(DisableCollidre(other.gameObject));
        }
    }
    public IEnumerator DisableCollidre(GameObject g)
    {
        yield return new WaitForSeconds(1.3f);
        played = false;
        g.GetComponent<Collider>().enabled = false
;    
    }
}
