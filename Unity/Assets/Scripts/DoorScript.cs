using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    [HideInInspector]
    public float BeingLookedDistance;
    [HideInInspector]
    public bool HasCrusifix = false;

    GameObject Crusifix;

    public int DoorBash;
    public int DoorSide;
    public bool DoorCheck;


    void Start()
    {
        Crusifix = GameObject.Find("Crusifix").gameObject;
        gameObject.GetComponent<Animator>().SetInteger("Bash", DoorBash);
    }

    public void CallScript() {
        //HasCrusifix = val;
        OpenDoor2();
    }

    void OpenDoor2()
    {
        if (BeingLookedDistance <= 3)
        {

            if (DoorCheck == false)
            {
                if (DoorSide == 2)
                {
                    if (DoorBash > 0) { gameObject.GetComponent<Animator>().SetInteger("Bash", 4); }
                    else if (GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerInventory>().pickedObjects.Contains(Crusifix))
                    {
                        gameObject.GetComponent<Animator>().SetInteger("DoorStates", 2); // 2 is the Right side (Open Door)
                    }
                }
                if (DoorSide == 1)
                {
                    if (DoorBash > 0) { gameObject.GetComponent<Animator>().SetInteger("Bash", 2); }
                    else if (GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerInventory>().pickedObjects.Contains(Crusifix))
                    {
                        gameObject.GetComponent<Animator>().SetInteger("DoorStates", 1); // 1 is the Left side (Open Door)
                    }
                }
            }
            else
            {
                //Play audio
            }
        }
    }

	
}
