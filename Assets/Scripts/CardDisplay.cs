using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Image artworkImage;

    public Text weaponNameText;
    public Text descriptionText;

    public void DefineCard(Card card)
    {
        artworkImage.sprite = card.artwork;

        weaponNameText.text = card.weaponName;
        descriptionText.text = card.description;
    }
}
