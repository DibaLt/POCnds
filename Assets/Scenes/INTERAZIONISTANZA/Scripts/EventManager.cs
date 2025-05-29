using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EventManager : MonoBehaviour
{

    [SerializeField] GameObject bosco;
    [SerializeField] GameObject nebbia;
    [SerializeField] GameObject terraBruciata;
    [SerializeField] GameObject paretiDivietoBosco;
    [SerializeField] GameObject esondazione;
    [SerializeField] GameObject pioggia;
    [SerializeField] GameObject onda;
    [SerializeField] GameObject zonaSicura;
    [SerializeField] GameObject frana;
    [SerializeField] GameObject stopFrana;

    //Variabili per l'incendio
    public bool panelFire = false;
    public bool anemometerFire = false;
    public bool windFire = false;
    public bool startFire = false;
    public bool safeFire = false;

    // Variabili per l'inondazione
    public bool panelFlood = false;
    public bool pluviometerFlood = false;
    public bool anemometerFlood = false;
    public bool startFlood = false;
    public bool safeFlood = false;

    // Variabili per la frana
    public bool panelRock = false;
    public bool pluviometerRock = false;
    public bool anemometerRock = false;
    public bool windRock = false;
    public bool startRock = false;
    public bool safeRock = false;

    private FireController fireController;
    private FloodController floodController;
    private MoveWave moveWave;
    private RockSpawner rockSpawner;

    void Start(){
        fireController = bosco.GetComponent<FireController>();
        floodController = esondazione.GetComponent<FloodController>();
        moveWave = onda.GetComponent<MoveWave>();
        rockSpawner = frana.GetComponent<RockSpawner>();
    }
    void Update()
    {
        // Gestione dell'incendio
        if(panelFire==true && startFire==false){
            fireController.StartFire();
            nebbia.SetActive(true);
            terraBruciata.SetActive(true);
            paretiDivietoBosco.SetActive(true);
            startFire =true;
        }

        if (startFire == true && safeFire == true)
        {
            fireController.StopFire();
            startFire = false;
            panelFire =false;
            anemometerFire=false;
            windFire=false;
            nebbia.SetActive(false);
        }

        // Gestione dell'Inondazione (Flood)
        if (panelFlood && !startFlood)
        {
            // Inizia l'inondazione
            zonaSicura.SetActive(true);
            onda.SetActive(true);
            floodController.StartFlood();
            moveWave.StartMovement();
            startFlood =true;

            // Resetta le variabili
            panelFlood = false;
            pluviometerFlood = false;
            anemometerFlood = false;
        }

        if (startFlood && safeFlood)  
        {
            // Ferma l'inondazione
            pioggia.SetActive(false);  // Disattiva la pioggia
            floodController.StopFlood();
            startFlood = false;
        }

        //Gestione della frana
        if (panelRock && !startRock)
        {
            // Inizia la frana
            rockSpawner.StartSpawn();
            startRock = true;
            stopFrana.SetActive(true);

            // Resetta le variabili
            panelRock = false;
            pluviometerRock = false;
            anemometerRock = false;
        }

        if (startRock && safeRock) 
        {
            // Ferma la frana
            rockSpawner.StopSpawn();  // Disattiva la frana
            startRock = false;
        }        

    }

    // Funzioni per verificare le variabili di fuoco
    public void CheckPanelFire()
    {
        if (anemometerFire == true && windFire == true){
            panelFire = true;
        }
    }

    public void CheckAnemometerFire()
    {
        anemometerFire = true;
    }

    public void CheckWindFire()
    {
        windFire = true;
    }

    public void CheckSafeFire()
    {
        Debug.Log("Chiamata");
        if (anemometerFire == true && windFire == true && panelFire == true)
        {
            Debug.Log("DEntro");
            safeFire = true;
        }
    }

    // Funzioni per verificare le variabili di inondazione
    public void CheckPanelFlood()
    {
        if (pluviometerFlood && anemometerFlood){
            panelFlood = true;
        }
    }

    public void CheckPluviometerFlood()
    {
        pluviometerFlood = true;
    }

    public void CheckAnemometerFlood()
    {
        anemometerFlood = true;
    }

    public void CheckSafeFlood()
    {
        safeFlood = true;
    }

    // Funzioni per verificare le variabili di frana
    public void CheckPanelRock()
    {
        if (pluviometerRock && anemometerRock){
            panelRock = true;
        }
    }

    public void CheckPluviometerRock()
    {
        pluviometerRock = true;
    }

    public void CheckAnemometerRock()
    {
        anemometerRock = true;
    }

    public void CheckWindRock()
    {
        windRock = true;
    }

    public void CheckSafeRock()
    {
        safeRock = true;
    }
}
