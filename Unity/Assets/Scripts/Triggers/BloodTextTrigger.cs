using UnityEngine;
using System.Collections;

public class BloodTextTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        gameObject.transform.parent.gameObject.GetComponent<BloodText>().CallScript();
    }

}
