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
    public class TweenAlpha : UIWindowAnimation
    {
        private void Start()
        {
            canvasGroup.DOFade(targetAlpha, duration).OnComplete(() =>
            {
                OnAnimationComplete?.Invoke();
            });
        }
        
        public CanvasGroup canvasGroup;
        public float duration = 1.0f;
        public float targetAlpha;

        protected override event Action OnAnimationComplete;
    }
}