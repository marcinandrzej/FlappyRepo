using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerStatesScript
{
    void OnStateEnter(Rigidbody2D playerRigidbody, float speed);
    void Execute(Rigidbody2D playerRigidbody, PlayerControllerScript player, float speed);
    void UpdatePlayer(GameObject player, Rigidbody2D playerRigidbody);
}

public class StartPlayerState : PlayerStatesScript
{
    public void OnStateEnter(Rigidbody2D playerRigidbody, float speed)
    {
        playerRigidbody.gravityScale = 0;
        playerRigidbody.velocity = new Vector2(0, 0);
    }

    public void Execute(Rigidbody2D playerRigidbody, PlayerControllerScript player, float speed)
    {
        player.ChangeState(new GamePlayerState());
    }

    public void UpdatePlayer(GameObject player, Rigidbody2D playerRigidbody)
    {
        
    }
}

public class GamePlayerState : PlayerStatesScript
{
    public void OnStateEnter(Rigidbody2D playerRigidbody, float speed)
    {
        playerRigidbody.gravityScale = 1;
        playerRigidbody.velocity = new Vector2(speed, 0);
        playerRigidbody.AddForce(new Vector2(0, 1) * 200);
    }

    public void Execute(Rigidbody2D playerRigidbody, PlayerControllerScript player, float speed)
    {
        playerRigidbody.velocity = new Vector2(speed, 0);
        playerRigidbody.AddForce(new Vector2(0, 1) * 200);
    }

    public void UpdatePlayer(GameObject player, Rigidbody2D playerRigidbody)
    {
        float heading = Mathf.Atan2(-playerRigidbody.velocity.x, playerRigidbody.velocity.y);
        player.transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
    }
}

public class EndPlayerState : PlayerStatesScript
{
    public void OnStateEnter(Rigidbody2D playerRigidbody, float speed)
    {
        playerRigidbody.gravityScale = 0;
        playerRigidbody.velocity = new Vector2(0, 0);
        playerRigidbody.angularVelocity = 0;
    }

    public void Execute(Rigidbody2D playerRigidbody, PlayerControllerScript player, float speed)
    {

    }

    public void UpdatePlayer(GameObject player, Rigidbody2D playerRigidbody)
    {

    }
}

