using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject prefabCube;
    private Rigidbody rb;
    public Text tempo;
    public float speed;
    public Text numCubos;
    public float time;
    public bool playing;
    private int cubos;
    private int numcubos;
    void Start()
    {
        playing = true;
        rb = GetComponent<Rigidbody>();
        tempo = FindObjectOfType<Text>();
        speed = 25.0f;
        cubos = 10;
        GerarCubos(cubos);
    }
    void Update()
    {
        if (playing)
        {
            numCubos.text = numcubos.ToString();
            time -= Time.deltaTime;
            tempo.text = "Time : " + time.ToString("F2") + "s";
            if (time <= 0.01)
            {
                DeleteAll();
                playing = false;
                tempo.text = "Perdeste!!";
                tempo.color = Color.red;
            }

        }
    }
    void DeleteAll()
    {
        GameObject[] generatedcubos = GameObject.FindGameObjectsWithTag("cubo");
        for (int i = 0; i < generatedcubos.Length; i++)
        {
            Destroy(generatedcubos[i]);
        }
    }
    void GerarCubos(int quantos)
    {
        time = 10.0f;
        for (int i = 0; i < quantos; i++)
        {
            Vector3 randomposition = new Vector3(Random.Range(-8f, 8f), 0.5f, Random.Range(-8f, 8f));
            Instantiate(prefabCube, randomposition, Quaternion.identity);
        }
        numcubos = quantos;
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cubo")
        {
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            numcubos--;
            time++;
            print("Cubos em falta : " + numcubos);
        }
        if (numcubos == 0)
        {
            GerarCubos(++cubos);
        }
    }
}
