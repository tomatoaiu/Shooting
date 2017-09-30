using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public string sceneName;
	public Image image { get { return GetComponent<Image>(); } }
	public Color setColor;
	private Color originColor;

	public enum Imagetype{
		Start,
		Continue,
		Config,
		Quit
	}
	public Imagetype imageType;

	void Start(){
		originColor = image.color;
	}

	// click event
	public void OnPointerClick (PointerEventData eventData){
		
		switch (imageType) {

		case Imagetype.Start:
			SceneManager.LoadScene (sceneName);
			break;

		case Imagetype.Continue:
			break;

		case Imagetype.Config:
			break;

		case Imagetype.Quit:
			break;
		}

	}
		
	public void OnPointerEnter(PointerEventData eventData){
		image.color = Color.red;
	}

	public void OnPointerExit(PointerEventData eventData){
		image.color = originColor;
	}
}
