using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocks : MonoBehaviour {

    public void CallShake() { StartCoroutine(ShakeRock()); }

    IEnumerator ShakeRock() {

        float overTime = 1f;
        float t = 0.0f;

        while (t < overTime)
        {
            t += Time.deltaTime * (Time.timeScale / overTime);

            float AngleAmount = (Mathf.Cos(Time.time * 1000) * 180) / Mathf.PI * 0.5f;
            Debug.Log("Rotation " + AngleAmount);
            AngleAmount = Mathf.Clamp(AngleAmount, -2, 1);
            gameObject.transform.localRotation = Quaternion.Euler(AngleAmount, AngleAmount, AngleAmount);

            yield return 0;
        }

        StopCoroutine("ShakeRock");
        ResetPos();
    }

    void ResetPos()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }


}
