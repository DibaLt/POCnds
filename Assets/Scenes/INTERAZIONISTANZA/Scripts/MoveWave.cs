using UnityEngine;

public class MoveWave : MonoBehaviour
{
    public GameObject targetObject;    // Oggetto da muovere (assegnabile in Inspector)
    [SerializeField] GameObject fiumeMarrone;
    public float distance = 1000f;     // Distanza da percorrere in metri
    public float duration = 30f;       // Tempo impiegato per percorrere la distanza

    public bool startMove = false;     // Booleano che attiva il movimento

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float elapsedTime;
    private bool isMoving = false;
    private bool hasMoved = false;
    private bool triggeredDistanceCheck = false;

    private ColorWater colorWater;

    void Start(){
        colorWater = fiumeMarrone.GetComponent<ColorWater>();
    }
    void Update()
    {
        if (startMove && !isMoving && !hasMoved && targetObject != null)
        {
            StartMovement();
        }

        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            targetObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

        float currentDistance = Vector3.Distance(startPosition, targetObject.transform.position);

        if (currentDistance >= 270f && !triggeredDistanceCheck)
            {
                triggeredDistanceCheck = true;
                OnDistanceReached();
            }

        if (t >= 1f)
            {
                isMoving = false;
                hasMoved = true;
                targetObject.SetActive(false); // Disattiva l’oggetto alla fine
            }
        }
    }

    public void StartMovement()
    {
        startPosition = targetObject.transform.position;
        targetPosition = startPosition + Vector3.right * distance;
        elapsedTime = 0f;
        isMoving = true;
    }

    private void OnDistanceReached()
    {
        colorWater.ChangeMaterial();
    }
}