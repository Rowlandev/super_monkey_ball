using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : PickUp
{

    private int valueOfPickUp;

    public Banana()
    {
        this.valueOfPickUp = 100;
    }

    override
    public int getValueOfPickUp()
    {
        return this.valueOfPickUp;
    }

    public void Update()
    {
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
    }
}
