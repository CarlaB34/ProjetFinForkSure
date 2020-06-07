using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public float speed = 1;

    public string description;

    public List<GameObject> wheels;

    public virtual void Move()
    {
        Vector3 dir = new Vector3(0.1f, 0, 0);
        transform.Translate(speed * dir);

        Vector3 dirRot = new Vector3(0, 0,  -1);
        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(speed * dirRot);
        }
    }

    public void ShowDescription()
    {
        Debug.Log("Descirption : " + description);
    }

    public abstract void Speciality(); 

    public void Start()
    {
        ShowDescription();
    }
}