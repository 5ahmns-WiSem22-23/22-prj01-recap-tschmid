using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 5f;

    [Header("carsettings")]
    public float driftFac = 0.95f;
    public float accelerationFac = 8f;
    public float turnFac = 4f;

    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    Rigidbody2D carRigidbody2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speed"))
            StartCoroutine(wait(waitTime));
    }

    IEnumerator wait(float waitTime)
    {
        accelerationFac = 15f;
        yield return new WaitForSeconds(waitTime);
        accelerationFac = 8f;
    }

    void Awake()
    {
        //läd den Rigidbody des Autos

        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //führt Funktionen unabhängig der Framerate aus

        ApplyEngineForce();

        KillOrthoVel();

        ApplySteering();
    }

    void ApplyEngineForce()
    {
        //auto wird langsamer wenn kein Gas gegeben wird
        if (accelerationInput == 0)
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        else carRigidbody2D.drag = 0;
        //auto beschleunigung
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFac;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {

        //auto kann sich am stand nicht im kreis drehen
        float minSpeedForTurn = (carRigidbody2D.velocity.magnitude / 8);
        minSpeedForTurn = Mathf.Clamp01(minSpeedForTurn);
        //auto lenkung
        rotationAngle -= steeringInput * turnFac * minSpeedForTurn;

        carRigidbody2D.MoveRotation(rotationAngle);
    }

    void KillOrthoVel()
    {
        //sorgt für ein besseres handling des autos, da die velocity nach außen (fliehkräfte) gedämpft werden ähnlich wie bei einem echten Auto wegen wiederstand der Reifen
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);
       
        carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFac;
    }
    public void SetInputVector(Vector2 inputVector)
    {
        //übernimmt die eingaben des spielers aus "CarInputHandler.cs"

        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
