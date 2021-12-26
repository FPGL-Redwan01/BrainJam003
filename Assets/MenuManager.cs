using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject BreakingNews, spaceText , Dailogue ;
    int a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BreakingNewsS());
    }


    public IEnumerator BreakingNewsS()
    {
        yield return new WaitForSeconds(1f);
        spaceText.gameObject.SetActive(true);
        if (Input.GetKeyDown("space"))
        {
            a++;
            if (a == 1)
            {
                BreakingNews.gameObject.SetActive(false);

                Dailogue.gameObject.SetActive(true);
            }
            if (a == 2)
            {
                SceneManager.LoadScene(1);
            }
            spaceText.gameObject.SetActive(false);
            
        }
    }
}
