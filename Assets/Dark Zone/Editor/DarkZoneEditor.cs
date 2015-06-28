using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DarkZone))]
[CanEditMultipleObjects]
public class DarkZoneEditor : Editor {
	SerializedProperty transitionDurationProp;
	SerializedProperty darkRadiusProp;

	public void OnEnable () {
		// Setup the SerializedProperties
		transitionDurationProp = serializedObject.FindProperty("transitionDuration");
		darkRadiusProp = serializedObject.FindProperty("darkRadius");
	}

	public override void OnInspectorGUI() {
		// Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
		serializedObject.Update();

		// Show the custom GUI controls

		DarkZone myDarkZone = (DarkZone)target;

		myDarkZone.transitionType = (DarkZone.Types)EditorGUILayout.EnumPopup("Transition Type", myDarkZone.transitionType);

		if (myDarkZone.transitionType == DarkZone.Types.DarkenOverDuration) {
			EditorGUILayout.Slider(transitionDurationProp, 0.0f, 10.0f, new GUIContent ("Transition Duration"));
		} else if (myDarkZone.transitionType == DarkZone.Types.DarkenWithDepth) {
			EditorGUILayout.Slider(darkRadiusProp, 0.0f, 500.0f, new GUIContent ("Dark Radius"));
		}

		// Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
		serializedObject.ApplyModifiedProperties ();
	}
}
