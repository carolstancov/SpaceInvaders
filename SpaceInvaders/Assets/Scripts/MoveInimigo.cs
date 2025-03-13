using UnityEngine;

public class MoveInimigo : MonoBehaviour
{

    private float contMove = 0; 
    

    gamemanager gManager;

    GameObject inObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<gamemanager>(); 
        inObj = GameObject.Find("Inimigos");
    }

    // Update is called once per frame
    void Update()
    {
        contMove += Time.deltaTime; 


        if(contMove > 0.25)
        {
            if(gManager.bateuParede == false)
            {
                if (gManager.desce == false)
                {
                    transform.position += new Vector3(.2f, 0, 0); 
                    contMove = 0; 
                }
                else
                {
                    transform.position += new Vector3(.2f, 0, 0);
                    inObj.transform.position += new Vector3(0, -1, 0); 
                    gManager.desce = false; 
                    contMove = 0;
                }
            }else if(gManager.bateuParede == true)
            {
                if (gManager.desce == false)
                {
                    transform.position += new Vector3(-.2f, 0, 0); 
                    contMove = 0; 
                }
                else
                {
                    transform.position += new Vector3(-.2f, 0, 0);
                    inObj.transform.position += new Vector3(0, -1, 0); 
                    gManager.desce = false; 
                    contMove = 0;
                    

                }
            }         
        }
    }

    void OnTriggerEnter2D (Collider2D outro)
    {
        if(outro.gameObject.tag == "ParedeDireita")
        {
            gManager.bateuParede = true;
            gManager.desce = true;
        }else if (outro.gameObject.tag == "ParedeEsquerda")
        {
            gManager.bateuParede = false;
            gManager.desce = true; 
        }

        if (outro.gameObject.tag == "Bala")
        {
            Destroy(gameObject);
            outro.gameObject.SetActive(false);
        }
    }
}
