using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using System.Net;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Android;

//using UnityEngine.InputSystem;
//using UnityEngine.Android;

public class UICode : MonoBehaviour
{

    //UI Document Object.
    public UIDocument doc;
    //The very first visual element object, also known as the 'root'.
    private VisualElement root;
    //The blue UI button.
    private Button UIPlay;
    private Label UILabel;
    public static int currentSteps = 0;

    public static StepCounter current
    {
        get;
    }

    public IntegerControl stepCounter
    {
        get;
    }


    // Start is called before the first frame update
    void Start()
    {

        if (!Permission.HasUserAuthorizedPermission("android.permission.ACTIVITY_RECOGNITION"))
        {
            Permission.RequestUserPermission("android.permission.ACTIVITY_RECOGNITION");
        }

        root = doc.rootVisualElement;
        //Initialize the button object by connecting it to the button in the layout.
        //The Q function with whatever type of element it is in the <> braces allows you to find and connect
        //objects from the layout to code.
        UIPlay = root.Q<Button>("Play");
        UILabel = root.Q<Label>("Label");
        //if (StepCounter.current == null)
        //{
        //    UILabel.text = string.Empty;
        //}
        //else
        //{
         //   UILabel.text = StepCounter.current.stepCounter.ReadValue().ToString();
        //}

        //Tie the ClickTheButton() function to execute when the button is clicked.
        UIPlay.clicked += ClickTheButton;

    }

    void Update()

    {
        if (StepCounter.current != null)
        {

            InputSystem.EnableDevice(StepCounter.current);


            if (StepCounter.current.enabled)

            {

                Debug.Log("StepCounter is enabled");

                currentSteps = StepCounter.current.stepCounter.ReadValue();

            }

            UILabel.text = "Steps: " + currentSteps;

        }

    }


    void ClickTheButton()
    {

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/fitness/v1/users/me/dataSources");
        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //StreamReader reader = new StreamReader(response.GetResponseStream());

        Debug.Log("test");
    }
}

    //HttpWebRequest request = (HttpWebRequest)UnityWebRequest.Post("https://www.googleapis.com/fitness/v1/users/me/dataSources");
    //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //StreamReader reader = new StreamReader(response.GetResponseStream());
