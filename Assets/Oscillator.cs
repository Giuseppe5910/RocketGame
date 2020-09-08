using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Oscillator : MonoBehaviour
{
    [Range(0, 1)][SerializeField] float movementFactor ;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon){ return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawsinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawsinWave / 2f + 0.5f;

        Vector3 offset = movementFactor*movementVector;
        transform.position = startingPos + offset;
    }
}
