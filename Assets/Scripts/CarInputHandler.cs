using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{

    TopDownCarController topDownCarController;

    void Awake()
    {

        //läd TopDownCarController
        topDownCarController = GetComponent<TopDownCarController>();
    }

    void Update()
    {
        //setzt inputaxen
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        topDownCarController.SetInputVector(inputVector);
    }
}
