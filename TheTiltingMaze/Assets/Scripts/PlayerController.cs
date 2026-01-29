using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private Rigidbody rigidBody;
    private int count;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void SetCountText() {
        countText.text = "Score: " + count.ToString() + "/6";
        if (count >= 6) {
            winTextObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("pickup")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("trap"))
        {
            this.gameObject.SetActive(false);
            loseTextObject.SetActive(true);
        }
    }
}
