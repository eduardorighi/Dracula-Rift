using UnityEngine;
using System.Collections;

public class MapControler : MonoBehaviour {

    public bool isGhost = false;
    public bool isHunter = false;

    private GameObject ghost;
    private GameObject hunter;
    private GameObject firstCamera;
    private GameObject startUI;
    private GameObject canvas;

    void Awake()
    {
        GameObject.Find("Canvas").gameObject.GetComponentInChildren<BlackFade>().CallStartBlackScreen();
        ghost = GameObject.Find("Ghost").gameObject;
        hunter = GameObject.Find("Hunter").gameObject;
        firstCamera = GameObject.Find("Camera").gameObject;
        startUI = GameObject.Find("StartUI").gameObject;
        canvas = GameObject.Find("Canvas").gameObject;

        hunter.SetActive(false);
        ghost.SetActive(false);
    }

    public void CallIsGhost()
    {
        isGhost = true;
        ghost.SetActive(true); // Set Active Ghost
        DisableUI();
    }

    public void CallIsHunter()
    {
        isHunter = true;
        hunter.SetActive(true); // Set Active Ghost
        DisableUI();
    }

    public void EndGame()
    {
        canvas.GetComponentInChildren<BlackFade>().CallStartBlackScreen(); // FadeOut
        // Play music
    }

    void DisableUI()
    {
        firstCamera.SetActive(false); // Disable UI Camera
        startUI.SetActive(false); // Disable UI
        canvas.GetComponentInChildren<BlackFade>().CallEndBlackScreen(); // FadeOut
    }

}
