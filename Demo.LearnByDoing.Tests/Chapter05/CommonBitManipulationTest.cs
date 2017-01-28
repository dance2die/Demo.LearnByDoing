﻿using System;
using Demo.LearnByDoing.Tests.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Chapter05
{
    public class CommonBitManipulationTest : BaseTest
    {
        private readonly CommonBitManipulation _sut = new CommonBitManipulation();

        public CommonBitManipulationTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestGettingBits()
        {
            int val8 = 8;
            for (int i = 0; i < 4; i++)
            {
                _output.WriteLine("{0} gets bit: {1} at position {2}", Convert.ToString(val8, 2), _sut.GetBit(val8, i), i);
            }

            Assert.False(_sut.GetBit(val8, 0));
            Assert.False(_sut.GetBit(val8, 1));
            Assert.False(_sut.GetBit(val8, 2));
            Assert.True(_sut.GetBit(val8, 3));
        }

        [Fact]
        public void TestSettingBits()
        {
            int value = 0;

            Assert.Equal(1, _sut.SetBit(value, 0));
            Assert.Equal(2, _sut.SetBit(value, 1));
            Assert.Equal(4, _sut.SetBit(value, 2));
            Assert.Equal(8, _sut.SetBit(value, 3));
        }

        [Fact]
        public void TestClearingBits()
        {
            int value = 239;

            Assert.Equal(238, _sut.ClearBit(value, 0));
            Assert.Equal(237, _sut.ClearBit(value, 1));
            Assert.Equal(235, _sut.ClearBit(value, 2));
            Assert.Equal(231, _sut.ClearBit(value, 3));
        }
    }

    public class CommonBitManipulation
    {
        public int ClearBit(int num, int i)
        {
            var mask = ~(1 << i);
            return num & mask;
        }

        public bool GetBit(int num, int i)
        {
            int mask = 1 << i;
            return (num & mask) != 0;
        }

        public int SetBit(int num, int i)
        {
            int mask = 1 << i;
            return (num | mask);
        }
    }
}
