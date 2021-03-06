using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingGhost : MonoBehaviour
{
    //[SerializeField] private UIHandler uiHandler;
    public PlayerMovement playerMovement;
    public CameraHandler cameraHandler;
    Animator floatingGhost;

    /// <summary>
    /// TextPrompt script to display info
    /// </summary>
    public TextPrompt Text;
    private bool isFloating;

    private void Awake()
    {
        isFloating = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        floatingGhost = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main && !isFloating)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                if (hit.transform.gameObject == this.gameObject)
                {
                    isFloating = true;
                    floatTheGhost();
                    Debug.Log("floating the ghost x1");
                }
            }
        }
        
    }

    protected void floatTheGhost()
    {
        if (!floatingGhost.enabled)
        {
            // causes floating ghost animation to play
            floatingGhost.enabled = true;
            floatingGhost.Play("FloatingGhost");
        }
    }
}