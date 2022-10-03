
/********************************************************************
created:    2022-10-03
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using DG.Tweening;
using Unicorn.UI;
using UnityEngine;

namespace Scripts
{
    public class TweenAnchorPos : UIWindowAnimation
    {
        private void Start()
        {
            rectTransform.DOAnchorPos(targetPosition, duration).SetEase(ease).OnComplete(() =>
            {
                // Console.WriteLine(rectTransform.anchoredPosition); // anchoredPosition跟Debug模式下看到的是一样的
                // Console.WriteLine("animation done");
                OnAnimationComplete?.Invoke();
            });
        }
        
        public RectTransform rectTransform;
        public float duration = 1.0f;
        
        public Vector2 targetPosition;
        public Ease ease = Ease.InOutFlash;
        
        protected override event Action OnAnimationComplete;
    }
}