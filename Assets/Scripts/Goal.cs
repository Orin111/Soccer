using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public int goalNum = 0;
    public int score = 0;

    public ActorAnimator playerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            

            makeGoal();

            StartCoroutine(RespawnObjects(2f));
        }
    }

    [ContextMenu("Goal")]
        private void makeGoal()
    {
        Debug.Log("GOAL");
        if (gameObject.CompareTag("Goal"))
        {
            int preScore = PlayerPrefs.GetInt("Goal" + goalNum.ToString());
            PlayerPrefs.SetInt("Goal" + goalNum.ToString(), preScore + 1); 
            playerAnimator.StartDanceAnimation();
        }

        if (PlayerPrefs.GetInt("Goal" + goalNum.ToString()) == 3)
        {
            Debug.Log("You WON!");
            PlayerPrefs.SetInt("Goal"+goalNum.ToString(),0);
            Application.Quit();
        }
    }
    

    IEnumerator RespawnObjects(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Goal" + goalNum.ToString() ,- 1) == -1)
        {
            PlayerPrefs.SetInt("Goal"+goalNum.ToString(),0);
        }
    }

    private void Update()
    {
        score = PlayerPrefs.GetInt("Goal" + goalNum.ToString());
    }
}
