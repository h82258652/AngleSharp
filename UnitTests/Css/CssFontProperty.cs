﻿using AngleSharp;
using AngleSharp.Css;
using AngleSharp.DOM.Css;
using AngleSharp.Parser.Css;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTests.Css
{
    [TestClass]
    public class CssFontPropertyTests
    {
        [TestMethod]
        public void CssFontFamilyMultipleWithIdentifiersLegal()
        {
            var snippet = "font-family: Gill Sans Extrabold, sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("gill sans extrabold, sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontFamilyInitialLegal()
        {
            var snippet = "font-family: initial ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("initial", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontFamilyMultipleDiverseLegal()
        {
            var snippet = "font-family: Courier, \"Lucida Console\", monospace ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("courier, 'Lucida Console', monospace", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontFamilyMultipleStringLegal()
        {
            var snippet = "font-family: \"Goudy Bookletter 1911\", sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("'Goudy Bookletter 1911', sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontFamilyMultipleNumberIllegal()
        {
            var snippet = "font-family: Goudy Bookletter 1911, sans-serif  ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyMultipleFractionIllegal()
        {
            var snippet = "font-family: Red/Black, sans-serif  ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyMultipleStringMixedWithIdentifierIllegal()
        {
            var snippet = "font-family: \"Lucida\" Grande, sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyMultipleExclamationMarkIllegal()
        {
            var snippet = "font-family: Ahem!, sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyMultipleAtIllegal()
        {
            var snippet = "font-family: test@foo, sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyHashIllegal()
        {
            var snippet = "font-family: #POUND ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontFamilyDashIllegal()
        {
            var snippet = "font-family: Hawaii 5-0 ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-family", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontFamilyProperty));
            var concrete = (CSSFontFamilyProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontVariantNormalUppercaseLegal()
        {
            var snippet = "font-variant : NORMAL";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-variant", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontVariantProperty));
            var concrete = (CSSFontVariantProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("normal", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontVariantSmallCapsLegal()
        {
            var snippet = "font-variant : small-caps ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-variant", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontVariantProperty));
            var concrete = (CSSFontVariantProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("small-caps", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontVariantSmallCapsIllegal()
        {
            var snippet = "font-variant : smallCaps ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-variant", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontVariantProperty));
            var concrete = (CSSFontVariantProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontStyleItalicLegal()
        {
            var snippet = "font-style : italic";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-style", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStyleProperty));
            var concrete = (CSSFontStyleProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("italic", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStyleObliqueLegal()
        {
            var snippet = "font-style : oblique ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-style", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStyleProperty));
            var concrete = (CSSFontStyleProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("oblique", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStyleNormalImportantLegal()
        {
            var snippet = "font-style : normal !important";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-style", property.Name);
            Assert.IsTrue(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStyleProperty));
            var concrete = (CSSFontStyleProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("normal", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAbsoluteImportantXxSmallLegal()
        {
            var snippet = "font-size : xx-small !important";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsTrue(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("xx-small", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAbsoluteMediumUppercaseLegal()
        {
            var snippet = "font-size : medium";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("medium", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAbsoluteLargeImportantLegal()
        {
            var snippet = "font-size : large !important";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsTrue(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("large", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeRelativeLargerLegal()
        {
            var snippet = "font-size : larger ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("larger", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeRelativeLargestIllegal()
        {
            var snippet = "font-size : largest ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontSizePercentLegal()
        {
            var snippet = "font-size : 120% ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("120%", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeZeroLegal()
        {
            var snippet = "font-size : 0 ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("0", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeLengthLegal()
        {
            var snippet = "font-size : 3.5em ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("3.5em", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeNumberIllegal()
        {
            var snippet = "font-size : 120.3 ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeProperty));
            var concrete = (CSSFontSizeProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontWeightPercentllegal()
        {
            var snippet = "font-weight : 100% ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-weight", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontWeightProperty));
            var concrete = (CSSFontWeightProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontWeightBolderLegalImportant()
        {
            var snippet = "font-weight : bolder !important";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-weight", property.Name);
            Assert.IsTrue(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontWeightProperty));
            var concrete = (CSSFontWeightProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("bolder", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontWeightBoldLegal()
        {
            var snippet = "font-weight : bold";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-weight", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontWeightProperty));
            var concrete = (CSSFontWeightProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("bold", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontWeight400Legal()
        {
            var snippet = "font-weight : 400 ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-weight", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontWeightProperty));
            var concrete = (CSSFontWeightProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("400", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStretchNormalUppercaseImportantLegal()
        {
            var snippet = "font-stretch : NORMAL !important";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-stretch", property.Name);
            Assert.IsTrue(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStretchProperty));
            var concrete = (CSSFontStretchProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("normal", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStretchExtraCondensedLegal()
        {
            var snippet = "font-stretch : extra-condensed ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-stretch", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStretchProperty));
            var concrete = (CSSFontStretchProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("extra-condensed", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStretchSemiExpandedSpaceBetweenIllegal()
        {
            var snippet = "font-stretch : semi expanded ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-stretch", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontStretchProperty));
            var concrete = (CSSFontStretchProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontShorthandWithFractionLegal()
        {
            var snippet = "font : 12px/14px sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("12px / 14px sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontShorthandPercentLegal()
        {
            var snippet = "font : 80% sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("80% sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontShorthandBoldItalicLargeLegal()
        {
            var snippet = "font : bold italic large serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("bold italic large serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontShorthandPredefinedLegal()
        {
            var snippet = "font : status-bar ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("status-bar", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontShorthandSizeAndFontListLegal()
        {
            var snippet = "font : 15px arial,sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("15px arial, sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontShorthandStyleWeightSizeLineHeightAndFontListLegal()
        {
            var snippet = "font : italic bold 12px/30px Georgia, serif";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("italic bold 12px / 30px georgia, serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssLetterSpacingLengthPxLegal()
        {
            var snippet = "letter-spacing: 3px ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("letter-spacing", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSLetterSpacingProperty));
            var concrete = (CSSLetterSpacingProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("3px", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssLetterSpacingLengthFloatPxLegal()
        {
            var snippet = "letter-spacing: .3px ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("letter-spacing", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSLetterSpacingProperty));
            var concrete = (CSSLetterSpacingProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("0.3px", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssLetterSpacingLengthFloatEmLegal()
        {
            var snippet = "letter-spacing: 0.3em ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("letter-spacing", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSLetterSpacingProperty));
            var concrete = (CSSLetterSpacingProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("0.3em", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssLetterSpacingNormalLegal()
        {
            var snippet = "letter-spacing: normal ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("letter-spacing", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSLetterSpacingProperty));
            var concrete = (CSSLetterSpacingProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("normal", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAdjustNoneLegal()
        {
            var snippet = "font-size-adjust : NONE";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size-adjust", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeAdjustProperty));
            var concrete = (CSSFontSizeAdjustProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("none", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAdjustNumberLegal()
        {
            var snippet = "font-size-adjust : 0.5";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size-adjust", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeAdjustProperty));
            var concrete = (CSSFontSizeAdjustProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("0.5", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeAdjustLengthIllegal()
        {
            var snippet = "font-size-adjust : 1.1em ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font-size-adjust", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontSizeAdjustProperty));
            var concrete = (CSSFontSizeAdjustProperty)property;
            Assert.AreEqual(CssValueType.Initial, concrete.Value.Type);
            Assert.IsTrue(concrete.IsInherited);
            Assert.IsFalse(concrete.HasValue);
        }

        [TestMethod]
        public void CssFontSizeHeightFamilyLegal()
        {
            var snippet = "font: 12pt/14pt sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("12pt / 14pt sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeFamilyLegal()
        {
            var snippet = "font: 80% sans-serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("80% sans-serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSizeHeightMultipleFamiliesLegal()
        {
            var snippet = "font: x-large/110% 'new century schoolbook', serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("x-large / 110% 'new century schoolbook', serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontWeightVariantSizeFamiliesLegal()
        {
            var snippet = "font: bold italic large Palatino, serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("bold italic large palatino, serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStyleVariantSizeHeightFamilyLegal()
        {
            var snippet = "font: normal small-caps 120%/120% fantasy ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("normal small-caps 120% / 120% fantasy", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStyleVariantSizeFamiliesLegal()
        {
            var snippet = "font: condensed oblique 12pt \"Helvetica Neue\", serif ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("condensed oblique 12pt 'Helvetica Neue', serif", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontSystemFamilyLegal()
        {
            var snippet = "font: status-bar ";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.Primitive, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("status-bar", concrete.Value.CssText);
        }

        [TestMethod]
        public void CssFontStyleWeightSizeHeightFamiliesLegal()
        {
            var snippet = "font: italic bold 12px / 30px Georgia, serif";
            var property = CssParser.ParseDeclaration(snippet);
            Assert.AreEqual("font", property.Name);
            Assert.IsFalse(property.IsImportant);
            Assert.IsInstanceOfType(property, typeof(CSSFontProperty));
            var concrete = (CSSFontProperty)property;
            Assert.AreEqual(CssValueType.List, concrete.Value.Type);
            Assert.IsFalse(concrete.IsInherited);
            Assert.IsTrue(concrete.HasValue);
            Assert.AreEqual("italic bold 12px / 30px georgia, serif", concrete.Value.CssText);
            Assert.AreEqual(new Length(30f, Length.Unit.Px), concrete.Height);
            Assert.AreEqual(new Length(12f, Length.Unit.Px), concrete.Size);
            Assert.AreEqual(FontStyle.Italic, concrete.Style);
            Assert.AreEqual(2, concrete.Families.Count());
            Assert.AreEqual("georgia", concrete.Families.First());
            Assert.AreEqual("Times New Roman", concrete.Families.Skip(1).First());
        }
    }
}
