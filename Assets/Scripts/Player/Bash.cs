using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : MonoBehaviour
{

 
    private Rigidbody2D PlayerRb;
  
    private Collider2D Col;

    [Header("Bash")]
    [SerializeField] private float Raduis;
    [SerializeField] GameObject BashAbleObj;
    private bool NearToBashAbleObj;
    private bool IsChosingDir;
    private bool IsBashing;
    [SerializeField] private float BashPower;
    [SerializeField] private float BashTime;
    [SerializeField] private GameObject Arrow;
    Vector3 BashDir;
    private float BashTimeReset;
    public CharacterController2D character;
    private float Dir;
    [SerializeField] private float Movement_Speed;

    public bool getBash()
    {
        return IsBashing;
    }
    // Start is called before the first frame update
    void Start()
    {

        BashTimeReset = BashTime;
        PlayerRb = GetComponent<Rigidbody2D>();
        Col = GetComponent<BoxCollider2D>();
        character = FindObjectOfType<CharacterController2D>();


    }

    // Update is called once per frame
    void Update()
    {


        
isBash();


    }

  



    /////////////////////////////////----BASH

    void isBash()
    {
        RaycastHit2D[] Rays = Physics2D.CircleCastAll(transform.position, Raduis, Vector3.forward);
        foreach (RaycastHit2D ray in Rays)
        {

            NearToBashAbleObj = false;

            if (ray.collider.CompareTag("BashAble"))
            {
                NearToBashAbleObj = true;
                BashAbleObj = ray.collider.transform.gameObject;
                break;
            }
        }
        if (NearToBashAbleObj)
        {
            
            /* BashAbleObj.GetComponent<SpriteRenderer>().color = Color.yellow;*/
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Time.timeScale = 0;
                BashAbleObj.transform.localScale = new Vector2(1.4f, 1.4f);
                Arrow.SetActive(true);
                Arrow.transform.position = BashAbleObj.transform.transform.position;
                IsChosingDir = true;
            }
            else if (IsChosingDir && Input.GetKeyUp(KeyCode.Mouse1))
            {
                Time.timeScale = 1f;
                BashAbleObj.transform.localScale = new Vector2(1, 1);
                IsChosingDir = false;
                IsBashing = true;
                PlayerRb.velocity = Vector2.zero;

                StartCoroutine(FindObjectOfType<Invincibility>().SetInvincibility(0.5f));

                transform.position = BashAbleObj.transform.position;
                /* BashDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;*/
                BashDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

                BashDir.z = 0;
                if (BashDir.x > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                BashDir = BashDir.normalized;

                BashAbleObj.GetComponent<Rigidbody2D>().AddForce(-BashDir * BashPower, ForceMode2D.Impulse);
                Arrow.SetActive(false);

            }
        }


        ////// Preform the bash
        ///
        if (IsBashing)
        {
            /*  BashTime -= Time.deltaTime;
              PlayerRb.AddForce(BashDir * BashPower, ForceMode2D.Impulse);
              IsBashing = false;
              BashTime = BashTimeReset;*/
            if (BashTime > 0)
            {
                BashTime -= Time.deltaTime;
                /*PlayerRb.AddForce(BashDir * BashPower, ForceMode2D.Impulse);*/
                PlayerRb.velocity = BashDir * BashPower * Time.deltaTime;
                BashAbleObj.GetComponent<Rigidbody2D>().velocity = -BashDir * BashPower * Time.deltaTime;
                /* PlayerRb.velocity = new Vector2(vectorInput.x * maxSpeed, velocity.y);*/
            }
            else
            {
                IsBashing = false;
                BashTime = BashTimeReset;

Debug.Log("bash"+BashDir);

            }

           
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Raduis);
    }



}
