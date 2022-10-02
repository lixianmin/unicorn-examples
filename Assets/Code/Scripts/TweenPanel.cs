/********************************************************************
created:    2022-10-02
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/

using System;
using DG.Tweening;
using Unicorn.UI;
using UnityEngine;

namespace Scripts
{
    public class TweenPanel : UIWindowAnimation
    {
        public enum OpenClose
        {
            Open,
            Close,
        }

        public OpenClose openClose = OpenClose.Open;
        public RectTransform rectTransform;
        public float fadeTime = 1.0f;
        public Ease easeType = Ease.Flash;
    
        private void Start()
        {
            if (openClose == OpenClose.Open)
            {
                _FadeIn();
            }
            else
            {
                _FadeOut();
            }
        }

        private void _FadeIn()
        {
            rectTransform.DOAnchorPos(new Vector2(100, 100), fadeTime, false)
                .SetEase(easeType)
                .OnComplete(() =>
                {
                    Console.WriteLine("open window animation done");
                    OnAnimationComplete?.Invoke();
                });
        }

        private void _FadeOut()
        {
            rectTransform.DOAnchorPos(new Vector2(0, -1000f), fadeTime, false)
                .SetEase(easeType)
                .OnComplete(()=>OnAnimationComplete?.Invoke());
        }

        protected override event Action OnAnimationComplete;
    }
}
