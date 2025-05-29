using UnityEngine;

public class FindEventManager : MonoBehaviour
{
    public GameObject eventManager;
    public EventManager eventManagerScript;
    public bool eventManagerFound = false; // Per evitare continue ricerche dopo averlo trovato

    void Update()
    {
        if (!eventManagerFound) // Cerca solo se non è stato già trovato
        {
            FindEventInScene();
        }
    }

    public void setEventManagerSafe()
    {
        if (eventManagerScript != null)
        {
            eventManagerScript.CheckSafeFire();
            Debug.Log("safeFire impostato su true");
        }
        else
        {
            if (eventManagerScript == null)
            {
                if (eventManagerFound == true)
                {
                    FindEventInScene();
                }
            }
        }
    }

    public void FindEventInScene()
    {
        eventManager = GameObject.Find("EventManager");

            if (eventManager != null)
            {
                eventManagerScript = eventManager.GetComponent<EventManager>();

                if (eventManagerScript != null)
                {
                    eventManagerFound = true;
                    Debug.Log("EventManagerScript trovato!");
                }
                else
                {
                    Debug.LogWarning("EventManager trovato, ma manca EventManagerScript!");
                }
            }
    }
}