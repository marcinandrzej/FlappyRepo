using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private const int LEVEL_COUNT = 7;
    public Image levelImage;

    public GameObject mainPanel;
    public GameObject levelPanel;

    private int[,] levelIndexes;
    private int levelIndex;   

	// Use this for initialization
	void Start ()
    {
        levelIndex = 0;
        SetUpLevels();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartGame()
    {
        DataScript.instance.SetGame(levelIndexes[levelIndex, 0], levelIndexes[levelIndex, 1], levelIndexes[levelIndex, 2]);
        SceneManager.LoadScene("GameScene");
    }

    private void SetUpLevels()
    {
        levelIndexes = new int[LEVEL_COUNT, 3];
        //sand
        levelIndexes[0, 0] = 0;
        levelIndexes[0, 1] = 0;
        levelIndexes[0, 2] = 0;
        //snow
        levelIndexes[1, 0] = 2;
        levelIndexes[1, 1] = 1;
        levelIndexes[1, 2] = 0;
        //grass
        levelIndexes[2, 0] = 4;
        levelIndexes[2, 1] = 0;
        levelIndexes[2, 2] = 2;
        //jungle
        levelIndexes[3, 0] = 6;
        levelIndexes[3, 1] = 1;
        levelIndexes[3, 2] = 3;
        //magic forest
        levelIndexes[4, 0] = 8;
        levelIndexes[4, 1] = 1;
        levelIndexes[4, 2] = 1;
        //dead forest
        levelIndexes[5, 0] = 10;
        levelIndexes[5, 1] = 0;
        levelIndexes[5, 2] = 4;
        //mushrooms
        levelIndexes[6, 0] = 12;
        levelIndexes[6, 1] = 1;
        levelIndexes[6, 2] = 5;
    }

    public void ShowNext()
    {
        if (levelIndex + 1 < (DataScript.instance.backgroundSprites.Length / 2))
        {
            levelIndex += 1;
            levelImage.sprite = DataScript.instance.backgroundSprites[levelIndex * 2];
        }
    }

    public void ShowPrevious()
    {
        if (levelIndex - 1 >= 0)
        {
            levelIndex -= 1;
            levelImage.sprite = DataScript.instance.backgroundSprites[levelIndex * 2];
        }
    }

    public void SwitchPanel(bool toMainPanel)
    {
        mainPanel.SetActive(toMainPanel);
        levelPanel.SetActive(!toMainPanel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
