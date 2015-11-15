using UnityEngine;
using System.Collections;

public class WaterDoor : MonoBehaviour {

    public void CallAnimation()
    {
        gameObject.GetComponent<Animator>().SetInteger("State", 1);
    }

}
