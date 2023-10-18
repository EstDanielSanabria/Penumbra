using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePlayer : MonoBehaviour
{
    public Transform HeadMarked;
    public Transform ScalePlayerObj;
    public float escalaInicial = 1.0f;
    public float FactorEscala = 0.01f;

    private Vector3 posicionInicial;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = HeadMarked.position;
        float distancia = Vector3.Distance(posicionInicial, ScalePlayerObj.position);

        float factor = escalaInicial + distancia * FactorEscala;

        transform.localScale = new Vector3 (factor, factor, factor);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
