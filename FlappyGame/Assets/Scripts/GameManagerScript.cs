using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject[] backgroundOb;
    public GameObject[] ObstacklesOb;

    // Use this for initialization
    void Start ()
    {
        SetUpBackGround(DataScript.instance.GetBackground()[0], DataScript.instance.GetBackground()[1]);
        SetUpObstackles(DataScript.instance.GetObstackleSprite(), DataScript.instance.GetObstackleColor());
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < ObstacklesOb.Length; i++)
        {
            if (ObstacklesOb[i].transform.position.x < playerTransform.position.x)
            {
                SpriteRenderer spriteRenderer = ObstacklesOb[i].GetComponentInChildren<SpriteRenderer>();
                if (!spriteRenderer.isVisible)
                {
                    if (i != 0)
                    {
                        ObstacklesOb[i].transform.position =
                            new Vector3(ObstacklesOb[i - 1].transform.position.x + Random.Range(3.0f, 5.0f),
                            Random.Range(-1.0f, 1.0f), 0);
                    }
                    else
                    {
                        ObstacklesOb[i].transform.position =
                            new Vector3(ObstacklesOb[ObstacklesOb.Length - 1].transform.position.x + Random.Range(3.0f, 5.0f),
                            Random.Range(-1.0f, 1.0f), 0);
                    }
                    ObstacklesOb[i].GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
	}

    public void SetUpBackGround(Sprite L, Sprite R)
    {
            backgroundOb[0].GetComponent<SpriteRenderer>().sprite = L;
            backgroundOb[1].GetComponent<SpriteRenderer>().sprite = R;
    }

    public void SetUpObstackles(Sprite sprite, Color32 color)
    {
        foreach (GameObject gO in ObstacklesOb)
        {
            SpriteRenderer[] spriteRenderers =  gO.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spr in spriteRenderers)
            {
                spr.sprite = sprite;
                spr.color = color;
            }
        }

        ObstacklesOb[0].transform.position = new Vector3(10, Random.Range(-1, 1), 0);
        for (int i = 1; i < ObstacklesOb.Length; i++)
        {
            ObstacklesOb[i].transform.position = new Vector3(ObstacklesOb[i - 1].transform.position.x + Random.Range(3.0f, 5.0f), Random.Range(-1.0f, 1.0f), 0);
        }
    }
}
