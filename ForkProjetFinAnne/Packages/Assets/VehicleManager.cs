using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    CockpitVehicle Cockpit;
    private Vehicle[] m_AllVehicles;
    private Camera m_CurrentCamera;

    public List<Car> allCars;
    public List<Truck> allTrucks;

    public Vehicle vehicleSelected;
    private int m_IndexVehicleSelected = 0;

    void Start()
    {
        m_AllVehicles = FindObjectsOfType<Vehicle>();
        m_CurrentCamera = FindObjectOfType<Camera>();

        allCars = new List<Car>();
        allTrucks = new List<Truck>();

        for (int i = 0; i < m_AllVehicles.Length; i++)
        {
            Vehicle currentVehicle = m_AllVehicles[i];
            // Si vehicule courrant est un car
            // Je l'ajoute à la liste allCar
            if(currentVehicle is Car)
            {
                allCars.Add((Car)currentVehicle);
            }
            else if(currentVehicle is Truck truck)
            {
                allTrucks.Add(truck);
            }
        }

        // Test si vehicle deja selectionné, sinon prend le premier du tableau
        if (vehicleSelected == null && m_AllVehicles.Length > 0)
        {
            m_IndexVehicleSelected = 0;
            vehicleSelected = m_AllVehicles[0];
        }
        else
        {
            for (int i = 0; i < m_AllVehicles.Length; i++)
            {
                if(m_AllVehicles[i] == vehicleSelected)
                {
                    m_IndexVehicleSelected = i;
                    break;
                }
            }
        }
    }

    public void Update()
    {
        if (vehicleSelected != null)
        {
            Vector3 newPosCamera = vehicleSelected.transform.position;

            if (m_CurrentCamera.transform.parent != null)
            {
                m_CurrentCamera.transform.parent.position = newPosCamera;
            }
            else
            {
                m_CurrentCamera.transform.position = newPosCamera;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                vehicleSelected.Move();
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                vehicleSelected.Speciality();
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if(vehicleSelected is CockpitVehicle cockpit)
                {
                    cockpit.OpenDoors();
                }
            }
        }
        else
        {
            Debug.LogError("NO VEHICLE SELECTED!");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UpdateSelectedVehicle();
        }
    }

    private void UpdateSelectedVehicle()
    {
        m_IndexVehicleSelected++;
        if(m_IndexVehicleSelected >= m_AllVehicles.Length)
        {
            m_IndexVehicleSelected = 0;
        }
        vehicleSelected = m_AllVehicles[m_IndexVehicleSelected];
    }
}
