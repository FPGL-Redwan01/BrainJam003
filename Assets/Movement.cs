using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator m_Anim;
    float m_HorizontalMovement;
    public GameObject Collsions;
    public GameObject AllAroudAuraFX;

    public GameObject BubbleTextUi;
    public GameObject PointerUi;


    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool m_CanMove = false;
    private void Awake()
    {
        Collsions.SetActive(false);
        m_Anim = transform.GetChild(0).GetComponent<Animator>();
    }
     public IEnumerator StartAura()
    {
        m_CanMove = true;      
        PointerUi.SetActive(false);
        BubbleTextUi.SetActive(true);
        Collsions.SetActive(true);
         yield return new WaitForSeconds(0);
        AllAroudAuraFX.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.3f);
        AllAroudAuraFX.gameObject.SetActive(false);
        m_CanMove = false;
        PointerUi.SetActive(true);
        BubbleTextUi.SetActive(false);
        transform.GetComponentInChildren<PlayerCollsion>().enabled = false ;
        Collsions.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            m_Anim.SetTrigger("Stop");
            StartCoroutine(StartAura());
            if (GM.Instance.FinalSpawn)
            {
                StartCoroutine(Win());
            }
        }

        if (!m_CanMove &&GM.Instance.StartGame)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
          
            if (direction.magnitude >= 0.1f)
            {
                m_Anim.SetFloat("Speed_f", direction.magnitude);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);


            }



            else
            {
                m_Anim.SetFloat("Speed_f", 0);
            }


        }
    }
    public IEnumerator Win()
    {
        yield return new WaitForSeconds(5);
        GM.Instance.WinPanel.SetActive(true);
    }

}
