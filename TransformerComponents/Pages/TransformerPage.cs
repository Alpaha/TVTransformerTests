using Atata;
using TransformerComponents.Controls;
using TransformerComponents.Controls.Rate;
using TransformerComponents.Controls.Transformer;

namespace TransformerComponents.Pages
{
    using _ = TransformerPage;

    [Url("ekb/articles/inet/tariff/573d572d563#572/transformer")]
    public class TransformerPage : Page<_>
    {
        public Transformer<_> Transformer { get; set; }

        public Rate<_> Rate { get; set; }

        public ChannelCard<_> ChannelCard { get; set; }

        [FindByClass("btn btn--outline-black")]
        public Button<_> ContextMenuButton { get; set; }

        public ContextMenu<_> ContextMenu { get; set; }
    }
}
