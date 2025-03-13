using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public bool bateuParede; 
    public bool desce; 

    public float velocidadeInimigos = 0.8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bateuParede = false;
        desce = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
