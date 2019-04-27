using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    private Player player1 = new Player(500, 500); // declared object to use as player from 'Player' class
    public Rigidbody myRb; // declared RigidBody to allow player movement

    public UICanvas uiCanvas;       

    public PickUp banana;
    public PickUp pineapple;

    // Update is called once per frame
    void Update()
    {

        if (player1.GetType() == typeof(Player))
        {
            player1.setMovement(myRb);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("banana"))
        {
            other.gameObject.SetActive(false);
            uiCanvas.updateScore(banana.getValueOfPickUp());
        }
        else if (other.gameObject.CompareTag("Finish Line"))
        {
            other.gameObject.SetActive(false);
            uiCanvas.endGame(player1);
        } else if (other.gameObject.CompareTag("pineapple"))
        {
            other.gameObject.SetActive(false);
            uiCanvas.updateScore(pineapple.getValueOfPickUp());
        }
    }
}
