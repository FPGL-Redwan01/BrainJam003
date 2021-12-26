using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutManager : MonoBehaviour
{
    public GameObject Tut;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void GoNext()
    {
        SceneManager.LoadScene(2);
    }
}
