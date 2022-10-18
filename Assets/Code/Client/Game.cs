/********************************************************************
created:    2022-08-12
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/
#pragma warning disable 0436
using UnityEngine;

namespace Client
{
    public class Game
    {
        public void Update(float deltaTime)
        {
            var time = Time.time;
            if (time >= _nextLogicUpdateTime)
            {
                var deltaLogicTime = time - _lastLogicUpdateTime;
                _lastLogicUpdateTime = _nextLogicUpdateTime;
                _nextLogicUpdateTime = time + 0.1f;
                _LogicUpdate(deltaLogicTime);
            }
            
            _Update(deltaTime);
        }

        private void _LogicUpdate(float deltaTime)
        {
        
        }

        private void _Update(float deltaTime)
        {

        }
        
        private float _lastLogicUpdateTime;
        private float _nextLogicUpdateTime;
    }
}