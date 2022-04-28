using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRoom3 : MonoBehaviour
{
    [SerializeField]
    private string room3 = "Room Three";
    
    void OnMouseDown()
    {
        SceneManager.LoadScene(room3);
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0) && Camera.main) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                Debug.Log(hit.collider.gameObject.name);
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }
    }
}

