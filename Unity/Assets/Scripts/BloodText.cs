using UnityEngine;
using System.Collections;

public class BloodText : MonoBehaviour {

    bool AlreadyActivated = false;

    void Start() {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
    }

    public void CallScript() { 
        if (!AlreadyActivated)
            StartCoroutine(ShowText());
        AlreadyActivated = true;
    }

    IEnumerator ShowText()
    {
        float t = 0.0f;
        float amount = 0.01f;

        while (t < 1)
        {
            t += amount;
            Debug.Log(t);
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, t);
            yield return 0;
        }

        StopCoroutine("ShowText");

    }

}
