﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonArrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

	public bool clicked = false;
	UIControl UC; GameObject hint;
	bool inside = false; float time = 0;

	void Start() {
		UC = GameObject.Find("Interface").transform.Find("UI").GetComponent<UIControl>();
		hint = transform.parent.Find("Hint").gameObject;
	}

	public void OnPointerEnter(PointerEventData d) {
		var c = GetComponent<Image>().color; c.a = 1; GetComponent<Image>().color = c;
		inside = true; time = 0;
	}
	public void OnPointerExit(PointerEventData d) {
		var c = GetComponent<Image>().color; c.a = 0.75F; GetComponent<Image>().color = c;
		inside = false; UC.HintOff();
	}
	public void OnPointerDown(PointerEventData d) {
		var c = GetComponent<Image>().color; c.a = 0.75F; GetComponent<Image>().color = c;
		inside = false; UC.HintOff();
		clicked = true;
	}

	void Update() {
		if (inside) {
			time += Time.deltaTime;
			if (time >= 0.8F && !hint.gameObject.activeSelf) UC.HintOn(2);
		}
	}
}