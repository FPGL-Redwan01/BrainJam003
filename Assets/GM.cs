using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class GM : Singleton<GM>
{
    public GameObject StartPanel;
    public bool StartGame;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartIt()
    {
        StartPanel.gameObject.SetActive(false);
        StartGame = true;
    }
}
