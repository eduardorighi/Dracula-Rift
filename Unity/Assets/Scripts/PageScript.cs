using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PageScript : MonoBehaviour {

    public List<GameObject> footprints = new List<GameObject>();
    public GameObject Left;
    public GameObject Right;

    int count = 0;

	// Use this for initialization
	void Start () {

        foreach (Transform child in transform)
        {
            footprints.Add(child.gameObject);
        }
	
	}

    public void CallScript() { 
        StartCoroutine(Clicked());
    }

    IEnumerator Clicked()
    {
        float overTime = 0.5f;
        float t = 0.0f;

        while (t < overTime)
        {
            t += Time.deltaTime * (Time.timeScale / overTime);

            yield return 0;
        }

        InstantiateFootprint();
        StopCoroutine("Clicked");
        StartCoroutine(Clicked());
    }

    void InstantiateFootprint()
    {

        if (footprints[count].gameObject.GetComponent<Footstep>().side == 0)
        {
            GameObject temp = Instantiate(Right) as GameObject;
            temp.transform.parent = footprints[count].gameObject.transform;
            temp.transform.position = footprints[count].gameObject.transform.position;
            temp.transform.localScale = new Vector3(1,1,1);
            float val = footprints[count].gameObject.transform.eulerAngles.y - temp.transform.eulerAngles.y;
            if (footprints[count].gameObject.transform.eulerAngles.y != 0)
                temp.transform.Rotate(new Vector3(0, val + 170, 0), Space.World);
        }
        else
        {
            GameObject temp = Instantiate(Left) as GameObject;
            temp.transform.parent = footprints[count].gameObject.transform;
            temp.transform.position = footprints[count].gameObject.transform.position;
            temp.transform.localScale = new Vector3(1, 1, 1);
            float val = footprints[count].gameObject.transform.eulerAngles.y - temp.transform.eulerAngles.y;
            if (footprints[count].gameObject.transform.eulerAngles.y != 0)
                temp.transform.Rotate(new Vector3(0, val, 0), Space.World);

        }

        if (footprints.Count == count)
            StopCoroutine("Clicked");

        count++;

    }






}
