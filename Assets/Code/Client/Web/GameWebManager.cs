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

        public new static readonly GameWebManager Instance = new();
    }
}