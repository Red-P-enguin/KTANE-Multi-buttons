using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KModkit;
using Newtonsoft.Json;
using System.Linq;
using System.Text.RegularExpressions;

public class SimpleModuleScript : MonoBehaviour {

	public KMAudio audio;
	public KMBombInfo info;
	public KMBombModule module;
	public KMSelectable cylinder1;
	public KMSelectable cylinder2;
	public KMSelectable cylinder3;
	public KMSelectable cylinderSubmit;
	public AudioSource playSound;

	public int ans = 0;
	public int InputAns = 0;
	public int StageCur;
	public int StageLim;

	bool _isSolved = false;

	void Start ()
	{
		module.HandlePass ();
		print ("Why");
		if (info.GetSerialNumberLetters ().Any ("BROKE".Contains))
		{
			ans++;
			print ("ans is added 1");
		}  
		else
		{
			print ("ans is unchanged");
		}
		if (info.GetSerialNumberLetters ().Any ("HELLO".Contains)) 
		{
			ans++;
			print ("ans is added 1");
		}
		else
		{
			print ("ans is unchanged");
		}
		if (info.GetPortCount () > 0) 
		{
			ans++;
			print ("ans is added 1");
		}
		else
		{
			print ("ans is unchanged");
		}
		if (info.GetBatteryCount() > 2) 
		{
			ans++;
			print ("ans is added 1");
		}
		else
		{
			print ("ans is unchanged");
		}

		if (StageCur > StageLim) 
		{
			module.HandlePass ();
			print ("Did it!");
		}
	}

	public void Button1()
	{
		playSound.Play ();
		if (info.GetBatteryCount () < 2) 
		{
			module.HandleStrike ();
			print ("WRONG!");
		}
		else 
		{
			InputAns++;
			print ("would like an answer");
		}
	}
	public void Button2()
	{
		playSound.Play ();
		if (info.GetBatteryCount () < 1) {
			module.HandleStrike ();
			print ("WRONG!");
		}
		else 
		{
			InputAns++;
			print ("would like an answer");
		}
	}
	public void Button3()
	{
		playSound.Play ();
		if (info.GetBatteryCount () < 1) {
			InputAns++;
			print ("would like an answer");
		} 
		else 
		{
			module.HandleStrike ();
			print ("WRONG!");
		}
	}
	public void Submit()
	{
		if (InputAns == ans) {
			module.HandlePass ();
			print ("Great!");
		}
		else 
		{
			module.HandleStrike ();
			print ("DIE");
		}
	}
}
