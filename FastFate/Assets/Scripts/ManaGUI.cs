using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaGUI : MonoBehaviour
{
	Mana mana;

	float baseWidth = 1600f;
	float baseHeight = 900f;

	public GUIStyle nameLabelStyle;

	void Awake()
	{
		mana = GameObject.FindObjectOfType(typeof(Mana)) as Mana;
	}

	void OnGUI()
	{
		// 해상도 대응.
		GUI.matrix = Matrix4x4.TRS(
			Vector3.zero,
			Quaternion.identity,
			new Vector3(Screen.width / baseWidth, Screen.height / baseHeight, 1f));

		GUI.Label(
			new Rect(1400f, 775f, 128f, 48f),
			new GUIContent(mana.manahave.ToString("0")+"/10"),
			nameLabelStyle);
		GUI.Label(
			new Rect(1240f, 780f, 128f, 48f),
			new GUIContent(mana.moneyhave.ToString("0")),
			nameLabelStyle);
	}
}
