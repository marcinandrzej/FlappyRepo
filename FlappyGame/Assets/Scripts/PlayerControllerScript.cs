using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public GuiScript gui;
    public LayerMask obstackleLayer;
    public LayerMask scoreLayer;
    private int obstackleLayerIndex;
    private int scoreLayerIndex;
    private const float PLAYER_SPEED = 5f;
    private Rigidbody2D myRigidbody;
    private PlayerStatesScript playerState;
    // Use this for initialization
    void Start ()
    {
        obstackleLayerIndex = (int)Mathf.Log(obstackleLayer.value, 2);
        scoreLayerIndex = (int)Mathf.Log(scoreLayer.value, 2);
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        ChangeState(new StartPlayerState());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            playerState.Execute(myRigidbody, this, PLAYER_SPEED);
        playerState.UpdatePlayer(gameObject, myRigidbody);
    }

    void OnBecameInvisible()
    {
        ChangeState(new EndPlayerState());
        if(gui != null)
            gui.ShowEndPanel();
    }

    public void ChangeState(PlayerStatesScript newState)
    {
        playerState = newState;
        playerState.OnStateEnter(myRigidbody, PLAYER_SPEED);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == obstackleLayerIndex)
        {
            ChangeState(new EndPlayerState());
            if (gui != null)
                gui.ShowEndPanel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == scoreLayerIndex)
        {
            if (gui != null)
                gui.Score();
            other.enabled = false;
        }
    }
}