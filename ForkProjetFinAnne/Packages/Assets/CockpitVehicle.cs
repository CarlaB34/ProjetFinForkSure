using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CockpitVehicle : Vehicle
{
    private bool m_IsLoaded = true;

    public List<GameObject> doors;

    public virtual void OpenDoors()
    {
        foreach  (GameObject door in doors)
        {
            door.transform.Rotate(new Vector3(0, -90f, 0));
        }
    }
    

    void Update()
    {
        
    }
}
