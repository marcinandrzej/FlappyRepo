using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    public static DataScript instance;

    public Sprite[] backgroundSprites;
    public Sprite[] ObstacklesSprites;
    public Color32[] ObstacklesColors;

    private int backgroundSpriteIndex;
    private int obstackleSpriteIndex;
    private int obstackleColorIndex;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetGame(int bgIndex, int obsSprIndex, int obsColorIndex)
    {
        backgroundSpriteIndex = bgIndex;
        obstackleSpriteIndex = obsSprIndex;
        obstackleColorIndex = obsColorIndex;
    }

    public Sprite[] GetBackground()
    {
        Sprite[] spr = new Sprite[2];
        spr[0] = backgroundSprites[backgroundSpriteIndex];
        spr[1] = backgroundSprites[backgroundSpriteIndex + 1];
        return spr;
    }

    public Sprite GetObstackleSprite()
    {
        return ObstacklesSprites[obstackleSpriteIndex];
    }

    public Color32 GetObstackleColor()
    {
        return ObstacklesColors[obstackleColorIndex];
    }
}
