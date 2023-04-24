using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{


    
    
    public float deathTime = 5f; // �뿪���������ʱ��
    public Animator animator; // ���Ŷ�����Animator���

    private bool isDead = false; // ����Ƿ�������
    private float leaveTime = 0f; // �뿪�����ʱ��
    private bool isInCover = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leaveTime = Time.time;
            // animator.SetBool("isLeavingCover", true);
            // Debug.Log("exit");
            isInCover = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Time.time - leaveTime < deathTime && isDead)
            {
                //animator.SetBool("KillingPlayer", false);
                isDead = false;
                //animator.SetBool("flyAway", true);
            }
            //animator.SetBool("isLeavingCover", false);
        }
        //Debug.Log("enter");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInCover = true;
        }
        //Debug.Log("enter");
    }



    private void Update()
    {
        if (!isInCover)
        {
            if (Time.time - leaveTime >= deathTime && !isDead)
            {
                //animator.SetBool("KillingPlayer", true);
                isDead = true;
                die();
            }
            
        }
    }

    private void die()
    {
        CharacterData CD =FindObjectOfType<CharacterData>();
        CD.Die();

    }
}

