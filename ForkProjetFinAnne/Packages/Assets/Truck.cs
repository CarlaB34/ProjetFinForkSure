using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : CockpitVehicle
{
    public GameObject trail;
    private bool m_IsLoaded = true;

    public override void Move()
    {
        base.Move();
        Debug.Log("Broooooom Brooomm");
    }

    

    public override void Speciality()
    {
        if(m_IsLoaded)
        {
            trail.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            trail.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
        m_IsLoaded = !m_IsLoaded;
    }
}
