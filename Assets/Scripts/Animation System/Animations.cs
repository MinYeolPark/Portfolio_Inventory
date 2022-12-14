using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{    
    [SerializeField] private AnimationsUI animationsUIPrefab;
    private AnimationsUI _animationsUI;
    private AnimationsUI animationsUI
    {
        get
        {
            if (!_animationsUI)
            {
                if (animationsUIPrefab == null)
                    animationsUIPrefab = Resources.Load<AnimationsUI>("Prefabs/Animations UI");
                _animationsUI = Instantiate(animationsUIPrefab, UIManager.instance.canvas.transform);
            }
            return _animationsUI;
        }
    }
    private PlayerEquipmentController player;
    public void init(PlayerEquipmentController player)
    {
        this.player = player;
        openUI();
    }
    public void openUI()
    {
        animationsUI.gameObject.SetActive(!animationsUI.gameObject.activeSelf);
        animationsUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 250);
        animationsUI.init(this);
    }

    public Animator getAnimator()
    {
        return player.GetComponent<Animator>();
    }
}
