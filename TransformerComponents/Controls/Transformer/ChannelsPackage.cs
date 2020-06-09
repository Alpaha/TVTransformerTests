using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [ControlDefinition("div", ContainingClass = "channels-package")]
    public class ChannelsPackage<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("transformer-name")]
        public Text<_> Name { get; set; }

        [FindByClass("transformer-panel__info-channels")]
        public Text<_> ChannelsCount { get; set; }

        [FindByClass("transformer-panel__info-price")]
        public Text<_> Price { get; set; }

        [FindByClass("btn btn--outline-pink")]
        public Button<_> AddButton { get; set; }

        [FindByClass("transformer-panel__context-menu")]
        public Button<_> ContextMenuButton { get; set; }

        public ChannelsGrid<_> Channels { get; set; }

    }
}
