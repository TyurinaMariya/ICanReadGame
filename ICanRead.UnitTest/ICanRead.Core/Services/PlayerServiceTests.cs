using ICanRead.Core.Resources;
using ICanRead.Core.Services;
using Moq;
using NUnit.Framework;
using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICanRead.UnitTests.ICanRead.Core.Services
{
    public class PlayerServiceTests
    {
        

        //[Test]
        //public void PlayClickSound_CorrectData_SimpleAudioPlayerWasPlayed()
        //{
        //    var resourceHelpers = Mock.Of<IResourceHelpers>(ld =>
        //      ld.GetStreamFromFile(It.IsAny<string>()) == new Mock<Stream>().Object);

        //    var player = new Mock<ISimpleAudioPlayer>();
        //    player.Setup(ld => ld.Load(It.IsAny<Stream>())).Returns(true);

        //    var factory = Mock.Of<ISimpleAudioPlayerFactory>(ld => 
        //       ld.GetSimpleAudioPlayer() == player.Object);

        //    var playerService = new PlayerService(factory, resourceHelpers);

        //    //act
        //    playerService.PlayClickSound();

        //    //verify
        //    player.Verify(p => p.Play());
        //}

    }
}
