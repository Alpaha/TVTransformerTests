using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindById("my-transformer")]
    public class MyTransformerTab<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("my-transformer__title")]
        public Text<_> Title { get; set; }

        [FindByClass("my-transformer__hint")]
        public Control<_> EmptyTransformerHint { get; set; }
        
        public MyTransformerChannels<_> ChannelsGrid { get; set; }

        public ControlList<ChannelsPackage<_>, _> Packages { get; set; }
    }

    [FindByClass("channels-package my-transformer__package")]
    public class MyTransformerPackage<_> : Control<_>
        where _ : PageObject<_>
    {
        public PackagePanel<_> PackagePanel { get; set; }

        [FindByClass("channels-grid")]
        public ControlList<Channel<_>, _> Channels { get; set; }
    }

    [FindByClass("transformer-panel")]
    public class PackagePanel<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("transformer-name")]
        public Text<_> Name { get; set; }

        [FindByClass("transformer-panel__info-channels")]
        public Text<_> ChannelCount { get; set; }

        [FindByClass("transformer-panel__info-price")]
        public Text<_> Price { get; set; }
    }
}
