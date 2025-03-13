using UnityEngine;

public class Tiros : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velTiro;
    public float tempoVida;

    void OnEnable()
    {
        Invoke("Desligar", tempoVida);
    }
    void Desligar()
    {
        gameObject.SetActive(false);
    }

    void OnDisabled()
    {
        CancelInvoke();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, velTiro, 0) * Time.deltaTime;
    }
}
