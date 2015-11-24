
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


namespace kerbalPlugin
{
	public class MyClass
	{
		public class HelloKerbinMod : PartModule
		{

			private int up = 0;
			private int down = 0;
			private int rollRight = 0;
			private int rollLeft = 0;
			private int count = 0;

			private bool logging = false;

			private float timeLimit = 0.15f;
			private float currentTime = 0.0f;

			public override void OnStart(StartState state)
			{
				// Add stuff to the log
				print("Hello, Kerbin from my logger mod!");
			}

			public void Update(){

				//increment time keeper
				currentTime += Time.deltaTime;

				//check for toggle
				if (Input.GetKeyDown(KeyCode.R))
					logging = !logging;

				//if toggle is true and time duration is triggered
				if(logging &&(currentTime > timeLimit)){

					currentTime = 0.0f;
					count ++;

					//get WSAD input as bool 1:0
					up = Input.GetKey(KeyCode.S)? 1 : 0;
					down = Input.GetKey(KeyCode.W)? 1 : 0;
					rollRight = Input.GetKey(KeyCode.E)? 1 : 0;
					rollLeft = Input.GetKey(KeyCode.Q)? 1 : 0;

					//write to file in CSV format
					System.IO.File.AppendAllText("blackbox.csv", "\n" +
					                             count + "," +
					                             up + "," +
					                             down + "," + 
					                             rollRight + "," + 
					                             rollLeft + "," + 
												 FlightGlobals.ActiveVessel.srfRelRotation.Pitch() + "," + 
					                             FlightGlobals.ActiveVessel.srfRelRotation.Roll() + "," +

					                             FlightGlobals.ship_rotation.Pitch() + "," +
					                             FlightGlobals.ship_rotation.Roll() + "," +
					                            
					                             FlightGlobals.ship_heading);

				}

			}

		}
	}
}

