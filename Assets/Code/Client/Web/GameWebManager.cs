using System;
using Unicorn.Web;

namespace Client.Web
{
    public class GameWebManager : WebManager
    {
        public GameWebManager()
        {
            Instance = this;
        }
        
        public override IWebNode LoadAsset(WebArgument argument, Action<IWebNode> handler)
        {
            var webItem = new WebItem(argument, handler);
            return webItem;
        }
    }
}