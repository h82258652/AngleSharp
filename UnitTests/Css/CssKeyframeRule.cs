﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngleSharp.DOM.Css;
using AngleSharp.Parser.Css;
using System.Linq;

namespace UnitTests.Css
{
    [TestClass]
    public class CssKeyframeRuleTests
    {
        CSSKeyframeRule Create(String source)
        {
            return CssParser.ParseKeyframeRule(source);
        }

        [TestMethod]
        public void KeyframeRuleWithFromAndMarginLeft()
        {
            var rule = Create(@"  from {
    margin-left: 0px;
  }");
            Assert.IsNotNull(rule);
            Assert.AreEqual("0%", rule.KeyText);
            Assert.AreEqual(1, rule.Key.Stops.Count());
            Assert.AreEqual(1, rule.Style.Declarations.Count());
            Assert.AreEqual("margin-left", rule.Style.Declarations.First().Name);
        }

        [TestMethod]
        public void KeyframeRuleWith50PercentAndMarginLeftOpacity()
        {
            var rule = Create(@"  50% {
    margin-left: 110px;
    opacity: 1;
  }");
            Assert.IsNotNull(rule);
            Assert.AreEqual("50%", rule.KeyText);
            Assert.AreEqual(1, rule.Key.Stops.Count());
            Assert.AreEqual(2, rule.Style.Declarations.Count());
            Assert.AreEqual("margin-left", rule.Style.Declarations.Skip(0).First().Name);
            Assert.AreEqual("opacity", rule.Style.Declarations.Skip(1).First().Name);
        }

        [TestMethod]
        public void KeyframeRuleWithToAndMarginLeft()
        {
            var rule = Create(@"  to {
    margin-left: 200px;
  }");
            Assert.IsNotNull(rule);
            Assert.AreEqual("100%", rule.KeyText);
            Assert.AreEqual(1, rule.Key.Stops.Count());
            Assert.AreEqual(1, rule.Style.Declarations.Count());
            Assert.AreEqual("margin-left", rule.Style.Declarations.First().Name);
        }

        [TestMethod]
        public void KeyframeRuleWithFromTo255075PercentAndPaddingTopPaddingLeftColor()
        {
            var rule = Create(@"  from,to, 25%, 50%,75%{
    padding-top: 200px;
    padding-left: 2em;
    color: red
  }");
            Assert.IsNotNull(rule);
            Assert.AreEqual("0%, 100%, 25%, 50%, 75%", rule.KeyText);
            Assert.AreEqual(5, rule.Key.Stops.Count());
            Assert.AreEqual(3, rule.Style.Declarations.Count());
            Assert.AreEqual("padding-top", rule.Style.Declarations.Skip(0).First().Name);
            Assert.AreEqual("padding-left", rule.Style.Declarations.Skip(1).First().Name);
            Assert.AreEqual("color", rule.Style.Declarations.Skip(2).First().Name);
        }

        [TestMethod]
        public void KeyframeRuleWith0AndNoDeclarations()
        {
            var rule = Create(@"  0% { }");
            Assert.IsNotNull(rule);
            Assert.AreEqual("0%", rule.KeyText);
            Assert.AreEqual(1, rule.Key.Stops.Count());
            Assert.AreEqual(0, rule.Style.Declarations.Count());
        }
    }
}
