/*
Copyright ?017. The University of Texas at Dallas. All Rights Reserved. 

Permission to use, copy, modify, and distribute this software and its documentation for 
educational, research, and not-for-profit purposes, without fee and without a signed 
licensing agreement, is hereby granted, provided that the above copyright notice, this 
paragraph and the following two paragraphs appear in all copies, modifications, and 
distributions. 

Contact The Office of Technology Commercialization, The University of Texas at Dallas, 
800 W. Campbell Road (AD15), Richardson, Texas 75080-3021, (972) 883-4558, 
otc@utdallas.edu, https://research.utdallas.edu/otc for commercial licensing opportunities.

IN NO EVENT SHALL THE UNIVERSITY OF TEXAS AT DALLAS BE LIABLE TO ANY PARTY FOR DIRECT, 
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, ARISING 
OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF THE UNIVERSITY OF TEXAS AT 
DALLAS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

THE UNIVERSITY OF TEXAS AT DALLAS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT 
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF ANY, PROVIDED HEREUNDER IS 
PROVIDED "AS IS". THE UNIVERSITY OF TEXAS AT DALLAS HAS NO OBLIGATION TO PROVIDE 
MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualHand : MonoBehaviour
{

    // Enumerate states of virtual hand interactions
    public enum VirtualHandState
    {
        Open,
        Touching,
        Holding,
        Closed,
        Apply,
        Select
    };

    // Inspector parameters
    [Tooltip("The tracking device used for tracking the real hand.")]
    public CommonTracker tracker;

    [Tooltip("The controller joystick used to determine relative direction (forward/backward) and speed.")]
    public CommonAxis joystick;

    [Tooltip("The interactive used to represent the virtual hand.")]
    public Affect hand;

    [Tooltip("The button required to be pressed to grab objects.")]
    public CommonButton button;

    [Tooltip("The button required to be pressed to select from menu.")]
    public CommonButton menu;

    [Tooltip("The speed amplifier for thrown objects. One unit is physically realistic.")]
    public float speed = 1.0f;

    // Private interaction variables
    VirtualHandState state;
    FixedJoint grasp;
    bool status;

    bool menustatus;
    bool menuBeamStatus;

    // Called at the end of the program initialization
    void Start()
    {

        // Set initial state to open
        state = VirtualHandState.Open;

        // Ensure hand interactive is properly configured
        hand.type = AffectType.Virtual;

        hand.gameObject.tag = "hands";
    }

    // FixedUpdate is not called every graphical frame but rather every physics frame
    void FixedUpdate()
    {

        // If state is open
        if (state == VirtualHandState.Open)
        {

            // If the hand is touching something
            if (hand.triggerOngoing)
            {
                // Change state to touching
                Debug.Log("Touching");
                state = VirtualHandState.Touching;
            }

            // If the hand is closed
            else if (button.GetPress() && !menu.GetPressDown())
            {
                // Change state to closed
                state = VirtualHandState.Closed;
                hand.type = AffectType.Physical;
            }

            else if (menu.GetPressDown())
            {

                if (button.GetPressDown())
                {
                    Debug.Log("HandleTriggerClicked");
                    if (EventSystem.current.currentSelectedGameObject != null)
                    {
                        ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
                        return;
                    }
                }

                GameObject menuUIObj;
                GameObject menuBeamObj;
                menuUIObj = GameObject.Find("MainMenuObjectHelper");

                menustatus = menuUIObj.GetComponent<MenuUI>().isOn;
                //menustatus = menuUIObj.activeInHierarchy;

                menuBeamObj = GameObject.Find("MenuBeamHelper");
                menuBeamStatus = menuBeamObj.GetComponent<MenuBeam>().isOn;

                if (menustatus == true)
                {
                    Debug.Log("TurnOff");
                    menustatus = false;
                    menuUIObj.GetComponent<MenuUI>().isOn = menustatus;
                    menuBeamObj.GetComponent<MenuBeam>().isOn = menustatus;

                }
                else if (menustatus == false)
                {
                    Debug.Log("TurnOn");
                    menustatus = true;
                    menuUIObj.GetComponent<MenuUI>().isOn = menustatus;
                    menuBeamObj.GetComponent<MenuBeam>().isOn = menustatus;
                }

                // Change state to Select
                state = VirtualHandState.Select;
            }

            else
            {
                // do nothing
            }
        }

        //If state is closed
        if (state == VirtualHandState.Closed)
        {
            if (!button.GetPress())
            {
                //change state to open
                state = VirtualHandState.Open;
                hand.type = AffectType.Virtual;
            }

            else
            {
                //do nothing
            }

        }

        // If state is touching
        else if (state == VirtualHandState.Touching)
        {

            // If the hand is not touching something
            if (!hand.triggerOngoing)
            {

                // Change state to open
                state = VirtualHandState.Open;
            }

            // If the hand is touching something and the button is pressed
            else if (hand.triggerOngoing && button.GetPress())
            {

                // Fetch touched target
                Collider target = hand.ongoingTriggers[0];

                if (target.GetComponent<Status>())
                {
                    status = target.GetComponent<Status>().isOn;
                    if (status == true)
                    {
                        Debug.Log("TurnOff");
                        status = false;
                        target.GetComponent<Status>().isOn = status;

                    }
                    else
                    {
                        Debug.Log("TurnOn");
                        status = true;
                        target.GetComponent<Status>().isOn = status;
                    }
                }

                if (target.GetComponent<Vision>())
                {
                    status = target.GetComponent<Vision>().isOn;
                    if (status == true)
                    {
                        status = false;
                        target.GetComponent<Vision>().isOn = status;
                        //grasp = target.GetComponent<Vision>().goggle.gameObject.AddComponent<FixedJoint>();
                        //grasp.connectedBody = hand.gameObject.GetComponent<Rigidbody>();

                    }
                }


                // Create a fixed joint between the hand and the target
                grasp = target.gameObject.AddComponent<FixedJoint>();
                // Set the connection
                grasp.connectedBody = hand.gameObject.GetComponent<Rigidbody>();

                if (target.gameObject.tag == "goggle")
                {
                    hand.gameObject.tag = "goggle";
                }


                // Change state to holding
                state = VirtualHandState.Holding;
            }

            //else if (hand.triggerOngoing && grip.GetPressDown())
            //{
            //    Debug.Log("Apply");
            //    Collider target = hand.ongoingTriggers[0];

            //    if (target.GetComponent<Status>())
            //    {
            //        status = target.GetComponent<Status>().isOn;
            //        if (status == true)
            //        {
            //            Debug.Log("TurnOff");
            //            status = false;
            //            target.GetComponent<Status>().isOn = status;            

            //        }
            //        else if (status == false)
            //        {
            //            Debug.Log("TurnOn");
            //            status = true;
            //            target.GetComponent<Status>().isOn = status;
            //        }
            //    }

            //    if (target.GetComponent<Goggles>())
            //    {
            //        status = target.GetComponent<Goggles>().isOn;
            //        if (status == true)
            //        {
            //            Debug.Log("TurnOff");
            //            status = false;
            //            target.GetComponent<Goggles>().isOn = status;

            //        }
            //        else if (status == false)
            //        {
            //            Debug.Log("TurnOn");
            //            status = true;
            //            target.GetComponent<Goggles>().isOn = status;
            //        }
            //    }

            //    if (target.GetComponent<Vision>())
            //    {
            //        status = target.GetComponent<Vision>().isOn;
            //        if (status == true)
            //        {
            //            Debug.Log("TurnOff");
            //            status = false;
            //            target.GetComponent<Vision>().isOn = status;

            //        }
            //        else if (status == false)
            //        {
            //            Debug.Log("TurnOn");
            //            status = true;
            //            target.GetComponent<Vision>().isOn = status;
            //        }
            //    }

            //    state = VirtualHandState.Apply;

            //}

            // Process current touching state
            else
            {

                // Nothing to do for touching
            }
        }

        // If state is holding
        else if (state == VirtualHandState.Holding)
        {

            // If grasp has been broken
            if (grasp == null)
            {

                // Update state to open
                state = VirtualHandState.Open;
            }

            // If button has been released and grasp still exists
            else if (!button.GetPress() && grasp != null)
            {

                // Get rigidbody of grasped target
                Rigidbody target = grasp.GetComponent<Rigidbody>();
                // Break grasp
                DestroyImmediate(grasp);

                // Apply physics to target in the event of attempting to throw it
                target.velocity = hand.velocity * speed;
                target.angularVelocity = hand.angularVelocity * speed;

                hand.gameObject.tag = "hands";

                // Update state to open
                state = VirtualHandState.Open;
            }


            // Process current holding state
            else
            {

                // Nothing to do for holding
            }
        }

        // if state is displacing
        //else if (state == VirtualHandState.Apply)
        //{

        //    if (grasp == null && !grip.GetPressDown() && !hand.triggerOngoing)
        //    {
        //        // Update state to open
        //        state = VirtualHandState.Open;
        //    }
        //    else if (grasp == null && !grip.GetPressDown() && hand.triggerOngoing)
        //    {
        //        state = VirtualHandState.Touching;
        //    }

        //    else
        //    {

        //    }

        //}

        else if (state == VirtualHandState.Select)
        {
            if (!menu.GetPressDown())
                state = VirtualHandState.Open;
        }
    }
}