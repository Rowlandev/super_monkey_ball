using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : PickUp
{

    private int valueOfPickUp;

    public Pineapple()
    {
        this.valueOfPickUp = 1000;
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
