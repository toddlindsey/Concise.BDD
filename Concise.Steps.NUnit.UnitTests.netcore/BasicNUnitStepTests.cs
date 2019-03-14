﻿using System;
using FluentAssertions;
using Concise.Steps;
using NUnit.Framework;

namespace Concise.Steps.NUnit.UnitTests
{
    [Description("Test class description")]
    public class BasicNUnitStepTests
    {
        [StepTest]
        public void BasicStepTest_Step_WillAlways_ExecuteImmediately()
        {
            bool ran = false;
            "Step"._(() => ran = true);
            ran.Should().BeTrue();
        }


        [StepTest]
        public void BasicStepTest_Step_IfFailsWithAnyException_WillPropogateThatException()
        {
            Action step = () =>
            {
                "Step that fails"._(() => throw new Exception("My Exception"));
            };

            step.Should().Throw<Exception>()
                .And.Message.Should().Be("My Exception");
        }

        [StepTest]
        public void BasicStepTest_ThreeSteps()
        {
            "Step 1"._(() => { });
            "Step 2"._(() => { });
            "Step 3"._(() => { });
        }

        [StepTest]
        [Ignore("Run to test failing test")]
        public void BasicStepTest_FailedOnStep()
        {
            "Step 1"._(() => { });
            "Step 2"._(() => {
                true.Should().BeFalse("I say so");
            });
            "Step 3"._(() => { });
        }

        [StepTest]
        [Ignore("Run to test failing test")]
        public void BasicStepTest_InconclusiveOnStep()
        {
            "Step 1"._(() => { });
            "Step 2"._(() => {
                Assert.Inconclusive("My message");
            });
            "Step 3"._(() => { });
        }

        [StepTest]
        public void BasicStepTest_AssertPassedOnStep()
        {
            "Step 1"._(() => { });
            "Step 2"._(() => {
                Assert.Pass("My message");
            });
            "Step 3"._(() => { });
        }

        [StepTest]
        [Ignore("Run to test failing test")]
        public void BasicStepTest_ExceptionOnStep()
        {
            "Step 1"._(() => { });
            "Step 2"._(() => {
                throw new InvalidOperationException("My message");
            });
            "Step 3"._(() => { });
        }
    }
}
