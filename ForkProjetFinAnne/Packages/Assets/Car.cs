using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : CockpitVehicle
{
    public override void Move()
    {
        base.Move();
        Debug.Log("Vroom Vroom");
    }

   
    public override void Speciality()
    {
        Debug.Log("No Speciliaty");
    }
}
