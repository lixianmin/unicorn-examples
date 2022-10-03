
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
            rectTransform.DOAnchorPos(endPosition, duration).SetEase(easeType).OnComplete(() =>
            {
                // Console.WriteLine("animation done");
                OnAnimationComplete?.Invoke();
            });
        }
        
        public RectTransform rectTransform;
        public float duration = 1.0f;
        public Vector2 endPosition;
        public Ease easeType = Ease.InOutFlash;
        
        protected override event Action OnAnimationComplete;
    }
}