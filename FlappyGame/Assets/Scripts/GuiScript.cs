using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiScript : MonoBehaviour
{
    public GameObject endPanel;
    public Text scoreTxt;
    private int score;

	// Use this for initialization
	void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Score()
    {
        score++;
        scoreTxt.text = score.ToString();
    }

    public void ShowEndPanel()
    {
        if(endPanel != null)
            StartCoroutine(ShowEndCoroutine());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Destroy(DataScript.instance.gameObject);
        SceneManager.LoadScene("MenuScene");
    }

    private IEnumerator ShowEndCoroutine()
    {
        Button[] buttons = endPanel.GetComponentsInChildren<Button>();
        foreach (Button but in buttons)
        {
            but.enabled = false;
        }
        endPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        endPanel.SetActive(true);
        Vector3 destination = new Vector3(1, 1, 1);
        while (endPanel.transform.localScale != destination)
        {
            endPanel.transform.localScale = Vector3.MoveTowards(
                endPanel.transform.localScale, destination, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        foreach (Button but in buttons)
        {
            but.enabled = true;
        }
    }
}
