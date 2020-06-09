using System;
using System.Linq;
using Atata;

namespace TransformerComponents.Controls.Transformer
{
    [FindByClass("all-channels", Visibility = Visibility.Any)]
    public class AllChannelsTab<_> : BaseTab<_>
        where _ : PageObject<_>
    {
        public ControlList<ChannelsPackage<_>, _> ChannelsPackageList { get; set; }

        public _ ClickOnPackageByName(string name)
        {
            var channelsPackage = ChannelsPackageList.FirstOrDefault(ch => ch.Name.Content == $"{name}");
            if(channelsPackage == null)
                throw new Exception($"Не найден пакет по названию: \"{name}\"");

            return channelsPackage.Click();
        }

        public _ AddPackageByName(string name)
        {
            var channelsPackage = ChannelsPackageList.FirstOrDefault(ch => ch.Name.Value == $"{name}");
            if(channelsPackage == null)
                throw new Exception($"Не найден пакет по названиею: \"{name}\"");

            if(!channelsPackage.AddButton.IsPresent.Value)
                throw new Exception($"Не удалось найти кнопку \"Добавить\" для пакета: \"{name}\"");

            return channelsPackage.AddButton.Click();
        }
    }
}
