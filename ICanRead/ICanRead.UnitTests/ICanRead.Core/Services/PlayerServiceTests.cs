using ICanRead.Core.Resources;
using ICanRead.Core.Services;
using Moq;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ICanRead.UnitTests.ICanRead.Core.Services
{
    public class PlayerServiceTests
    {
        [Fact]
        public void PlayerService_PlayersFactoryIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PlayerService(null, Mock.Of<IResourceHelpers>()));
        }
        [Fact]
        public void PlayerService_ResourceHelpersIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PlayerService(Mock.Of<ISimpleAudioPlayerFactory>(), null));
        }
        [Fact]
        public void PlayerService_ResourceNotFound_FileNotFoundException()
        {
            var resourceHelpers = Mock.Of<IResourceHelpers>(ld =>
              ld.GetStreamFromFile(It.IsAny<string>()) == null);

            Assert.Throws<FileNotFoundException>(() => new PlayerService(Mock.Of<ISimpleAudioPlayerFactory>(), resourceHelpers));
        }
     
        [Fact]
        public void PlayerService_AudioNotLoaded_InvalidDataException()
        {
            var resourceHelpers = Mock.Of<IResourceHelpers>(ld =>
                ld.GetStreamFromFile(It.IsAny<string>())==new Mock<Stream>().Object);

            var factory =  Mock.Of<ISimpleAudioPlayerFactory>(ld => ld.GetSimpleAudioPlayer()==
                Mock.Of<ISimpleAudioPlayer>(p=>p.Load(It.IsAny<Stream>())==false));

            //act
            InvalidDataException invalidDataException = Assert.Throws<InvalidDataException>(() => new PlayerService(factory, resourceHelpers));
        }

        [Fact]
        public void PlayClickSound_CorrectData_SimpleAudioPlayerWasPlayed()
        {
            var resourceHelpers = Mock.Of<IResourceHelpers>(ld =>
              ld.GetStreamFromFile(It.IsAny<string>()) == new Mock<Stream>().Object);

            var player = new Mock<ISimpleAudioPlayer>();
            player.Setup(ld => ld.Load(It.IsAny<Stream>())).Returns(true);

            var factory = Mock.Of<ISimpleAudioPlayerFactory>(ld => 
               ld.GetSimpleAudioPlayer() == player.Object);

            var playerService = new PlayerService(factory, resourceHelpers);

            //act
            playerService.PlayClickSound();

            //verify
            player.Verify(p => p.Play());
        }

    }
}
