using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTest : MonoBehaviour
{
    public static GameControllerTest instance;
    public int typecar;

    private void Awake()
    {
        instance = this;
    }

    public void SelectCart(int car)
    {
        typecar = car;
    }
    
}
