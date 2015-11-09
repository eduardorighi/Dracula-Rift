using UnityEngine;
using System.Collections;

public class RockButton : MonoBehaviour {

    public GameObject Rock1;
    public GameObject Rock2;

    public void CallClicked()
    {
        gameObject.SetActive(false); // Disable Object
        Rock1.GetComponent<Rocks>().CallShake();
        Rock2.GetComponent<Rocks>().CallShake();
    }


}
