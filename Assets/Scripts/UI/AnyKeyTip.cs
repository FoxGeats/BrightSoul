using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class AnyKeyTip : MonoBehaviour
{
    public int counter=0;

    [SerializeField] private CanvasGroup textCanvasGroup;
    [SerializeField] private VideoPlayer prologue;
    [SerializeField] private VideoPlayer intro;
    [SerializeField] private bool isCrossing;

    public Animator animator;
    public AudioSource audioSource;
    private OpeningSequence os;

    private void Update()
    {
  

        if (Input.anyKeyDown)
        {
            if (isCrossing)
            {
                Display();
            }
            else
            {
                DisplayLate();
            }
        }
    }

    public void Display()
    {
        StopAllCoroutines();
        switch (counter)
        {
            case 0:
                ResetAnyKeyTip();
                animator.Play("Enter", 0, 720);
                audioSource.Stop();
                /* os = FindObjectOfType<OpeningSequence>();
                 os.PlayPrologue();*/
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    Debug.Log("f");
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Debug.Log("1");
                    SceneManager.LoadSceneAsync(1);
                }

                break;
            case 1:
                ResetAnyKeyTip();
                prologue.frame = (long)prologue.frameCount;
               
                break;
            case 2:
                ResetAnyKeyTip();
                intro.frame = (long)intro.frameCount;
                
                break;
        }
    }

    public void DisplayLate()
    {
        StartCoroutine(DelayDisplay());
    }

    IEnumerator DelayDisplay()
    {
        isCrossing = true;
        while (textCanvasGroup.alpha != 1)
        {
            textCanvasGroup.alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ResetAnyKeyTip()
    {
        isCrossing = false;
        textCanvasGroup.alpha = 0;
    }
}
