
/********************************************************************
created:    2022-08-12
author:     lixianmin

Copyright (C) - All Rights Reserved
*********************************************************************/
using System;
using Unicorn.Web;

namespace Client.Web
{
    public class GameWebManager : WebManager
    {
        static GameWebManager()
        {
        }

        private GameWebManager()
        {
        }

        public override IWebNode LoadAsset(WebArgument argument, Action<IWebNode> handler)
        {
            var webItem = new WebItem(argument, handler);
            return webItem;
        }
        
        public IWebNode LoadAsset(string key, Action<IWebNode> handler)
        {
            return LoadAsset(new WebArgument { key = key }, handler);
        }
        
        public WebPrefab LoadPrefab(string key, Action<WebPrefab> handler)
        {
            return LoadPrefab(new WebArgument { key = key }, handler);
        }

        public new static readonly GameWebManager It = new();
    }
}