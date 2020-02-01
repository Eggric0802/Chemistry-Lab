using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class TurnBack : MonoBehaviour
{

    [Space(10)]
    [Header("Toggle for the gui on off")]
    public bool GuiOn;
    bool isAmonia = false, isLead = false, isCooper = false;


    [Space(10)]
    [Header("The text to Display on Trigger")]
    [Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the Label section to change this text")]
    public string Text = "Turn Back";
    public string Text2 = "";
    public string Text3 = "";

    [Tooltip("This is the window Box's size. It will be mid screen. Add or reduce the X and Y to move the box in Pixels. ")]
    public Rect BoxSize = new Rect(0, 0, 200, 100);


    [Space(10)]
    [Tooltip("To edit the look of the text Go to Assets > Create > GUIskin. Add the new Guiskin to the Custom Skin proptery. If you select the GUIskin in your project tab you can now adjust the font, colour, size etc of the text")]
    public GUISkin customSkin;



    // if this script is on an object with a collider display the Gui
    //void OnTriggerEnter()
    //{
    //    GuiOn = true;
    //}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "AmmeniaSoluble")
        {
            GuiOn = true;
            isAmonia = true;

        }

        if (col.gameObject.tag == "CopperSoluble")
        {
            GuiOn = true;
            isCooper = true;
        }

        if (col.gameObject.tag == "LeadInsoluble")
        {
            GuiOn = true;
            isLead = true;
        }

    }


    void OnTriggerExit()
    {
        GuiOn = false;
    }

    void OnGUI()
    {

        if (customSkin != null)
        {
            GUI.skin = customSkin;
        }

        if (GuiOn == true)
        {
            // Make a group on the center of the screen
            GUI.BeginGroup(new Rect((Screen.width - BoxSize.width) / 2, (Screen.height - BoxSize.height) / 2, BoxSize.width, BoxSize.height));
            // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

            //if (col.gameObject.tag == "AmmeniaSoluble")
            //{
            //    GUI.Label(BoxSize, Text);
            //}

            //if (col.gameObject.tag == "CopperSoluble")
            // {
            //    GUI.Label(BoxSize, Text2);
            //}

            //if (col.gameObject.tag == "LeadInsoluble")
            //{
            //    GUI.Label(BoxSize, Text3);
            //}
            if (isAmonia)
            {
                GUI.Label(BoxSize, Text);
            }
            else if (isCooper)
            {
                GUI.Label(BoxSize, Text2);
            }
            else if (isLead)
            {
                GUI.Label(BoxSize, Text3);
            }

            // End the group we started above. This is very important to remember!
            GUI.EndGroup();

        }


    }

}