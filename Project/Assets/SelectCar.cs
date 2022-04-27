using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCar : MonoBehaviour
{
    public int carType;

    private void OnMouseDown()
    {
        Debug.Log(carType);
        GameControllerTest.instance.SelectCart(carType);
    }
}
