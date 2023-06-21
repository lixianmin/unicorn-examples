
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
        private void OnEnable()
        {
            rectTransform.DOAnchorPos(targetPosition, duration).SetEase(ease).OnComplete(() =>
            {
                // Logo.Info(rectTransform.anchoredPosition); // anchoredPosition跟Debug模式下看到的是一样的
                // Logo.Info("animation done");
                OnAnimationComplete?.Invoke();
            });
        }
        
        // 为什么不使用public变量? 使用private是为最小化访问权限, 而为了支持序列化就需要补一个SerializeField属性
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private float duration = 1.0f;
        
        [SerializeField] private Vector2 targetPosition;
        [SerializeField] private Ease ease = Ease.InOutFlash;
        
        public override event Action OnAnimationComplete;
    }
}