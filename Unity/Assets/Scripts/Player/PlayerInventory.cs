using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {

    public List<GameObject> pickedObjects = new List<GameObject>();

    public void CheckInventoryForEndGame()
    {
        

        if (pickedObjects.Count == 5)
        {
            GameObject.Find("Canvas").gameObject.GetComponentInChildren<BlackFade>().CallTeleportToDracula(); // Call Fade Canvas
            // Block Movement
            // Play Music
        }
    }

}
