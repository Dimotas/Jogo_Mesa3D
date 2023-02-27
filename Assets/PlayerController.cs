using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private int count;
    public GameObject GameOverText;
    public Text txtCount;
    public Text txtCena;
    Scene m_Cena;
    int[] quantos = { 12, 5, 8 };
    string[] nome = { "Cena 1", "Cena 2", "Cena 3" };


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 20.0f;
        m_Cena = SceneManager.GetActiveScene();
        count = quantos[m_Cena.buildIndex];
        txtCena.text = nome[m_Cena.buildIndex];
        txtCount.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(MoveH, 0.0f, MoveV);
        rb.AddForce(move * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        count--;
        txtCount.text = count.ToString();
        if (count == 0) 
            GameOverText.SetActive(true);
    }
}
