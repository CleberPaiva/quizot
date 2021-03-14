using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Material material;
    public float velocidadeX, velocidadeY;
    public float incremento;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
