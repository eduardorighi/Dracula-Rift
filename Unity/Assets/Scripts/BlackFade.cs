using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour {

    bool IsTeleport = false;
    bool IsStart = true;

    public void CallTeleportToDracula()
    {
        StartCoroutine(FadeIn());
        IsTeleport = true;
    }

    public void CallStartBlackScreen()
    {
        StartCoroutine(FadeIn());
    }

    public void CallEndBlackScreen()
    {
        StartCoroutine(FadeOut());
    }

    void CheckNextStep()
    {
        if (IsTeleport)
        {
            GameObject.Find("Hunter").gameObject.transform.position = GameObject.Find("DraculaTeleport").gameObject.transform.position;
            StartCoroutine(FadeOut());
            IsTeleport = false;
        }
        if (IsStart)
        {
            IsStart = false;
        }
    }

    IEnumerator FadeIn()
    {
        float t = 0.0f;
        float amount = 0.05f;

        while (t < 1)
        {
            t += amount;
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, t);
            yield return 0;
        }

        StopCoroutine("FadeIn");
        CheckNextStep();
    }

    IEnumerator FadeOut()
    {
        float t = 1.0f;
        float amount = 0.05f;

        while (t > 0)
        {
            t -= amount;
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, t);
            yield return 0;
        }

        StopCoroutine("FadeOut");

    }


}
