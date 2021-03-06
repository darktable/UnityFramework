﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UGUITool
{
    static PointerEventData eventDatas = new PointerEventData(EventSystem.current);
    static List<RaycastResult> hit = new List<RaycastResult>();

    static public bool IsHitUI()
    {
        eventDatas.position = Input.mousePosition;
        eventDatas.pressPosition = Input.mousePosition;
        EventSystem.current.RaycastAll(eventDatas, hit);

        if (hit.Count > 0)
            return true;

        if (EventSystem.current.IsPointerOverGameObject())  //鼠标点在UI上
            return true;
        return false;
    }
    
    static public void set_icon(Image img,string name,bool is_nativesize = true)
    {
        if(name == null)
        {
            Debug.LogError("set_icon Image name 不能为 null !" );
            return;
        }

        if (img == null)
        {
            Debug.LogError("set_icon Image 不能为 null !");
            return;
        }

        try
        {
            Debug.LogError("xxx");
            Sprite sp = null;//ResourceManager.Load<Sprite>(name);
            img.overrideSprite = sp;// Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector3.zero);
            img.sprite = img.overrideSprite;

            if (is_nativesize)
                img.SetNativeSize();
        }
        catch (System.Exception e)
        {
            Debug.LogError("set_icon Exception:" + e.ToString());           
        }
    }

    static public void set_SpriteRender(GameObject go , string name)
    {
        try
        {
            Debug.LogError("xxx");
            Texture2D tex = null;//ResourceManager.Load<Texture2D>(name);
            SpriteRenderer sprite = go.GetComponent<SpriteRenderer>();
            sprite.sprite = CreateSprite(tex);
        }
        catch
        {

        }
    }

    static public Sprite CreateSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector3.one * 0.5f);
    }
}
