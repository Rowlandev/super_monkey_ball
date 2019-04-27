using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    // PRIVATE ATTRIBUTES
    private Rigidbody rb;
    private float sidewaysForce;
    private float forwardsForce;
    private bool moveable;

    // CONSTRUCTORS
    public Player(float enteredSidewaysForce, float enteredForwardsForce)
    {
        this.sidewaysForce = enteredSidewaysForce;
        this.forwardsForce = enteredForwardsForce;
        moveable = true;
    }

    // GETTERS

    public float getSidewaysForce()
    {
        return this.sidewaysForce;
    }

    public float getForwardsForce()
    {
        return this.forwardsForce;
    }

    public bool isMoveable()
    {
        return this.moveable;
    }

    // SETTERS

    public void setSidewaysForce(float enteredSidewaysForce)
    {
        this.sidewaysForce = enteredSidewaysForce;
    }

    public void setForwardsForce(float enteredForwardsForce)
    {
        this.forwardsForce = enteredForwardsForce;
    }

    public void setIsMoveable(bool newBool)
    {
        this.moveable = newBool;
    }

    // CUSTOM METHODS

    public void setMovement(Rigidbody enteredRb)
    {
        if (isMoveable() == true)
        {
            this.rb = enteredRb;

            if (Input.GetKey("right"))
            {
                rb.AddForce(getSidewaysForce() * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("left"))
            {
                rb.AddForce(-getSidewaysForce() * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey("up"))
            {
                rb.AddForce(0, 0, getForwardsForce() * Time.deltaTime);
            }

            if (Input.GetKey("down"))
            {
                rb.AddForce(0, 0, -getForwardsForce() * Time.deltaTime);
            }
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }

}
