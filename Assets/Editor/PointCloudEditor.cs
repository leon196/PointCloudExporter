using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEditor;
using PointCloudExporter;

[CustomEditor(typeof(PointCloudGenerator))]
public class PointCloudEditor : Editor {
	public override void OnInspectorGUI () {
		serializedObject.Update();
		DrawDefaultInspector();
		PointCloudGenerator script = (PointCloudGenerator)target;
		
		if(GUILayout.Button("Generate")) {
			script.Generate();
		}
		if(GUILayout.Button("Reset")) {
			script.Reset();
		}
		if(GUILayout.Button("Displace")) {
			script.Displace();
		}
		if(GUILayout.Button("Export")) {
			script.Export();
		}
		if(GUILayout.Button("Save Baked Colors")) {
			string fileName = EditorUtility.SaveFilePanel("Export .png file", "", "", "png");
			File.WriteAllBytes(fileName, script.GetBakedMap().EncodeToPNG());
		}
	}
}