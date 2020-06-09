using System.Drawing;
using System.Linq;
using Atata;
using NUnit.Framework;
using TransformerComponents.Pages;
using TVTransformerTests.Extensions;

namespace TVTransformerTests
{
    public class MyTests : UITestFixture
    {
        [Test(Description = "Обычное добавление канала и пакета")]
        public void SimpleAddChannelAndPackage()
        {
            var page = Go.To<TransformerPage>()
                .Transformer.NavigationMenu.WaitTo.BeVisible()
                .Transformer.MyTransformerTab.EmptyTransformerHint.Should.BeVisible()
                .Transformer.NavigationMenu.Tabs[tab => tab.Name.Value == Consts.Tabs.AllChannels].Click()
                .Transformer.AllChannelsTab.WaitTo.BeVisible();

            var package = page.Transformer.AllChannelsTab.ChannelsPackageList[panel => panel.Name.Value == Consts.Packages.Rain];
            package.Click();

            var channel = package.Channels.ChannelsList[ch => ch.Name == Consts.Channels.Rain];
            channel.Click();
            page.ChannelCard.Footer.AddButton.Click();

            page.Transformer.AllChannelsTab.AddPackageByName(Consts.Packages.InformativeHD);

            page.Transformer.NavigationMenu.Tabs[tab => tab.Name.Value == Consts.Tabs.MyTransformer].Click()
                .Transformer.MyTransformerTab.WaitTo.BeVisible()
                .Transformer.MyTransformerTab.ChannelsGrid.Channels.Should.HaveCount(1)
                .Transformer.MyTransformerTab.ChannelsGrid.Channels.FirstOrDefault().Click()
                .ChannelCard.Name.Should.BeEquivalent(Consts.Channels.Rain)
                .Transformer.MyTransformerTab.Packages.First().Name.Should.BeEquivalent(Consts.Packages.InformativeHD);
        }

        [Test(Description = "Проверка счётчиков каналов в тарифе и вкладке \"Мой Трансформер\"")]
        public void CheckChannelCounters()
        {
            int channelsCounter = 0;

            var page = Go.To<TransformerPage>()
                .Transformer.NavigationMenu.WaitTo.BeVisible()
                .Transformer.NavigationMenu.ClickTabByName(Consts.Tabs.AllChannels)
                .Transformer.AllChannelsTab.WaitTo.BeVisible();

            page.Transformer.AllChannelsTab.AddPackageByName(Consts.Packages.HD);
            channelsCounter += 
                int.Parse(page.Transformer.AllChannelsTab.ChannelsPackageList[p => p.Name.Value == Consts.Packages.HD].ChannelsCount.Value.Split(' ')[0]);
            page.Transformer.NavigationMenu.MyTransformerCounter.Should.BeEquivalent(channelsCounter.ToString());
            page.Rate.Body.TransformerCheck.ChannelsCount.Should.BeEquivalent($"{channelsCounter.ToString()} {Pluralizer.ChanelPlural(channelsCounter)}");

            var package = page.Transformer.AllChannelsTab.ChannelsPackageList[p => p.Name.Value == Consts.Packages.Rain];
            package.Click();
            var channel = package.Channels.ChannelsList[ch => ch.Name == Consts.Channels.Rain];
            channel.Click();
            page.ChannelCard.Footer.AddButton.Click();
            channelsCounter++;
            page.Transformer.NavigationMenu.MyTransformerCounter.Should.BeEquivalent(channelsCounter.ToString());
            page.Rate.Body.TransformerCheck.ChannelsCount.Should.BeEquivalent($"{channelsCounter.ToString()} {Pluralizer.ChanelPlural(channelsCounter)}");
        }

