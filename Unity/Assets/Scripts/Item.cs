using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    [HideInInspector]
    public bool Clicked = false;
    [HideInInspector]
    public bool AlreadyClicked = false;

    public GameObject PlayerObj;
    public Shader GlowShader;
    
    Shader DefaultShader;
    Renderer Renderer;

    public float BeingLookedDistance = 10000;
    bool IsLooking = false;

    void Start()
    {
        Renderer = gameObject.GetComponent<Renderer>();
        DefaultShader = Renderer.material.shader;
    }

    // Update is called once per frame
    void Update()
    {
        if (!AlreadyClicked) 
            CheckClick();
        CheckGlow();

    }

    void CheckClick() {

        if (Clicked == true) {

           
            AlreadyClicked = true; // Stop checking for click every update

            if (gameObject.name == "Rock1") { // If is the LEFT Rock
                
                CheckInventoryForRock(gameObject); // Add Obj to player inventory
            
            }

            if (gameObject.name == "Rock2") { // If is the RIGHT Rock
                
                CheckInventoryForRock(gameObject);

            }

            if (gameObject.name == "Garlic")
            {
                gameObject.SetActive(false); // Disable Object
                AddObjectToPlayerInventory(gameObject);
            }

            if (gameObject.name == "Crusifix")
            {
                gameObject.SetActive(false); // Disable Object
                AddObjectToPlayerInventory(gameObject);
            }

            if (gameObject.name == "Knife")
            {
                gameObject.SetActive(false); // Disable Object
                AddObjectToPlayerInventory(gameObject);
            }

            if (gameObject.name == "Wood")
            {
                gameObject.SetActive(false); // Disable Object
                AddObjectToPlayerInventory(gameObject);
            }

            if (gameObject.name == "Page4")
            {
                gameObject.GetComponent<PageScript>().CallScript();
            }

            //Check if has all items (End Game)
            PlayerObj.GetComponent<PlayerInventory>().CheckInventoryForEndGame();

        }
    
    }

    void CheckInventoryForRock(GameObject obj)
    {

        bool haveRock = false;

        foreach (GameObject x in PlayerObj.GetComponent<PlayerInventory>().pickedObjects)
        {
            if (x.name == "Rock1" || x.name == "Rock2")
            {
                haveRock = true;
                AddRockToInvetory(obj);
                RemoveRockFromInvetory(x);
            }
        }

        if (!haveRock)
        {
            AddRockToInvetory(obj);
        }
            
    }

    void AddRockToInvetory(GameObject obj)
    {
        gameObject.SetActive(false); // Disable Object
        PlayerObj.GetComponent<PlayerInventory>().pickedObjects.Add(obj);
    }

    void RemoveRockFromInvetory(GameObject obj)
    {
        obj.SetActive(true); // Disable Object
        obj.GetComponent<Item>().AlreadyClicked = false;
        obj.GetComponent<Item>().Clicked = false;
        PlayerObj.GetComponent<PlayerInventory>().pickedObjects.Remove(obj);
    }

    void AddObjectToPlayerInventory(GameObject obj) { // Add Obj to player inventory

        PlayerObj.GetComponent<PlayerInventory>().pickedObjects.Add(obj);
    
    }

    void OnMouseEnter()
    {
        IsLooking = true;     
    }

    void OnMouseExit()
    {
        IsLooking = false;
    }

    void CheckGlow()
    {

        if ((BeingLookedDistance <= 3 && BeingLookedDistance > 0) && IsLooking) // "> 0" to correct a bug that is making some twitch moves as 0
        {
            Renderer.material.shader = GlowShader;
            //Debug.Log(BeingLookedDistance + " - " + IsLooking);
        }
            
        if (BeingLookedDistance > 3 || IsLooking == false)
            Renderer.material.shader = DefaultShader;
    }

}
