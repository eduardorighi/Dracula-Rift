using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {

    public GameObject Child;

    public void CallLight() { StartCoroutine(LightCandle()); }

    IEnumerator LightCandle()
    {
        float overTime = 3f;
        float t = 0.0f;

        Child.SetActive(true);

        while (t < overTime)
        {
            t += Time.deltaTime * (Time.timeScale / overTime);
            yield return 0;
        }

        Child.SetActive(false);
        StopCoroutine("LightCandle");

    }


}
