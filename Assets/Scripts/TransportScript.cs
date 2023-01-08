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
        if (collision.CompareTag("Item") && !occupied)
        {
            //auto ist besetzt
            occupied = true;
            //colider des gift's wird gelöscht
            Destroy(collision.gameObject.GetComponent<Collider2D>());
            //gift objekt wird in pickedUpObj geladen
            pickedUpObj = collision.gameObject;
            //gift wird child von car und position wird zurückgesetzt
            pickedUpObj.gameObject.transform.SetParent(car.transform);
            pickedUpObj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            pickedUpObj.gameObject.transform.localRotation = Quaternion.identity;
        }
        else if (collision.CompareTag("Target") && occupied)
        {
            //pickUpCount +1
            script.pickUpCount++;
            //auto ist nichtmehr besetzt
            occupied = false;
            //auto wird als child der dropoff zone gesetzt
            gameObject.transform.GetChild(0).transform.SetParent(dropoffZone.transform);
            //postition wird zurückgesetzt
            pickedUpObj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
            pickedUpObj.gameObject.transform.localRotation = Quaternion.identity;
            //pickedUpObj wird gecleared
            pickedUpObj = null;
        }
        else
        {
            //falls gift schon aufgenommen wurde und das auto mit einem anderen gift collided voided die Funktion
        }
    }
}
