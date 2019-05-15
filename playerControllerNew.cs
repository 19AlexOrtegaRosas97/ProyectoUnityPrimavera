using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControllerNew : MonoBehaviour
{
    public float speed = 3.5f;
    public float gravity = 10f;
    private CharacterController controller;
    private int count=0;
    private int countFogata = 0;
    private int countDisponible = 8;
    public Text countText;
    public Text winText;
    public Text fogataText;
    public GameObject cubetaMano;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        count = 0;
        countText.text = "Cubetas : " + count.ToString() + "/"+countDisponible;
        fogataText.text = "Fogatas : " + countFogata.ToString() + "/8";
        winText.text = "";
        cubetaMano.SetActive(false);
    }
        
    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 diretion = new Vector3(horizontal, zMov*5, vertical);
        Vector3 velocity = diretion * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
        countText.text = "Cubetas : " + count.ToString() + "/" + countDisponible;
        fogataText.text = "Fogatas : " + countFogata.ToString() + "/8";
        if (countFogata == 8)
        {
            winText.text = "Salvaste el Bosque!!!";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countText.text = "Cubetas : " + count.ToString() + "/"+countDisponible;
            cubetaMano.SetActive(true);
        }

        if (other.gameObject.CompareTag("fogata"))
        {   if (count > 0)
            {
                other.gameObject.SetActive(false);
                countFogata += 1;
                count -= 1;
                countDisponible -= 1;
                fogataText.text = "Fogatas : " + countFogata.ToString() + "/8";
                if (count == 0)
                {
                    cubetaMano.SetActive(false);
                }
            }
        }
    }
}
