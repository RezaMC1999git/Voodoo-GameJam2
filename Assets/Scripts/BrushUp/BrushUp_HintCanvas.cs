using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushUp_HintCanvas : MonoBehaviour
{
    public Sprite redCircle;
    public Sprite greenCircle;
    public Sprite blueCircle;
    public Sprite yellowCircle;

    public Image currentColor;
    public Image nextColor;
    public Image sliderColor;
    public Image circleImage;
    public Slider slider;
    public float sliderSpeed = 2f; 

    private void Update()
    {
        slider.value += 1f * sliderSpeed * Time.deltaTime;
        circleImage.fillAmount += 1f * sliderSpeed * Time.deltaTime;
        if (slider.value >= slider.maxValue)
            slider.value = 0;
        if (circleImage.fillAmount == 1)
            circleImage.fillAmount = 0;
    }

    public void RedBall(int nextColor)
    {
        currentColor.sprite = redCircle;
        sliderColor.color = Color.red;
        ColorizeNextImage(nextColor);
    }

    public void GreenBall(int nextColor)
    {
        currentColor.sprite = greenCircle;
        sliderColor.color = Color.green;
        ColorizeNextImage(nextColor);
    }

    public void BlueBall(int nextColor)
    {
        currentColor.sprite = blueCircle;
        sliderColor.color = Color.blue;
        ColorizeNextImage(nextColor);
    }

    public void YellowBall(int nextColor)
    {
        currentColor.sprite = yellowCircle;
        sliderColor.color = Color.yellow;
        ColorizeNextImage(nextColor);
    }

    void ColorizeNextImage(int nextIndex)
    {
        switch (nextIndex)
        {
            case 0:
                nextColor.sprite = redCircle;
                circleImage.sprite = redCircle;
                break;
            case 1:
                nextColor.sprite = greenCircle;
                circleImage.sprite = greenCircle;
                break;
            case 2:
                nextColor.sprite = blueCircle;
                circleImage.sprite = blueCircle;
                break;
            case 3:
                nextColor.sprite = yellowCircle;
                circleImage.sprite = yellowCircle;
                break;
        }
    }

}
