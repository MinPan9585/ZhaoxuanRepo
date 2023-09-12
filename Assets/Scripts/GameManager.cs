using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public int score = 0;
    public Vector3 startPosition;

    public int lives = 1;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        startPosition = ball.transform.position;
    }

    public void Die()
    {
        ball.GetComponent<Rigidbody>().position = startPosition;
        //ball.GetComponent<Ball>().currentPower = 1f;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //Debug.Log(ball.GetComponent<Rigidbody>().velocity);
    }

    public void EndGame()
    {

    }
}
