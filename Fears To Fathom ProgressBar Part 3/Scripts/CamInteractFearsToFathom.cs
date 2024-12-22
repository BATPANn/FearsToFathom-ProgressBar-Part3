using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Cinemachine;
using UnityStandardAssets.Characters.FirstPerson;


public class CamInteractFearsToFathom : MonoBehaviour
{


    // Lookat Check

    public bool TalkToActualManeq = false;
    public bool TalkToRedManeq = false;

    // Lookat Check

    public LookAtFunction LookAtScript;

    public Text InteractionText;

    private float InteractDistance = 5f;

    public bool CanInteract = true;

    // look at


    public CinemachineVirtualCamera PlayerVcam;
    public CinemachineVirtualCamera TalkZoomVcam;
    public CinemachineVirtualCamera RedManeqZoomVcam;

    public FirstPersonController FpsController;


    // look at


    // talk 

    public GameObject TalkPanel;

    public GameObject ChoicePack;

    public Text SubText;
    string holder;
    float time = 0.05f;


    // talk 

    // audio

    public AudioSource TalkSource;


    // audio


    // added Part 3 ProgressBar


    public FearsToFathomProgressBar ProgressScript;

     // added Part 3 ProgressBar


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(CanInteract == true)
        {


            Ray ray1 = new Ray(transform.position, transform.forward);
            RaycastHit hit1;

            if(Physics.Raycast(ray1, out hit1, InteractDistance))
            {


                if (hit1.collider.CompareTag("Maneq"))
                {

                    InteractionText.text = "Talk To Him";

                    // talk to him

                    if(Input.GetKeyDown(KeyCode.E))
                    {

                        CanInteract = false;


                        // added Part 3 Progress

                        InteractionText.text = "";

                        ProgressScript.TalkManeqProgressVoid();


                        // added Part 3 Progress

                       // StartCoroutine(TalkToManeqCO());


                    }

                    // talk to him


                }
                else if (hit1.collider.CompareTag("RedManeq"))
                {


                    InteractionText.text = "Talk to Red Maneq";

                    // talk to him



                    if(Input.GetKeyDown(KeyCode.E))
                    {


                        CanInteract = false;
                        StartCoroutine(TalkToRedManeqCO());


                    }


                    // talk to him


                }
                else
                {

                    InteractionText.text = "";


                }



            }
            else
            {

                InteractionText.text = "";

            }





        }



        
    }




    IEnumerator TalkToRedManeqCO()
    {


        // check bool

        TalkToRedManeq = true;

        // check bool


        InteractionText.text = "";
        FpsController.enabled = false;
        RedManeqZoomVcam.enabled = true;
        PlayerVcam.enabled = false;
        TalkZoomVcam.enabled = false;

        // look at

        LookAtScript.IKActive = true;

        // look at


        yield return new WaitForSeconds(1f);


        TalkPanel.SetActive(true);

        // audio

        TalkSource.Play();

        // audio

        SubText.text = "Me: ";
        holder = "Hello, Why are you red ?";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        // audio

        TalkSource.Stop();

        // audio


        yield return MousePress();

        TalkSource.Play();

        SubText.text = "Maneq: ";
        holder = "I'm Red cause he wants me to be Red";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        TalkSource.Stop();

        yield return MousePress();

        StartCoroutine(FinalCO());


    }



    public void TalkToManeqVoid()
    {

        StartCoroutine(TalkToManeqCO());


    }


    IEnumerator TalkToManeqCO()
    {



        // check bool

        TalkToActualManeq = true;

        // check bool


        InteractionText.text = "";
        FpsController.enabled = false;
        TalkZoomVcam.enabled = true;
        PlayerVcam.enabled = false;
        RedManeqZoomVcam.enabled = false;

        // look at

        LookAtScript.IKActive = true;

        // look at


        yield return new WaitForSeconds(1f);


        FpsController.enabled = false;

        // cursor

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // cursor

        TalkPanel.SetActive(true);

        // audio

        TalkSource.Play();

        // audio

        SubText.text = "Me: ";
        holder = "Hello, are you OK ?";
        foreach(char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        // audio

        TalkSource.Stop();

        // audio


        yield return MousePress();


        TalkSource.Play();

        SubText.text = "Maneq: ";
        holder = "Yeah I'm fine.";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        TalkSource.Stop();

        yield return MousePress();

        TalkSource.Play();

        SubText.text = "Maneq: ";
        holder = "Are you lost ?";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        TalkSource.Stop();

        yield return new WaitForSeconds(1f);


        ChoicePack.SetActive(true);



        // reset

        ProgressScript.ResetProgressBarVoid();

        // reset

        


    }



    public void Choice1Void()
    {

        StartCoroutine(Choice1CO());


    }

    public void Choice2Void()
    {


        StartCoroutine(Choice2CO());


    }


    IEnumerator Choice1CO()
    {

        ChoicePack.SetActive(false);


        TalkSource.Play();

        SubText.text = "Me: ";
        holder = "No, I'm a local";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        TalkSource.Stop();

        yield return new WaitForSeconds(3f);


        StartCoroutine(FinalCO());


    }

    IEnumerator Choice2CO()
    {


        ChoicePack.SetActive(false);

        TalkSource.Play();

        SubText.text = "Me: ";
        holder = "Yes, I will ask for help later.";
        foreach (char c in holder)
        {

            SubText.text += c;
            yield return new WaitForSeconds(time);


        }

        TalkSource.Stop();

        yield return new WaitForSeconds(3f);

        StartCoroutine(FinalCO());


    }


    IEnumerator FinalCO()
    {


        // check bool


        TalkToRedManeq = false;
        TalkToActualManeq = false;

        // check bool


        TalkPanel.SetActive(false);
        FpsController.enabled = true;
        ChoicePack.SetActive(false);
        SubText.text = "";

        // look at

        LookAtScript.IKActive = false;

        // look at

        FpsController.enabled = true;
        PlayerVcam.enabled = true;
        TalkZoomVcam.enabled = false;
        RedManeqZoomVcam.enabled = false;

        CanInteract = true;

        yield return null;


    }



    IEnumerator MousePress()
    {



        while(!Input.GetMouseButtonDown(0))
        {


            yield return null;



        }


    }




}
