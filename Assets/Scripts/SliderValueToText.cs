using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour {

    public Slider sliderUI;
    private Text textSliderValue;

	// Use this for initialization
	void Start () {
        textSliderValue = GetComponent<Text>();
        ShowSliderValue();
	}
	
	// Update is called once per frame
	public void ShowSliderValue () {
        string sliderMessage = "Slider value =" + sliderUI.value;
        textSliderValue.text = sliderMessage;
	}
}