        [Test(Description = "Проверка заполненности прогресс бара на длину и цвет")]
        public void CheckProgressBarWidthAndColor()
        {
            var page = Go.To<TransformerPage>()
                .Rate.Body.WaitTo.BeVisible()
                .Rate.Body.TransformerCheck.ProgressBar.Progress.Should.Not.BeVisible()
                .Rate.Body.TransformerCheck.ProgressBar.Progress.Css["width"].Should.BeEquivalent("0px");

            var package = page.Transformer.NavigationMenu.ClickTabByName(Consts.Tabs.AllChannels)
                .Transformer.AllChannelsTab.WaitTo.BeVisible()
                .Transformer.AllChannelsTab.ChannelsPackageList[p => p.Name.Value == Consts.Packages.Rain];
            package.Click();

            package.Channels.ChannelsList[ch => ch.Name == Consts.Channels.Rain].Click();
            var price = double.Parse(page.ChannelCard.Footer.Price.Value.Split(' ')[0].Replace(',', '.'));
            page.ChannelCard.Footer.AddButton.Click();

            page.Rate.Body.TransformerCheck.ProgressBar.Progress.Css["width"].Should
                .Contain($"{WidthExtensions.GetIntegerPartOfWidth(price)}");

            var expectedColor = Color.FromArgb(1, 232, 0, 140);
            var expectedColorString =
                $"rgba({expectedColor.R}, {expectedColor.G}, {expectedColor.B}, {expectedColor.A})";
            page.Rate.Body.TransformerCheck.ProgressBar.Progress.Css["background-color"].Should
                .BeEquivalent(expectedColorString);

            expectedColor = Color.FromArgb(1, 126, 211, 33);
            expectedColorString = $"rgba({expectedColor.R}, {expectedColor.G}, {expectedColor.B}, {expectedColor.A})";
            page.Transformer.AllChannelsTab.AddPackageByName(Consts.Packages.SuperCinemaHD);
            page.Rate.Body.TransformerCheck.ProgressBar.Progress.Css["background-color"].Should
                .BeEquivalent(expectedColorString);
        }

        [Test(Description = "Проверка удаления канала и пакета")]
        public void CheckRemoveChannelAndPackage()
        {
            var page = Go.To<TransformerPage>()
                .Transformer.NavigationMenu.WaitTo.BeVisible()
                .Transformer.NavigationMenu.ClickTabByName(Consts.Tabs.AllChannels)
                .Transformer.AllChannelsTab.WaitTo.BeVisible()
                .Transformer.AllChannelsTab.AddPackageByName(Consts.Packages.SuperCinemaHD)
                .Transformer.AllChannelsTab.AddPackageByName(Consts.Packages.HDPlus);
            var package =
                page.Transformer.AllChannelsTab.ChannelsPackageList[p => p.Name.Value == Consts.Packages.Rain];
            package.Click();
            package.Channels.ChannelsList[ch => ch.Name == Consts.Channels.Rain].Click()
                .ChannelCard.WaitTo.BeVisible()
                .ChannelCard.Footer.AddButton.Click();

            var greenColor = Color.FromArgb(1, 126, 211, 33);
            var violetColor = Color.FromArgb(1, 232, 0, 140);
            var greenColorString = $"rgba({greenColor.R}, {greenColor.G}, {greenColor.B}, {greenColor.A})";
            var violetColorString = $"rgba({violetColor.R}, {violetColor.G}, {violetColor.B}, {violetColor.A})";

            page.Transformer.NavigationMenu.ClickTabByName(Consts.Tabs.MyTransformer);
            Assert.AreEqual(greenColorString, page.Rate.Body.TransformerCheck.ProgressBar.Progress.ColorCode);

            var packageToRemove =
                page.Transformer.MyTransformerTab.Packages[p => p.Name.Value == Consts.Packages.SuperCinemaHD];
            packageToRemove.ContextMenuButton.Click()
                .ContextMenu.WaitTo.BeVisible()
                .ContextMenu.Remove.Click();

            Assert.AreEqual(violetColorString, page.Rate.Body.TransformerCheck.ProgressBar.Progress.ColorCode);

            page.Transformer.NavigationMenu.ClickTabByName(Consts.Tabs.MyTransformer)
                .Transformer.MyTransformerTab.WaitTo.BeVisible();
            var channelToRemove =
                page.Transformer.MyTransformerTab.ChannelsGrid.Channels[ch => ch.Name == Consts.Channels.Rain];
            channelToRemove.Click().ChannelCard.Footer.RemoveChannel.Click()
                .Transformer.MyTransformerTab.ChannelsGrid.WaitTo.Not.BeVisible();

            page.ContextMenuButton.Click()
                .ContextMenu.WaitTo.BeVisible()
                .ContextMenu.RemoveAll.Click()
                .Transformer.MyTransformerTab.EmptyTransformerHint.WaitTo.BeVisible();

            page.Rate.Body.TransformerCheck.ProgressBar.Progress.Should.Not.BeVisible();
        }
    }
}