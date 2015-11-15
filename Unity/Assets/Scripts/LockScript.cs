using UnityEngine;
using System.Collections;

public class LockScript : MonoBehaviour {

    GameObject rock1;
    GameObject rock2;

    void Awake()
    {
        rock1 = GameObject.Find("Rock1").gameObject;
        rock2 = GameObject.Find("Rock2").gameObject;
    }

    public void CheckLock(GameObject player)
    {
        if (player.GetComponent<PlayerInventory>().pickedObjects.Contains(rock1))
        {
            CallShake();
            // Play sound
        }
        else if (player.GetComponent<PlayerInventory>().pickedObjects.Contains(rock2))
        {
            CallShake();
            gameObject.SetActive(false); // "Destroy" lock
            // Play sound
            gameObject.transform.parent.GetComponentInChildren<Animator>().SetBool("Open", true);
        }
    }

    public void CallShake() { StartCoroutine(ShakeLock()); }

    IEnumerator ShakeLock()
    {

        float overTime = 0.5f;
        float t = 0.0f;

        while (t < overTime)
        {
            t += Time.deltaTime * (Time.timeScale / overTime);

            float AngleAmount = (Mathf.Cos(Time.time * 1000) * 180) / Mathf.PI * 0.5f;
            Debug.Log("Rotation " + AngleAmount);
            AngleAmount = Mathf.Clamp(AngleAmount, -3, 3);
            gameObject.transform.localRotation = Quaternion.Euler(AngleAmount, AngleAmount, AngleAmount);

            yield return 0;
        }

        StopCoroutine("ShakeLock");
        ResetPos();
    }

    void ResetPos()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
