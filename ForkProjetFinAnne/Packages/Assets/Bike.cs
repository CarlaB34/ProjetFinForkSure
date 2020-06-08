using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : Vehicle
{
    public GameObject sideCar;
    private bool m_IsLoaded = true;

    public override void Move()
    {
        base.Move();
    }

    public override void Speciality()
    {
        if (m_IsLoaded)
        {
            sideCar.transform.position = this.transform.position;
            sideCar.transform.parent = this.transform;
        }

        if (m_IsLoaded == false)
        {
            sideCar.transform.parent = null;
        }
        m_IsLoaded = !m_IsLoaded;
    }
}

   

