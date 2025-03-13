using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class MovePlayer : MonoBehaviour
{
    public float movSpeed = 5.0f; // Velocidade de movimento
    private bool movingRight = true; // Direção do movimento

    public float tiroInicial;
    public float tiroContinuo;
    public GameObject tiros;

    public int numeroTiros;
    List<GameObject> listaTiros;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        listaTiros = new List<GameObject>();

        for (int i = 0; i < numeroTiros; i++)
        {
            GameObject obj = (GameObject)Instantiate(tiros);
            obj.SetActive(false);
            listaTiros.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Atualize a posição do jogador
        float posX = transform.position.x;

        if (movingRight)
        {
            posX += movSpeed * Time.deltaTime;
        }
        else
        {
            posX -= movSpeed * Time.deltaTime;
        }

        // Verifique os limites e mude a direção se necessário
        if (posX >= 10)
        {
            movingRight = false;
            posX = 10; // Garante que não ultrapasse o limite
        }
        else if (posX <= -10)
        {
            movingRight = true;
            posX = -10;// Garante que não ultrapasse o limite
        }

        transform.position = new Vector3(posX, -4.3f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Atirar", tiroInicial, tiroContinuo);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Atirar");
        }
    }


    void Atirar()
    {
        for (int i = 0; i < listaTiros.Count; i++)
        {
            if (!listaTiros[i].activeInHierarchy)
            {
                listaTiros[i].transform.position = transform.position;
                listaTiros[i].transform.rotation = transform.rotation;
                listaTiros[i].SetActive(true);
                break;
            }
        }
    }
}
