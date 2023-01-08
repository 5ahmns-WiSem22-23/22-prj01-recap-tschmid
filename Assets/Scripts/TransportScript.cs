using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{
    public bool occupied;
    public GameManager script;
    public GameObject dropoffZone;
    public GameObject pickedUpObj;
    public GameObject car;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") && occupied==false)
        {
            occupied = true;
            Destroy(collision.gameObject.GetComponent<Collider2D>());
            pickedUpObj = collision.gameObject;
            pickedUpObj.gameObject.transform.SetParent(car.transform);
            pickedUpObj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            pickedUpObj.gameObject.transform.localRotation = Quaternion.identity;
        }
        else if (collision.CompareTag("Target") && occupied)
        {
            script.pickUpCount++;
            occupied = false;
            gameObject.transform.GetChild(0).transform.SetParent(dropoffZone.transform);
            pickedUpObj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            pickedUpObj.gameObject.transform.localRotation = Quaternion.identity;
            pickedUpObj = null;
        }
        else
        {

        }
    }
}
