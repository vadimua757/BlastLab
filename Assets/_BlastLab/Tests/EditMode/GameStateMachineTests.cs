using System;
using BlastLab.Core;
using NUnit.Framework;

namespace BlastLab.Tests
{
    public class GameStateMachineTests
    {
        [Test]
        public void StartsAsNone() => Assert.AreEqual(GameState.None, new GameStateMachine().Current);

        [Test]
        public void NoneToMainMenuToSandboxAndBack_Works()
        {
            var sm = new GameStateMachine();
            sm.ChangeTo(GameState.MainMenu);
            sm.ChangeTo(GameState.Sandbox);
            sm.ChangeTo(GameState.MainMenu);
            Assert.AreEqual(GameState.MainMenu, sm.Current);
        }

        [Test]
        public void InvalidTransition_Throws()
        {
            var sm = new GameStateMachine();
            Assert.Throws<InvalidOperationException>(() => sm.ChangeTo(GameState.Sandbox));
        }

        [Test]
        public void StateChanged_ReportsPreviousAndNew()
        {
            var sm = new GameStateMachine();
            GameState from = GameState.Sandbox, to = GameState.None;
            sm.StateChanged += (a, b) => { from = a; to = b; };
            sm.ChangeTo(GameState.MainMenu);
            Assert.AreEqual(GameState.None, from);
            Assert.AreEqual(GameState.MainMenu, to);
        }
    }
}
