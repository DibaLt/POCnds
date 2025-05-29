using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlluminatePulseFeedback : MonoBehaviour
{
    public float pulseSpeed = 1f;
    public float maxIntensity = 2f;
    public float minIntensity = 0.5f;

    private Renderer objectRenderer;
    private Material material;
    private bool isPlayerInRange = false;
    private bool hasBeenClicked = false;
    private float timeElapsed = 0f;

    private float timer = 0f;
    private bool hasTimerOn = false;

    private GameObject objectToIlluminate;

    // Start is called before the first frame update
    void Start()
    {
        //objectToIlluminate = transform.GetChild(0).gameObject;
        objectToIlluminate = transform.gameObject;

        Renderer childRenderer = objectToIlluminate.GetComponent<Renderer>();
        if(childRenderer != null){
        material = childRenderer.material;

        material.EnableKeyword("_EMISSION");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenClicked) return;

        else {

            if(isPlayerInRange){
                            
                if(hasTimerOn == false){
                    hasTimerOn = true;
                }

                timer += Time.deltaTime;
                
                if(timer >= 20){
                timeElapsed += Time.deltaTime * pulseSpeed;
                float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(timeElapsed, 1f));

                material.SetColor("_EmissionColor", Color.white * intensity*0.2f);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        
            isPlayerInRange = true;
    }

    void OnTriggerExit(Collider other) {
        
            isPlayerInRange = false;

            material.SetColor("_EmissionColor", Color.black);
    }

    public void onClick(){

        if(!hasBeenClicked){
            hasBeenClicked = true;
            timer = 0;
            material.SetColor("_EmissionColor", Color.black);
        }

    }
}
