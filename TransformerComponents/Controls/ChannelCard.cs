using Atata;

namespace TransformerComponents.Controls
{
    [ControlDefinition("div", ContainingClass = "channel-card")]
    public class ChannelCard<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("channel-card__header-logo")]
        public Image<_> Image { get; set; }

        [FindByClass("btn-close")]
        public Control<_> Close { get; set; }

        [FindByClass("channel-card__content-name")]
        public H4<_> Name { get; set; }

        [FindByClass("channel-card__content-description")]
        public Text<_> Description { get; set; }

        public ChannelCardFooter<_> Footer { get; set; }
    }

    [FindByClass("channel-card__footer")]
    public class ChannelCardFooter<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByContent("Канал уже в Трансформере.")]
        public Text<_> AlreadyInTransformer { get; set; }

        [FindByClass("btn btn--default btn--card")]
        public Button<_> AddButton { get; set; }
        
        [FindByXPath("//*[@id='transformer']/div[2]/div[6]/div[3]/span")]
        public Text<_> Price { get; set; }

        [FindByClass("menu-btn__name")]
        public Text<_> RemoveChannel { get; set; }
    }
}
