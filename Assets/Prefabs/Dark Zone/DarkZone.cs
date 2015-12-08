using UnityEngine;
using System.Collections;

public class DarkZone : MonoBehaviour {

	// General Variables

	public enum Types {DarkenOverDuration, DarkenWithDepth};
	public Types transitionType;

	private Color daylight;
	private Color darkness = Color.black;
	private Color fogColor;
	private float defaultFogEnd;
	private float darknessFogEnd = 50;
	private float transitionPercent = 0.0f;

	// Variables for DarkenOverDuration

	public float transitionDuration;

	private float transitionTimer;
	private enum Transition {off, enter, exit};
	private Transition transitionState = Transition.off;

	// Variables for DarkenWithDepth

	public float darkRadius; // Radius of the region that is always the darkest

	private float zoneRadius; // Radius of the entire DarkZone
	private float darkeningDistance; // Distance you must travel into zone before reaching max darkness


	// Use this for initialization
	void Start () {
		daylight = RenderSettings.ambientLight;
		fogColor = RenderSettings.fogColor;
		defaultFogEnd = RenderSettings.fogEndDistance;

		transitionTimer = 0;

		zoneRadius = transform.localScale.x / 2;
		darkeningDistance = zoneRadius - darkRadius;
	}
	
	// Update is called once per frame
	void Update () {
		if (transitionState != Transition.off) {
			if (transitionState == Transition.enter) {
				transitionTimer += Time.deltaTime;
				if (transitionTimer >= transitionDuration) {
					transitionTimer = transitionDuration;
					transitionState = Transition.off;
				}
			} else if (transitionState == Transition.exit) {
				transitionTimer -= Time.deltaTime;
				if (transitionTimer <= 0) {
					transitionTimer = 0;
					transitionState = Transition.off;
				}
			}
			transitionPercent = transitionTimer / transitionDuration;
			LerpRenderSettings(transitionPercent);
		}
	}

	void OnTriggerStay (Collider col) {
		if (transitionType != Types.DarkenOverDuration) {
			if (col.tag == "Player") {
				float distanceFromCenter = Vector3.Distance(transform.position, col.transform.position);
				if (distanceFromCenter > darkRadius) {
					transitionPercent = Mathf.Clamp((darkeningDistance - distanceFromCenter + darkRadius) / darkeningDistance, 0, 1);
					LerpRenderSettings(transitionPercent);
				}
				else {
					if (transitionPercent != 1)
						transitionPercent = 1;
					MaxDarkness();
				}
			}
		}
	}

	void OnTriggerEnter (Collider col) {
		if (transitionType == Types.DarkenOverDuration) {
			transitionState = Transition.enter;
		}
	}

	void OnTriggerExit (Collider col) {
		if (transitionType == Types.DarkenOverDuration) {
			transitionState = Transition.exit;
		}
	}

	void LerpRenderSettings(float transitionPercent) {
		RenderSettings.ambientLight = Color.Lerp(daylight, darkness, transitionPercent);
		RenderSettings.fogColor = Color.Lerp(fogColor, darkness, transitionPercent);
		RenderSettings.fogEndDistance = Mathf.Lerp(defaultFogEnd, darknessFogEnd, transitionPercent);
	}

	void MaxDarkness () {
		RenderSettings.ambientLight = darkness;
		RenderSettings.fogColor = darkness;
		RenderSettings.fogEndDistance = darknessFogEnd;
	}
}
