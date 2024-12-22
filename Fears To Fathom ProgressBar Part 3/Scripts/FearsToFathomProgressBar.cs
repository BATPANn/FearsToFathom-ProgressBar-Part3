using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FearsToFathomProgressBar : MonoBehaviour
{


    public Slider slider;

    public float duration = 12f; // the time it takes to fill 

    private float pasttime = 0f; // the time that has past

    // added Part 3 

    public bool RunProgress = false; // Check if we can Run Function or not

    public CamInteractFearsToFathom CamInteract; // Refrence To Our CamInteract Script

    private bool DidOnce = false; // Stop Looping

    private bool TalkToManeqFunctionBool = false; // Need one for each function 

    public GameObject Slider_GameObject;

    public Text UnderProgressText;

    // added Part 3 
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Slider_GameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {




        if(RunProgress == true)
        {


            pasttime += Time.deltaTime; // increase 1 each second
            slider.value = Mathf.Clamp01(pasttime / duration); // The actuall function


            if (pasttime >= duration && DidOnce == false)
            {

                Debug.Log("Full");
                DidOnce = true;
                RunProgress = false;

                UnderProgressText.text = "";

                if(TalkToManeqFunctionBool == true)
                {


                    TalkToManeqFunctionBool = false; // do only once
                    Slider_GameObject.SetActive(false); // don't show our progress bar



                    // refrence to cam interact

                    CamInteract.TalkToManeqVoid();


                    // refrence to cam interact


                }






            }


        }

        






    }




    public void TalkManeqProgressVoid()
    {

        duration = 2f;
        Slider_GameObject.SetActive(true);
        RunProgress = true;
        TalkToManeqFunctionBool = true;

        UnderProgressText.text = "Talking to maneq";


    }

    public void ResetProgressBarVoid()
    {

        RunProgress = false; // can't run progress
        pasttime = 0f; // time past reset
        slider.value = 0f; // empty slider
        DidOnce = false; // do it again

        // reset functions

        TalkToManeqFunctionBool = false;
        


        // reset functions




    }




}
