using UnityEngine;
using System.Collections;

public class PlayerSight : MonoBehaviour {

    [HideInInspector]
    public GameObject lookingAt;
    public Shader GlowShader;
    public GameObject grades;

    void Update()
    {
        Raycast();
        CheckClick();

        //if (Input.GetButtonDown("Fire2") || Input.GetKey("e"))
        //{
        //    Screen.lockCursor = true;
        //}

        //if (Input.GetKey("r"))
        //{
        //    Screen.lockCursor = false;
        //}
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("asdas");
        grades = GameObject.FindGameObjectWithTag("Grade");
        if (col.gameObject.name == "DogTrap")
        {
            grades.transform.position += Vector3.up * 5 * Time.deltaTime;
        }
    }

    void Raycast()
    {
        Transform cam = Camera.main.transform;
        RaycastHit hit;
        Ray ray = new Ray(cam.position, cam.forward);
        if (Physics.Raycast(ray, out hit, 500)) ;
        {
            //Debug.Log(hit.collider.gameObject);
            lookingAt = hit.collider.gameObject;
            
            // Set the distance from item on item script
            if (lookingAt.tag == "Item") lookingAt.GetComponent<Item>().BeingLookedDistance = hit.distance;
            if (lookingAt.tag == "Door") lookingAt.GetComponent<DoorScript>().BeingLookedDistance = hit.distance;
        }
    }

    void CheckClick()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")))
        {
            if (lookingAt.tag == "Item") {
                lookingAt.GetComponent<Item>().Clicked = true;
            }

            if (lookingAt.name == "GhostRockButton")
            {
                lookingAt.GetComponent<RockButton>().CallClicked();
            }

            if (lookingAt.tag == "Candle")
            {
                lookingAt.GetComponent<Candle>().CallLight();
            }

            if (lookingAt.tag == "Door")
            {
                lookingAt.GetComponent<DoorScript>().CallScript();
            }

            if (lookingAt.name == "WaterDoorObject")
            {
                lookingAt.GetComponentInParent<WaterDoor>().CallAnimation();
            }

            if (lookingAt.name == "Coffin") // End Game
            {
                GameObject.Find("MapControler").gameObject.GetComponent<MapControler>().EndGame();
            }

            if (lookingAt.name == "Lock")
            {
                lookingAt.GetComponent<LockScript>().CheckLock(gameObject);
            }
        }
    }


}
