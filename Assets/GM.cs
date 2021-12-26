using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Singleton;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : Singleton<GM>
{
    public GameObject Tuts;
    public GameObject ThreeLabour , Lover;
    public int Point;
    public Text SpreadText;

    public int Count;
    public GameObject StartPanel, LoosePnel, WinPanel;
    public bool StartGame;

    public float NPC1Time, NPC2Time, NPC3Time, NPC4Time , NPC5Time;
    public GameObject NPC1, NPC2, NPC3, NPC4 , NPC5;


   public bool FinalSpawn;
    public override void Start()
    {
        base.Start();
        GM.Instance.StartCoroutine(GM.Instance.Spawn1());
        GM.Instance.StartCoroutine(GM.Instance.Spawn2());
        GM.Instance.StartCoroutine(GM.Instance.Spawn3());
        GM.Instance.StartCoroutine(GM.Instance.Spawn4()); GM.Instance.StartCoroutine(GM.Instance.Spawn5());
    }
    public void IncreaePoints()
    {
       
       SpreadText.text =100.ToString();

    }
    public void Reset()
    {
        SceneManager.LoadScene(2);
    }
    public void StartIt()
    {
        if (Tuts != null)
        Tuts.gameObject.SetActive(true);


        StartPanel.gameObject.SetActive(false);
        StartGame = true;
    }

    public IEnumerator Spawn1()
    {
        if (NPC1 != null)
        {
            yield return new WaitForSeconds(NPC1Time);
            NPC1.SetActive(true);
        }
    }
    public IEnumerator Spawn2()
    {
        if (NPC2 != null)
        {
            yield return new WaitForSeconds(NPC2Time);
            NPC2.SetActive(true);
        }
    }
    public IEnumerator Spawn3()
    {
        if (NPC3 != null)
        {
            yield return new WaitForSeconds(NPC3Time);
            NPC3.SetActive(true);
        }
    }
    public IEnumerator Spawn4()
    {
        if (NPC4 != null)
        {
            yield return new WaitForSeconds(NPC4Time);
            NPC4.SetActive(true);
        }
    }
    public IEnumerator Spawn5()
    {
        if (NPC5 != null)
        {
            yield return new WaitForSeconds(NPC5Time);
            NPC5.SetActive(true);
            yield return new WaitForSeconds(3);
            FinalSpawn = true;
        }
    }
}

