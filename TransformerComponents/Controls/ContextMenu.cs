using Atata;

namespace TransformerComponents.Controls
{
    [FindByClass("context-menu")]
    public class ContextMenu<_> : Control<_>
        where _ : PageObject<_>
    {
        [FindByClass("menu-btn__name")]
        [FindByContent("Убрать все")]
        public Text<_> RemoveAll { get; set; }

        [FindByClass("menu-btn__name")]
        [FindByContent("Убрать")]
        public Text<_> Remove { get; set; }
    }
}
