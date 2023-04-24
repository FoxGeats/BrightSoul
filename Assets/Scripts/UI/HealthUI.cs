using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Animator[] healthItems;
    public Animator geo;
    public float showHealthItemIntervalTime = 0.2f;

    private CharacterData characterData;

    private int showHealth;

    private void Start()
    {
        characterData = FindObjectOfType<CharacterData>();
        showHealth = characterData.getHealth();
    }

    private void Update()
    {
        updateHealth();
    }

    private void updateHealth()
    {
        if (showHealth < characterData.getHealth()){
            showHealth++;
            StartCoroutine(ShowHealthItems());
        }
    }

    public void Hurt()
    {
        if (characterData.GetDeadStatement())
            return;
        characterData.LoseHealth(1);
        int health = characterData.GetCurrentHealth();
        healthItems[health].SetTrigger("Hurt");
    }

    public IEnumerator ShowHealthItems()
    {
        for (int i = 0; i < showHealth; i++)
        {
            healthItems[i].SetTrigger("Respawn");
            yield return new WaitForSeconds(showHealthItemIntervalTime);
        }
        yield return new WaitForSeconds(showHealthItemIntervalTime);
        geo.Play("Enter");
    }

    public void HideHealthItems()
    {
        geo.Play("Quit");
        for (int i = 0; i < healthItems.Length; i++)
        {
            healthItems[i].SetTrigger("Hide");
        }
    }
}
