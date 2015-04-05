using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml;
using A = DocumentFormat.OpenXml.Drawing;
using P14 = DocumentFormat.OpenXml.Office2010.PowerPoint;
using P15 = DocumentFormat.OpenXml.Office2013.PowerPoint;
using Thm15 = DocumentFormat.OpenXml.Office2013.Theme;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;

namespace EasyOXML
{
    public class XMLManager
    {

        // Creates a PresentationDocument.
        public void CreatePackage(string filePath)
        {
            using (PresentationDocument package = PresentationDocument.Create(filePath, PresentationDocumentType.Presentation))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(PresentationDocument document)
        {
            //슬라이드 Thumbnail 이미지
            ThumbnailPart thumbnailPart1 = document.AddNewPart<ThumbnailPart>("image/jpeg", "rId2");
            GenerateThumbnailPart1Content(thumbnailPart1);

            //프리젠테이션 파트
            PresentationPart presentationPart1 = document.AddPresentationPart();
            GeneratePresentationPart1Content(presentationPart1);
            //프리젠테이션 파트 프로퍼티
            PresentationPropertiesPart presentationPropertiesPart1 = presentationPart1.AddNewPart<PresentationPropertiesPart>("rId3");
            GeneratePresentationPropertiesPart1Content(presentationPropertiesPart1);

            //슬라이드1
            SlidePart slidePart1 = presentationPart1.AddNewPart<SlidePart>("rId2");
            GenerateSlidePart1Content(slidePart1);
            //슬라이드 레이아웃
            SlideLayoutPart slideLayoutPart1 = slidePart1.AddNewPart<SlideLayoutPart>("rId1");
            GenerateSlideLayoutPart1Content(slideLayoutPart1);
            //슬라이드 마스터
            SlideMasterPart slideMasterPart1 = slideLayoutPart1.AddNewPart<SlideMasterPart>("rId1");
            GenerateSlideMasterPart1Content(slideMasterPart1);
            //슬라이드 레이아웃2 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart2 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId8");
            GenerateSlideLayoutPart2Content(slideLayoutPart2);

            slideLayoutPart2.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃3 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart3 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId3");
            GenerateSlideLayoutPart3Content(slideLayoutPart3);
            
            slideLayoutPart3.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃4 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart4 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId7");
            GenerateSlideLayoutPart4Content(slideLayoutPart4);

            slideLayoutPart4.AddPart(slideMasterPart1, "rId1");
            //슬라이드 테마
            ThemePart themePart1 = slideMasterPart1.AddNewPart<ThemePart>("rId12");
            GenerateThemePart1Content(themePart1);
            //슬라이드 레이아웃5 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart5 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId2");
            GenerateSlideLayoutPart5Content(slideLayoutPart5);

            slideLayoutPart5.AddPart(slideMasterPart1, "rId1");
            //슬라이드 마스터1 => 슬라이드레이아웃 1
            slideMasterPart1.AddPart(slideLayoutPart1, "rId1");
            //슬라이드 레이아웃6 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart6 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId6");
            GenerateSlideLayoutPart6Content(slideLayoutPart6);

            slideLayoutPart6.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃7 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart7 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId11");
            GenerateSlideLayoutPart7Content(slideLayoutPart7);

            slideLayoutPart7.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃8 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart8 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId5");
            GenerateSlideLayoutPart8Content(slideLayoutPart8);

            slideLayoutPart8.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃9 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart9 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId10");
            GenerateSlideLayoutPart9Content(slideLayoutPart9);

            slideLayoutPart9.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃10 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart10 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId4");
            GenerateSlideLayoutPart10Content(slideLayoutPart10);

            slideLayoutPart10.AddPart(slideMasterPart1, "rId1");
            //슬라이드 레이아웃11 => 슬라이드마스터
            SlideLayoutPart slideLayoutPart11 = slideMasterPart1.AddNewPart<SlideLayoutPart>("rId9");
            GenerateSlideLayoutPart11Content(slideLayoutPart11);

            slideLayoutPart11.AddPart(slideMasterPart1, "rId1");
            //슬라이드1 <= 슬라이드마스터 1
            presentationPart1.AddPart(slideMasterPart1, "rId1");
            //테이블스타일 
            TableStylesPart tableStylesPart1 = presentationPart1.AddNewPart<TableStylesPart>("rId6");
            GenerateTableStylesPart1Content(tableStylesPart1);
            //테이블스타일 => 테마1
            presentationPart1.AddPart(themePart1, "rId5");
            //뷰 프로퍼티1
            ViewPropertiesPart viewPropertiesPart1 = presentationPart1.AddNewPart<ViewPropertiesPart>("rId4");
            GenerateViewPropertiesPart1Content(viewPropertiesPart1);
            //Extened파일 프로퍼티 1
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId4");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);
            //SetPackage프로퍼티
            SetPackageProperties(document);
        }

        // Generates content of thumbnailPart1.
        private void GenerateThumbnailPart1Content(ThumbnailPart thumbnailPart1)
        {
            System.IO.Stream data = GetBinaryDataStream(thumbnailPart1Data);
            thumbnailPart1.FeedData(data);
            data.Close();
        }

        // Generates content of presentationPart1.
        private void GeneratePresentationPart1Content(PresentationPart presentationPart1)
        {
            Presentation presentation1 = new Presentation() { SaveSubsetFonts = true };
            presentation1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentation1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentation1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            SlideMasterIdList slideMasterIdList1 = new SlideMasterIdList();
            SlideMasterId slideMasterId1 = new SlideMasterId() { Id = (UInt32Value)2147483660U, RelationshipId = "rId1" };

            slideMasterIdList1.Append(slideMasterId1);

            SlideIdList slideIdList1 = new SlideIdList();
            SlideId slideId1 = new SlideId() { Id = (UInt32Value)256U, RelationshipId = "rId2" };

            slideIdList1.Append(slideId1);
            SlideSize slideSize1 = new SlideSize() { Cx = 9144000, Cy = 6858000, Type = SlideSizeValues.Screen4x3 };
            NotesSize notesSize1 = new NotesSize() { Cx = 6858000L, Cy = 9144000L };

            DefaultTextStyle defaultTextStyle1 = new DefaultTextStyle();

            A.DefaultParagraphProperties defaultParagraphProperties1 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties1 = new A.DefaultRunProperties() { Language = "ko-KR" };

            defaultParagraphProperties1.Append(defaultRunProperties1);

            A.Level1ParagraphProperties level1ParagraphProperties1 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties2 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill1.Append(schemeColor1);
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties2.Append(solidFill1);
            defaultRunProperties2.Append(latinFont1);
            defaultRunProperties2.Append(eastAsianFont1);
            defaultRunProperties2.Append(complexScriptFont1);

            level1ParagraphProperties1.Append(defaultRunProperties2);

            A.Level2ParagraphProperties level2ParagraphProperties1 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties3 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill2.Append(schemeColor2);
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties3.Append(solidFill2);
            defaultRunProperties3.Append(latinFont2);
            defaultRunProperties3.Append(eastAsianFont2);
            defaultRunProperties3.Append(complexScriptFont2);

            level2ParagraphProperties1.Append(defaultRunProperties3);

            A.Level3ParagraphProperties level3ParagraphProperties1 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties4 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill3.Append(schemeColor3);
            A.LatinFont latinFont3 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont3 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont3 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties4.Append(solidFill3);
            defaultRunProperties4.Append(latinFont3);
            defaultRunProperties4.Append(eastAsianFont3);
            defaultRunProperties4.Append(complexScriptFont3);

            level3ParagraphProperties1.Append(defaultRunProperties4);

            A.Level4ParagraphProperties level4ParagraphProperties1 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties5 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill4.Append(schemeColor4);
            A.LatinFont latinFont4 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont4 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont4 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties5.Append(solidFill4);
            defaultRunProperties5.Append(latinFont4);
            defaultRunProperties5.Append(eastAsianFont4);
            defaultRunProperties5.Append(complexScriptFont4);

            level4ParagraphProperties1.Append(defaultRunProperties5);

            A.Level5ParagraphProperties level5ParagraphProperties1 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties6 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill5.Append(schemeColor5);
            A.LatinFont latinFont5 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont5 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont5 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties6.Append(solidFill5);
            defaultRunProperties6.Append(latinFont5);
            defaultRunProperties6.Append(eastAsianFont5);
            defaultRunProperties6.Append(complexScriptFont5);

            level5ParagraphProperties1.Append(defaultRunProperties6);

            A.Level6ParagraphProperties level6ParagraphProperties1 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties7 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill6 = new A.SolidFill();
            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill6.Append(schemeColor6);
            A.LatinFont latinFont6 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont6 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont6 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties7.Append(solidFill6);
            defaultRunProperties7.Append(latinFont6);
            defaultRunProperties7.Append(eastAsianFont6);
            defaultRunProperties7.Append(complexScriptFont6);

            level6ParagraphProperties1.Append(defaultRunProperties7);

            A.Level7ParagraphProperties level7ParagraphProperties1 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties8 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill7 = new A.SolidFill();
            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill7.Append(schemeColor7);
            A.LatinFont latinFont7 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont7 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont7 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties8.Append(solidFill7);
            defaultRunProperties8.Append(latinFont7);
            defaultRunProperties8.Append(eastAsianFont7);
            defaultRunProperties8.Append(complexScriptFont7);

            level7ParagraphProperties1.Append(defaultRunProperties8);

            A.Level8ParagraphProperties level8ParagraphProperties1 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties9 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill8 = new A.SolidFill();
            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill8.Append(schemeColor8);
            A.LatinFont latinFont8 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont8 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont8 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties9.Append(solidFill8);
            defaultRunProperties9.Append(latinFont8);
            defaultRunProperties9.Append(eastAsianFont8);
            defaultRunProperties9.Append(complexScriptFont8);

            level8ParagraphProperties1.Append(defaultRunProperties9);

            A.Level9ParagraphProperties level9ParagraphProperties1 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties10 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill9 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill9.Append(schemeColor9);
            A.LatinFont latinFont9 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont9 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont9 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties10.Append(solidFill9);
            defaultRunProperties10.Append(latinFont9);
            defaultRunProperties10.Append(eastAsianFont9);
            defaultRunProperties10.Append(complexScriptFont9);

            level9ParagraphProperties1.Append(defaultRunProperties10);

            defaultTextStyle1.Append(defaultParagraphProperties1);
            defaultTextStyle1.Append(level1ParagraphProperties1);
            defaultTextStyle1.Append(level2ParagraphProperties1);
            defaultTextStyle1.Append(level3ParagraphProperties1);
            defaultTextStyle1.Append(level4ParagraphProperties1);
            defaultTextStyle1.Append(level5ParagraphProperties1);
            defaultTextStyle1.Append(level6ParagraphProperties1);
            defaultTextStyle1.Append(level7ParagraphProperties1);
            defaultTextStyle1.Append(level8ParagraphProperties1);
            defaultTextStyle1.Append(level9ParagraphProperties1);

            presentation1.Append(slideMasterIdList1);
            presentation1.Append(slideIdList1);
            presentation1.Append(slideSize1);
            presentation1.Append(notesSize1);
            presentation1.Append(defaultTextStyle1);

            presentationPart1.Presentation = presentation1;
        }

        // Generates content of presentationPropertiesPart1.
        private void GeneratePresentationPropertiesPart1Content(PresentationPropertiesPart presentationPropertiesPart1)
        {
            PresentationProperties presentationProperties1 = new PresentationProperties();
            presentationProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            presentationProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            presentationProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            PresentationPropertiesExtensionList presentationPropertiesExtensionList1 = new PresentationPropertiesExtensionList();

            PresentationPropertiesExtension presentationPropertiesExtension1 = new PresentationPropertiesExtension() { Uri = "{E76CE94A-603C-4142-B9EB-6D1370010A27}" };

            P14.DiscardImageEditData discardImageEditData1 = new P14.DiscardImageEditData() { Val = false };
            discardImageEditData1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension1.Append(discardImageEditData1);

            PresentationPropertiesExtension presentationPropertiesExtension2 = new PresentationPropertiesExtension() { Uri = "{D31A062A-798A-4329-ABDD-BBA856620510}" };

            P14.DefaultImageDpi defaultImageDpi1 = new P14.DefaultImageDpi() { Val = (UInt32Value)220U };
            defaultImageDpi1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            presentationPropertiesExtension2.Append(defaultImageDpi1);

            PresentationPropertiesExtension presentationPropertiesExtension3 = new PresentationPropertiesExtension() { Uri = "{FD5EFAAD-0ECE-453E-9831-46B23BE46B34}" };

            P15.ChartTrackingReferenceBased chartTrackingReferenceBased1 = new P15.ChartTrackingReferenceBased() { Val = true };
            chartTrackingReferenceBased1.AddNamespaceDeclaration("p15", "http://schemas.microsoft.com/office/powerpoint/2012/main");

            presentationPropertiesExtension3.Append(chartTrackingReferenceBased1);

            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension1);
            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension2);
            presentationPropertiesExtensionList1.Append(presentationPropertiesExtension3);

            presentationProperties1.Append(presentationPropertiesExtensionList1);

            presentationPropertiesPart1.PresentationProperties = presentationProperties1;
        }

        // Generates content of slidePart1.
        private void GenerateSlidePart1Content(SlidePart slidePart1)
        {
            Slide slide1 = new Slide();
            slide1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slide1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slide1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData1 = new CommonSlideData();

            ShapeTree shapeTree1 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties1 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties1 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties1 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties1 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties1.Append(nonVisualDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(nonVisualGroupShapeDrawingProperties1);
            nonVisualGroupShapeProperties1.Append(applicationNonVisualDrawingProperties1);

            GroupShapeProperties groupShapeProperties1 = new GroupShapeProperties();

            A.TransformGroup transformGroup1 = new A.TransformGroup();
            A.Offset offset1 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents1 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset1 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents1 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup1.Append(offset1);
            transformGroup1.Append(extents1);
            transformGroup1.Append(childOffset1);
            transformGroup1.Append(childExtents1);

            groupShapeProperties1.Append(transformGroup1);

            GroupShape groupShape1 = new GroupShape();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties2 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties2 = new NonVisualDrawingProperties() { Id = (UInt32Value)10U, Name = "그룹 9" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties2 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties2 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties2.Append(nonVisualDrawingProperties2);
            nonVisualGroupShapeProperties2.Append(nonVisualGroupShapeDrawingProperties2);
            nonVisualGroupShapeProperties2.Append(applicationNonVisualDrawingProperties2);

            GroupShapeProperties groupShapeProperties2 = new GroupShapeProperties();

            A.TransformGroup transformGroup2 = new A.TransformGroup();
            A.Offset offset2 = new A.Offset() { X = 2777706L, Y = 793630L };
            A.Extents extents2 = new A.Extents() { Cx = 3269412L, Cy = 5348376L };
            A.ChildOffset childOffset2 = new A.ChildOffset() { X = 2777706L, Y = 793630L };
            A.ChildExtents childExtents2 = new A.ChildExtents() { Cx = 3269412L, Cy = 5348376L };

            transformGroup2.Append(offset2);
            transformGroup2.Append(extents2);
            transformGroup2.Append(childOffset2);
            transformGroup2.Append(childExtents2);

            groupShapeProperties2.Append(transformGroup2);

            ConnectionShape connectionShape1 = new ConnectionShape();

            NonVisualConnectionShapeProperties nonVisualConnectionShapeProperties1 = new NonVisualConnectionShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties3 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "직선 화살표 연결선 4" };
            NonVisualConnectorShapeDrawingProperties nonVisualConnectorShapeDrawingProperties1 = new NonVisualConnectorShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties3 = new ApplicationNonVisualDrawingProperties();

            nonVisualConnectionShapeProperties1.Append(nonVisualDrawingProperties3);
            nonVisualConnectionShapeProperties1.Append(nonVisualConnectorShapeDrawingProperties1);
            nonVisualConnectionShapeProperties1.Append(applicationNonVisualDrawingProperties3);

            ShapeProperties shapeProperties1 = new ShapeProperties();

            A.Transform2D transform2D1 = new A.Transform2D() { VerticalFlip = true };
            A.Offset offset3 = new A.Offset() { X = 2958861L, Y = 793630L };
            A.Extents extents3 = new A.Extents() { Cx = 2708694L, Cy = 1492369L };

            transform2D1.Append(offset3);
            transform2D1.Append(extents3);

            A.PresetGeometry presetGeometry1 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.StraightConnector1 };
            A.AdjustValueList adjustValueList1 = new A.AdjustValueList();

            presetGeometry1.Append(adjustValueList1);

            A.Outline outline1 = new A.Outline() { Width = 57150 };
            A.TailEnd tailEnd1 = new A.TailEnd() { Type = A.LineEndValues.Triangle };

            outline1.Append(tailEnd1);

            shapeProperties1.Append(transform2D1);
            shapeProperties1.Append(presetGeometry1);
            shapeProperties1.Append(outline1);

            ShapeStyle shapeStyle1 = new ShapeStyle();

            A.LineReference lineReference1 = new A.LineReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference1.Append(schemeColor10);

            A.FillReference fillReference1 = new A.FillReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference1.Append(schemeColor11);

            A.EffectReference effectReference1 = new A.EffectReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference1.Append(schemeColor12);

            A.FontReference fontReference1 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            fontReference1.Append(schemeColor13);

            shapeStyle1.Append(lineReference1);
            shapeStyle1.Append(fillReference1);
            shapeStyle1.Append(effectReference1);
            shapeStyle1.Append(fontReference1);

            connectionShape1.Append(nonVisualConnectionShapeProperties1);
            connectionShape1.Append(shapeProperties1);
            connectionShape1.Append(shapeStyle1);

            ConnectionShape connectionShape2 = new ConnectionShape();

            NonVisualConnectionShapeProperties nonVisualConnectionShapeProperties2 = new NonVisualConnectionShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties4 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "직선 연결선 6" };
            NonVisualConnectorShapeDrawingProperties nonVisualConnectorShapeDrawingProperties2 = new NonVisualConnectorShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties4 = new ApplicationNonVisualDrawingProperties();

            nonVisualConnectionShapeProperties2.Append(nonVisualDrawingProperties4);
            nonVisualConnectionShapeProperties2.Append(nonVisualConnectorShapeDrawingProperties2);
            nonVisualConnectionShapeProperties2.Append(applicationNonVisualDrawingProperties4);

            ShapeProperties shapeProperties2 = new ShapeProperties();

            A.Transform2D transform2D2 = new A.Transform2D() { HorizontalFlip = true };
            A.Offset offset4 = new A.Offset() { X = 2777706L, Y = 2285999L };
            A.Extents extents4 = new A.Extents() { Cx = 181155L, Cy = 2872596L };

            transform2D2.Append(offset4);
            transform2D2.Append(extents4);

            A.PresetGeometry presetGeometry2 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Line };
            A.AdjustValueList adjustValueList2 = new A.AdjustValueList();

            presetGeometry2.Append(adjustValueList2);
            A.Outline outline2 = new A.Outline() { Width = 57150 };

            shapeProperties2.Append(transform2D2);
            shapeProperties2.Append(presetGeometry2);
            shapeProperties2.Append(outline2);

            ShapeStyle shapeStyle2 = new ShapeStyle();

            A.LineReference lineReference2 = new A.LineReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference2.Append(schemeColor14);

            A.FillReference fillReference2 = new A.FillReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference2.Append(schemeColor15);

            A.EffectReference effectReference2 = new A.EffectReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference2.Append(schemeColor16);

            A.FontReference fontReference2 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor17 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            fontReference2.Append(schemeColor17);

            shapeStyle2.Append(lineReference2);
            shapeStyle2.Append(fillReference2);
            shapeStyle2.Append(effectReference2);
            shapeStyle2.Append(fontReference2);

            connectionShape2.Append(nonVisualConnectionShapeProperties2);
            connectionShape2.Append(shapeProperties2);
            connectionShape2.Append(shapeStyle2);

            ConnectionShape connectionShape3 = new ConnectionShape();

            NonVisualConnectionShapeProperties nonVisualConnectionShapeProperties3 = new NonVisualConnectionShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties5 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "직선 연결선 8" };
            NonVisualConnectorShapeDrawingProperties nonVisualConnectorShapeDrawingProperties3 = new NonVisualConnectorShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties5 = new ApplicationNonVisualDrawingProperties();

            nonVisualConnectionShapeProperties3.Append(nonVisualDrawingProperties5);
            nonVisualConnectionShapeProperties3.Append(nonVisualConnectorShapeDrawingProperties3);
            nonVisualConnectionShapeProperties3.Append(applicationNonVisualDrawingProperties5);

            ShapeProperties shapeProperties3 = new ShapeProperties();

            A.Transform2D transform2D3 = new A.Transform2D();
            A.Offset offset5 = new A.Offset() { X = 2777706L, Y = 5158595L };
            A.Extents extents5 = new A.Extents() { Cx = 3269412L, Cy = 983411L };

            transform2D3.Append(offset5);
            transform2D3.Append(extents5);

            A.PresetGeometry presetGeometry3 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Line };
            A.AdjustValueList adjustValueList3 = new A.AdjustValueList();

            presetGeometry3.Append(adjustValueList3);
            A.Outline outline3 = new A.Outline() { Width = 57150 };

            shapeProperties3.Append(transform2D3);
            shapeProperties3.Append(presetGeometry3);
            shapeProperties3.Append(outline3);

            ShapeStyle shapeStyle3 = new ShapeStyle();

            A.LineReference lineReference3 = new A.LineReference() { Index = (UInt32Value)1U };
            A.SchemeColor schemeColor18 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            lineReference3.Append(schemeColor18);

            A.FillReference fillReference3 = new A.FillReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor19 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            fillReference3.Append(schemeColor19);

            A.EffectReference effectReference3 = new A.EffectReference() { Index = (UInt32Value)0U };
            A.SchemeColor schemeColor20 = new A.SchemeColor() { Val = A.SchemeColorValues.Accent1 };

            effectReference3.Append(schemeColor20);

            A.FontReference fontReference3 = new A.FontReference() { Index = A.FontCollectionIndexValues.Minor };
            A.SchemeColor schemeColor21 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            fontReference3.Append(schemeColor21);

            shapeStyle3.Append(lineReference3);
            shapeStyle3.Append(fillReference3);
            shapeStyle3.Append(effectReference3);
            shapeStyle3.Append(fontReference3);

            connectionShape3.Append(nonVisualConnectionShapeProperties3);
            connectionShape3.Append(shapeProperties3);
            connectionShape3.Append(shapeStyle3);

            groupShape1.Append(nonVisualGroupShapeProperties2);
            groupShape1.Append(groupShapeProperties2);
            groupShape1.Append(connectionShape1);
            groupShape1.Append(connectionShape2);
            groupShape1.Append(connectionShape3);

            shapeTree1.Append(nonVisualGroupShapeProperties1);
            shapeTree1.Append(groupShapeProperties1);
            shapeTree1.Append(groupShape1);

            CommonSlideDataExtensionList commonSlideDataExtensionList1 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension1 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId1 = new P14.CreationId() { Val = (UInt32Value)3223529696U };
            creationId1.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension1.Append(creationId1);

            commonSlideDataExtensionList1.Append(commonSlideDataExtension1);

            commonSlideData1.Append(shapeTree1);
            commonSlideData1.Append(commonSlideDataExtensionList1);

            ColorMapOverride colorMapOverride1 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping1 = new A.MasterColorMapping();

            colorMapOverride1.Append(masterColorMapping1);

            Timing timing1 = new Timing();

            TimeNodeList timeNodeList1 = new TimeNodeList();

            ParallelTimeNode parallelTimeNode1 = new ParallelTimeNode();
            CommonTimeNode commonTimeNode1 = new CommonTimeNode() { Id = (UInt32Value)1U, Duration = "indefinite", Restart = TimeNodeRestartValues.Never, NodeType = TimeNodeValues.TmingRoot };

            parallelTimeNode1.Append(commonTimeNode1);

            timeNodeList1.Append(parallelTimeNode1);

            timing1.Append(timeNodeList1);

            slide1.Append(commonSlideData1);
            slide1.Append(colorMapOverride1);
            slide1.Append(timing1);

            slidePart1.Slide = slide1;
        }

        // Generates content of slideLayoutPart1.
        private void GenerateSlideLayoutPart1Content(SlideLayoutPart slideLayoutPart1)
        {
            SlideLayout slideLayout1 = new SlideLayout() { Type = SlideLayoutValues.Title, Preserve = true };
            slideLayout1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData2 = new CommonSlideData() { Name = "제목 슬라이드" };

            ShapeTree shapeTree2 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties3 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties6 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties3 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties6 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties3.Append(nonVisualDrawingProperties6);
            nonVisualGroupShapeProperties3.Append(nonVisualGroupShapeDrawingProperties3);
            nonVisualGroupShapeProperties3.Append(applicationNonVisualDrawingProperties6);

            GroupShapeProperties groupShapeProperties3 = new GroupShapeProperties();

            A.TransformGroup transformGroup3 = new A.TransformGroup();
            A.Offset offset6 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents6 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset3 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents3 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup3.Append(offset6);
            transformGroup3.Append(extents6);
            transformGroup3.Append(childOffset3);
            transformGroup3.Append(childExtents3);

            groupShapeProperties3.Append(transformGroup3);

            Shape shape1 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties1 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties7 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties1 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks1 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties1.Append(shapeLocks1);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties7 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape1 = new PlaceholderShape() { Type = PlaceholderValues.CenteredTitle };

            applicationNonVisualDrawingProperties7.Append(placeholderShape1);

            nonVisualShapeProperties1.Append(nonVisualDrawingProperties7);
            nonVisualShapeProperties1.Append(nonVisualShapeDrawingProperties1);
            nonVisualShapeProperties1.Append(applicationNonVisualDrawingProperties7);

            ShapeProperties shapeProperties4 = new ShapeProperties();

            A.Transform2D transform2D4 = new A.Transform2D();
            A.Offset offset7 = new A.Offset() { X = 685800L, Y = 1122363L };
            A.Extents extents7 = new A.Extents() { Cx = 7772400L, Cy = 2387600L };

            transform2D4.Append(offset7);
            transform2D4.Append(extents7);

            shapeProperties4.Append(transform2D4);

            TextBody textBody1 = new TextBody();
            A.BodyProperties bodyProperties1 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle1 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties2 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };
            A.DefaultRunProperties defaultRunProperties11 = new A.DefaultRunProperties() { FontSize = 6000 };

            level1ParagraphProperties2.Append(defaultRunProperties11);

            listStyle1.Append(level1ParagraphProperties2);

            A.Paragraph paragraph1 = new A.Paragraph();

            A.Run run1 = new A.Run();

            A.RunProperties runProperties1 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties1.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text1 = new A.Text();
            text1.Text = "마스터 제목 스타일 편집";

            run1.Append(runProperties1);
            run1.Append(text1);
            A.EndParagraphRunProperties endParagraphRunProperties1 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph1.Append(run1);
            paragraph1.Append(endParagraphRunProperties1);

            textBody1.Append(bodyProperties1);
            textBody1.Append(listStyle1);
            textBody1.Append(paragraph1);

            shape1.Append(nonVisualShapeProperties1);
            shape1.Append(shapeProperties4);
            shape1.Append(textBody1);

            Shape shape2 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties2 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties8 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Subtitle 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties2 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks2 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties2.Append(shapeLocks2);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties8 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape2 = new PlaceholderShape() { Type = PlaceholderValues.SubTitle, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties8.Append(placeholderShape2);

            nonVisualShapeProperties2.Append(nonVisualDrawingProperties8);
            nonVisualShapeProperties2.Append(nonVisualShapeDrawingProperties2);
            nonVisualShapeProperties2.Append(applicationNonVisualDrawingProperties8);

            ShapeProperties shapeProperties5 = new ShapeProperties();

            A.Transform2D transform2D5 = new A.Transform2D();
            A.Offset offset8 = new A.Offset() { X = 1143000L, Y = 3602038L };
            A.Extents extents8 = new A.Extents() { Cx = 6858000L, Cy = 1655762L };

            transform2D5.Append(offset8);
            transform2D5.Append(extents8);

            shapeProperties5.Append(transform2D5);

            TextBody textBody2 = new TextBody();
            A.BodyProperties bodyProperties2 = new A.BodyProperties();

            A.ListStyle listStyle2 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties3 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet1 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties12 = new A.DefaultRunProperties() { FontSize = 2400 };

            level1ParagraphProperties3.Append(noBullet1);
            level1ParagraphProperties3.Append(defaultRunProperties12);

            A.Level2ParagraphProperties level2ParagraphProperties2 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet2 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties13 = new A.DefaultRunProperties() { FontSize = 2000 };

            level2ParagraphProperties2.Append(noBullet2);
            level2ParagraphProperties2.Append(defaultRunProperties13);

            A.Level3ParagraphProperties level3ParagraphProperties2 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet3 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties14 = new A.DefaultRunProperties() { FontSize = 1800 };

            level3ParagraphProperties2.Append(noBullet3);
            level3ParagraphProperties2.Append(defaultRunProperties14);

            A.Level4ParagraphProperties level4ParagraphProperties2 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet4 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties15 = new A.DefaultRunProperties() { FontSize = 1600 };

            level4ParagraphProperties2.Append(noBullet4);
            level4ParagraphProperties2.Append(defaultRunProperties15);

            A.Level5ParagraphProperties level5ParagraphProperties2 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet5 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties16 = new A.DefaultRunProperties() { FontSize = 1600 };

            level5ParagraphProperties2.Append(noBullet5);
            level5ParagraphProperties2.Append(defaultRunProperties16);

            A.Level6ParagraphProperties level6ParagraphProperties2 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet6 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties17 = new A.DefaultRunProperties() { FontSize = 1600 };

            level6ParagraphProperties2.Append(noBullet6);
            level6ParagraphProperties2.Append(defaultRunProperties17);

            A.Level7ParagraphProperties level7ParagraphProperties2 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet7 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties18 = new A.DefaultRunProperties() { FontSize = 1600 };

            level7ParagraphProperties2.Append(noBullet7);
            level7ParagraphProperties2.Append(defaultRunProperties18);

            A.Level8ParagraphProperties level8ParagraphProperties2 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet8 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties19 = new A.DefaultRunProperties() { FontSize = 1600 };

            level8ParagraphProperties2.Append(noBullet8);
            level8ParagraphProperties2.Append(defaultRunProperties19);

            A.Level9ParagraphProperties level9ParagraphProperties2 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0, Alignment = A.TextAlignmentTypeValues.Center };
            A.NoBullet noBullet9 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties20 = new A.DefaultRunProperties() { FontSize = 1600 };

            level9ParagraphProperties2.Append(noBullet9);
            level9ParagraphProperties2.Append(defaultRunProperties20);

            listStyle2.Append(level1ParagraphProperties3);
            listStyle2.Append(level2ParagraphProperties2);
            listStyle2.Append(level3ParagraphProperties2);
            listStyle2.Append(level4ParagraphProperties2);
            listStyle2.Append(level5ParagraphProperties2);
            listStyle2.Append(level6ParagraphProperties2);
            listStyle2.Append(level7ParagraphProperties2);
            listStyle2.Append(level8ParagraphProperties2);
            listStyle2.Append(level9ParagraphProperties2);

            A.Paragraph paragraph2 = new A.Paragraph();

            A.Run run2 = new A.Run();

            A.RunProperties runProperties2 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties2.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text2 = new A.Text();
            text2.Text = "마스터 부제목 스타일 편집";

            run2.Append(runProperties2);
            run2.Append(text2);
            A.EndParagraphRunProperties endParagraphRunProperties2 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph2.Append(run2);
            paragraph2.Append(endParagraphRunProperties2);

            textBody2.Append(bodyProperties2);
            textBody2.Append(listStyle2);
            textBody2.Append(paragraph2);

            shape2.Append(nonVisualShapeProperties2);
            shape2.Append(shapeProperties5);
            shape2.Append(textBody2);

            Shape shape3 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties3 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties9 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties3 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks3 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties3.Append(shapeLocks3);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties9 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape3 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties9.Append(placeholderShape3);

            nonVisualShapeProperties3.Append(nonVisualDrawingProperties9);
            nonVisualShapeProperties3.Append(nonVisualShapeDrawingProperties3);
            nonVisualShapeProperties3.Append(applicationNonVisualDrawingProperties9);
            ShapeProperties shapeProperties6 = new ShapeProperties();

            TextBody textBody3 = new TextBody();
            A.BodyProperties bodyProperties3 = new A.BodyProperties();
            A.ListStyle listStyle3 = new A.ListStyle();

            A.Paragraph paragraph3 = new A.Paragraph();

            A.Field field1 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties3 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties3.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text3 = new A.Text();
            text3.Text = "2015-03-31";

            field1.Append(runProperties3);
            field1.Append(text3);
            A.EndParagraphRunProperties endParagraphRunProperties3 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph3.Append(field1);
            paragraph3.Append(endParagraphRunProperties3);

            textBody3.Append(bodyProperties3);
            textBody3.Append(listStyle3);
            textBody3.Append(paragraph3);

            shape3.Append(nonVisualShapeProperties3);
            shape3.Append(shapeProperties6);
            shape3.Append(textBody3);

            Shape shape4 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties4 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties10 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties4 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks4 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties4.Append(shapeLocks4);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties10 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape4 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties10.Append(placeholderShape4);

            nonVisualShapeProperties4.Append(nonVisualDrawingProperties10);
            nonVisualShapeProperties4.Append(nonVisualShapeDrawingProperties4);
            nonVisualShapeProperties4.Append(applicationNonVisualDrawingProperties10);
            ShapeProperties shapeProperties7 = new ShapeProperties();

            TextBody textBody4 = new TextBody();
            A.BodyProperties bodyProperties4 = new A.BodyProperties();
            A.ListStyle listStyle4 = new A.ListStyle();

            A.Paragraph paragraph4 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties4 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph4.Append(endParagraphRunProperties4);

            textBody4.Append(bodyProperties4);
            textBody4.Append(listStyle4);
            textBody4.Append(paragraph4);

            shape4.Append(nonVisualShapeProperties4);
            shape4.Append(shapeProperties7);
            shape4.Append(textBody4);

            Shape shape5 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties5 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties11 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties5 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks5 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties5.Append(shapeLocks5);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties11 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape5 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties11.Append(placeholderShape5);

            nonVisualShapeProperties5.Append(nonVisualDrawingProperties11);
            nonVisualShapeProperties5.Append(nonVisualShapeDrawingProperties5);
            nonVisualShapeProperties5.Append(applicationNonVisualDrawingProperties11);
            ShapeProperties shapeProperties8 = new ShapeProperties();

            TextBody textBody5 = new TextBody();
            A.BodyProperties bodyProperties5 = new A.BodyProperties();
            A.ListStyle listStyle5 = new A.ListStyle();

            A.Paragraph paragraph5 = new A.Paragraph();

            A.Field field2 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties4 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties4.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text4 = new A.Text();
            text4.Text = "?#?";

            field2.Append(runProperties4);
            field2.Append(text4);
            A.EndParagraphRunProperties endParagraphRunProperties5 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph5.Append(field2);
            paragraph5.Append(endParagraphRunProperties5);

            textBody5.Append(bodyProperties5);
            textBody5.Append(listStyle5);
            textBody5.Append(paragraph5);

            shape5.Append(nonVisualShapeProperties5);
            shape5.Append(shapeProperties8);
            shape5.Append(textBody5);

            shapeTree2.Append(nonVisualGroupShapeProperties3);
            shapeTree2.Append(groupShapeProperties3);
            shapeTree2.Append(shape1);
            shapeTree2.Append(shape2);
            shapeTree2.Append(shape3);
            shapeTree2.Append(shape4);
            shapeTree2.Append(shape5);

            CommonSlideDataExtensionList commonSlideDataExtensionList2 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension2 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId2 = new P14.CreationId() { Val = (UInt32Value)2822795843U };
            creationId2.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension2.Append(creationId2);

            commonSlideDataExtensionList2.Append(commonSlideDataExtension2);

            commonSlideData2.Append(shapeTree2);
            commonSlideData2.Append(commonSlideDataExtensionList2);

            ColorMapOverride colorMapOverride2 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping2 = new A.MasterColorMapping();

            colorMapOverride2.Append(masterColorMapping2);

            slideLayout1.Append(commonSlideData2);
            slideLayout1.Append(colorMapOverride2);

            slideLayoutPart1.SlideLayout = slideLayout1;
        }

        // Generates content of slideMasterPart1.
        private void GenerateSlideMasterPart1Content(SlideMasterPart slideMasterPart1)
        {
            SlideMaster slideMaster1 = new SlideMaster();
            slideMaster1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideMaster1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideMaster1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData3 = new CommonSlideData();

            Background background1 = new Background();

            BackgroundStyleReference backgroundStyleReference1 = new BackgroundStyleReference() { Index = (UInt32Value)1001U };
            A.SchemeColor schemeColor22 = new A.SchemeColor() { Val = A.SchemeColorValues.Background1 };

            backgroundStyleReference1.Append(schemeColor22);

            background1.Append(backgroundStyleReference1);

            ShapeTree shapeTree3 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties4 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties12 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties4 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties12 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties4.Append(nonVisualDrawingProperties12);
            nonVisualGroupShapeProperties4.Append(nonVisualGroupShapeDrawingProperties4);
            nonVisualGroupShapeProperties4.Append(applicationNonVisualDrawingProperties12);

            GroupShapeProperties groupShapeProperties4 = new GroupShapeProperties();

            A.TransformGroup transformGroup4 = new A.TransformGroup();
            A.Offset offset9 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents9 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset4 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents4 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup4.Append(offset9);
            transformGroup4.Append(extents9);
            transformGroup4.Append(childOffset4);
            transformGroup4.Append(childExtents4);

            groupShapeProperties4.Append(transformGroup4);

            Shape shape6 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties6 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties13 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties6 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks6 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties6.Append(shapeLocks6);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties13 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape6 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties13.Append(placeholderShape6);

            nonVisualShapeProperties6.Append(nonVisualDrawingProperties13);
            nonVisualShapeProperties6.Append(nonVisualShapeDrawingProperties6);
            nonVisualShapeProperties6.Append(applicationNonVisualDrawingProperties13);

            ShapeProperties shapeProperties9 = new ShapeProperties();

            A.Transform2D transform2D6 = new A.Transform2D();
            A.Offset offset10 = new A.Offset() { X = 628650L, Y = 365126L };
            A.Extents extents10 = new A.Extents() { Cx = 7886700L, Cy = 1325563L };

            transform2D6.Append(offset10);
            transform2D6.Append(extents10);

            A.PresetGeometry presetGeometry4 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList4 = new A.AdjustValueList();

            presetGeometry4.Append(adjustValueList4);

            shapeProperties9.Append(transform2D6);
            shapeProperties9.Append(presetGeometry4);

            TextBody textBody6 = new TextBody();

            A.BodyProperties bodyProperties6 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };
            A.NormalAutoFit normalAutoFit1 = new A.NormalAutoFit();

            bodyProperties6.Append(normalAutoFit1);
            A.ListStyle listStyle6 = new A.ListStyle();

            A.Paragraph paragraph6 = new A.Paragraph();

            A.Run run3 = new A.Run();

            A.RunProperties runProperties5 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties5.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text5 = new A.Text();
            text5.Text = "마스터 제목 스타일 편집";

            run3.Append(runProperties5);
            run3.Append(text5);
            A.EndParagraphRunProperties endParagraphRunProperties6 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph6.Append(run3);
            paragraph6.Append(endParagraphRunProperties6);

            textBody6.Append(bodyProperties6);
            textBody6.Append(listStyle6);
            textBody6.Append(paragraph6);

            shape6.Append(nonVisualShapeProperties6);
            shape6.Append(shapeProperties9);
            shape6.Append(textBody6);

            Shape shape7 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties7 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties14 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties7 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks7 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties7.Append(shapeLocks7);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties14 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape7 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties14.Append(placeholderShape7);

            nonVisualShapeProperties7.Append(nonVisualDrawingProperties14);
            nonVisualShapeProperties7.Append(nonVisualShapeDrawingProperties7);
            nonVisualShapeProperties7.Append(applicationNonVisualDrawingProperties14);

            ShapeProperties shapeProperties10 = new ShapeProperties();

            A.Transform2D transform2D7 = new A.Transform2D();
            A.Offset offset11 = new A.Offset() { X = 628650L, Y = 1825625L };
            A.Extents extents11 = new A.Extents() { Cx = 7886700L, Cy = 4351338L };

            transform2D7.Append(offset11);
            transform2D7.Append(extents11);

            A.PresetGeometry presetGeometry5 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList5 = new A.AdjustValueList();

            presetGeometry5.Append(adjustValueList5);

            shapeProperties10.Append(transform2D7);
            shapeProperties10.Append(presetGeometry5);

            TextBody textBody7 = new TextBody();

            A.BodyProperties bodyProperties7 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false };
            A.NormalAutoFit normalAutoFit2 = new A.NormalAutoFit();

            bodyProperties7.Append(normalAutoFit2);
            A.ListStyle listStyle7 = new A.ListStyle();

            A.Paragraph paragraph7 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties1 = new A.ParagraphProperties() { Level = 0 };

            A.Run run4 = new A.Run();

            A.RunProperties runProperties6 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties6.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text6 = new A.Text();
            text6.Text = "마스터 텍스트 스타일을 편집합니다";

            run4.Append(runProperties6);
            run4.Append(text6);

            paragraph7.Append(paragraphProperties1);
            paragraph7.Append(run4);

            A.Paragraph paragraph8 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties2 = new A.ParagraphProperties() { Level = 1 };

            A.Run run5 = new A.Run();

            A.RunProperties runProperties7 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties7.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text7 = new A.Text();
            text7.Text = "둘째 수준";

            run5.Append(runProperties7);
            run5.Append(text7);

            paragraph8.Append(paragraphProperties2);
            paragraph8.Append(run5);

            A.Paragraph paragraph9 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties3 = new A.ParagraphProperties() { Level = 2 };

            A.Run run6 = new A.Run();

            A.RunProperties runProperties8 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties8.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text8 = new A.Text();
            text8.Text = "셋째 수준";

            run6.Append(runProperties8);
            run6.Append(text8);

            paragraph9.Append(paragraphProperties3);
            paragraph9.Append(run6);

            A.Paragraph paragraph10 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties4 = new A.ParagraphProperties() { Level = 3 };

            A.Run run7 = new A.Run();

            A.RunProperties runProperties9 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties9.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text9 = new A.Text();
            text9.Text = "넷째 수준";

            run7.Append(runProperties9);
            run7.Append(text9);

            paragraph10.Append(paragraphProperties4);
            paragraph10.Append(run7);

            A.Paragraph paragraph11 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties5 = new A.ParagraphProperties() { Level = 4 };

            A.Run run8 = new A.Run();

            A.RunProperties runProperties10 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties10.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text10 = new A.Text();
            text10.Text = "다섯째 수준";

            run8.Append(runProperties10);
            run8.Append(text10);
            A.EndParagraphRunProperties endParagraphRunProperties7 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph11.Append(paragraphProperties5);
            paragraph11.Append(run8);
            paragraph11.Append(endParagraphRunProperties7);

            textBody7.Append(bodyProperties7);
            textBody7.Append(listStyle7);
            textBody7.Append(paragraph7);
            textBody7.Append(paragraph8);
            textBody7.Append(paragraph9);
            textBody7.Append(paragraph10);
            textBody7.Append(paragraph11);

            shape7.Append(nonVisualShapeProperties7);
            shape7.Append(shapeProperties10);
            shape7.Append(textBody7);

            Shape shape8 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties8 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties15 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties8 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks8 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties8.Append(shapeLocks8);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties15 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape8 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties15.Append(placeholderShape8);

            nonVisualShapeProperties8.Append(nonVisualDrawingProperties15);
            nonVisualShapeProperties8.Append(nonVisualShapeDrawingProperties8);
            nonVisualShapeProperties8.Append(applicationNonVisualDrawingProperties15);

            ShapeProperties shapeProperties11 = new ShapeProperties();

            A.Transform2D transform2D8 = new A.Transform2D();
            A.Offset offset12 = new A.Offset() { X = 628650L, Y = 6356351L };
            A.Extents extents12 = new A.Extents() { Cx = 2057400L, Cy = 365125L };

            transform2D8.Append(offset12);
            transform2D8.Append(extents12);

            A.PresetGeometry presetGeometry6 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList6 = new A.AdjustValueList();

            presetGeometry6.Append(adjustValueList6);

            shapeProperties11.Append(transform2D8);
            shapeProperties11.Append(presetGeometry6);

            TextBody textBody8 = new TextBody();
            A.BodyProperties bodyProperties8 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle8 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties4 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left };

            A.DefaultRunProperties defaultRunProperties21 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill10 = new A.SolidFill();

            A.SchemeColor schemeColor23 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint1 = new A.Tint() { Val = 75000 };

            schemeColor23.Append(tint1);

            solidFill10.Append(schemeColor23);

            defaultRunProperties21.Append(solidFill10);

            level1ParagraphProperties4.Append(defaultRunProperties21);

            listStyle8.Append(level1ParagraphProperties4);

            A.Paragraph paragraph12 = new A.Paragraph();

            A.Field field3 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties11 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties11.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text11 = new A.Text();
            text11.Text = "2015-03-31";

            field3.Append(runProperties11);
            field3.Append(text11);
            A.EndParagraphRunProperties endParagraphRunProperties8 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph12.Append(field3);
            paragraph12.Append(endParagraphRunProperties8);

            textBody8.Append(bodyProperties8);
            textBody8.Append(listStyle8);
            textBody8.Append(paragraph12);

            shape8.Append(nonVisualShapeProperties8);
            shape8.Append(shapeProperties11);
            shape8.Append(textBody8);

            Shape shape9 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties9 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties16 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties9 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks9 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties9.Append(shapeLocks9);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties16 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape9 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties16.Append(placeholderShape9);

            nonVisualShapeProperties9.Append(nonVisualDrawingProperties16);
            nonVisualShapeProperties9.Append(nonVisualShapeDrawingProperties9);
            nonVisualShapeProperties9.Append(applicationNonVisualDrawingProperties16);

            ShapeProperties shapeProperties12 = new ShapeProperties();

            A.Transform2D transform2D9 = new A.Transform2D();
            A.Offset offset13 = new A.Offset() { X = 3028950L, Y = 6356351L };
            A.Extents extents13 = new A.Extents() { Cx = 3086100L, Cy = 365125L };

            transform2D9.Append(offset13);
            transform2D9.Append(extents13);

            A.PresetGeometry presetGeometry7 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList7 = new A.AdjustValueList();

            presetGeometry7.Append(adjustValueList7);

            shapeProperties12.Append(transform2D9);
            shapeProperties12.Append(presetGeometry7);

            TextBody textBody9 = new TextBody();
            A.BodyProperties bodyProperties9 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle9 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties5 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Center };

            A.DefaultRunProperties defaultRunProperties22 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill11 = new A.SolidFill();

            A.SchemeColor schemeColor24 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint2 = new A.Tint() { Val = 75000 };

            schemeColor24.Append(tint2);

            solidFill11.Append(schemeColor24);

            defaultRunProperties22.Append(solidFill11);

            level1ParagraphProperties5.Append(defaultRunProperties22);

            listStyle9.Append(level1ParagraphProperties5);

            A.Paragraph paragraph13 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties9 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph13.Append(endParagraphRunProperties9);

            textBody9.Append(bodyProperties9);
            textBody9.Append(listStyle9);
            textBody9.Append(paragraph13);

            shape9.Append(nonVisualShapeProperties9);
            shape9.Append(shapeProperties12);
            shape9.Append(textBody9);

            Shape shape10 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties10 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties17 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties10 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks10 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties10.Append(shapeLocks10);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties17 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape10 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties17.Append(placeholderShape10);

            nonVisualShapeProperties10.Append(nonVisualDrawingProperties17);
            nonVisualShapeProperties10.Append(nonVisualShapeDrawingProperties10);
            nonVisualShapeProperties10.Append(applicationNonVisualDrawingProperties17);

            ShapeProperties shapeProperties13 = new ShapeProperties();

            A.Transform2D transform2D10 = new A.Transform2D();
            A.Offset offset14 = new A.Offset() { X = 6457950L, Y = 6356351L };
            A.Extents extents14 = new A.Extents() { Cx = 2057400L, Cy = 365125L };

            transform2D10.Append(offset14);
            transform2D10.Append(extents14);

            A.PresetGeometry presetGeometry8 = new A.PresetGeometry() { Preset = A.ShapeTypeValues.Rectangle };
            A.AdjustValueList adjustValueList8 = new A.AdjustValueList();

            presetGeometry8.Append(adjustValueList8);

            shapeProperties13.Append(transform2D10);
            shapeProperties13.Append(presetGeometry8);

            TextBody textBody10 = new TextBody();
            A.BodyProperties bodyProperties10 = new A.BodyProperties() { Vertical = A.TextVerticalValues.Horizontal, LeftInset = 91440, TopInset = 45720, RightInset = 91440, BottomInset = 45720, RightToLeftColumns = false, Anchor = A.TextAnchoringTypeValues.Center };

            A.ListStyle listStyle10 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties6 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Right };

            A.DefaultRunProperties defaultRunProperties23 = new A.DefaultRunProperties() { FontSize = 1200 };

            A.SolidFill solidFill12 = new A.SolidFill();

            A.SchemeColor schemeColor25 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint3 = new A.Tint() { Val = 75000 };

            schemeColor25.Append(tint3);

            solidFill12.Append(schemeColor25);

            defaultRunProperties23.Append(solidFill12);

            level1ParagraphProperties6.Append(defaultRunProperties23);

            listStyle10.Append(level1ParagraphProperties6);

            A.Paragraph paragraph14 = new A.Paragraph();

            A.Field field4 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties12 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties12.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text12 = new A.Text();
            text12.Text = "?#?";

            field4.Append(runProperties12);
            field4.Append(text12);
            A.EndParagraphRunProperties endParagraphRunProperties10 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph14.Append(field4);
            paragraph14.Append(endParagraphRunProperties10);

            textBody10.Append(bodyProperties10);
            textBody10.Append(listStyle10);
            textBody10.Append(paragraph14);

            shape10.Append(nonVisualShapeProperties10);
            shape10.Append(shapeProperties13);
            shape10.Append(textBody10);

            shapeTree3.Append(nonVisualGroupShapeProperties4);
            shapeTree3.Append(groupShapeProperties4);
            shapeTree3.Append(shape6);
            shapeTree3.Append(shape7);
            shapeTree3.Append(shape8);
            shapeTree3.Append(shape9);
            shapeTree3.Append(shape10);

            CommonSlideDataExtensionList commonSlideDataExtensionList3 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension3 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId3 = new P14.CreationId() { Val = (UInt32Value)1820659753U };
            creationId3.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension3.Append(creationId3);

            commonSlideDataExtensionList3.Append(commonSlideDataExtension3);

            commonSlideData3.Append(background1);
            commonSlideData3.Append(shapeTree3);
            commonSlideData3.Append(commonSlideDataExtensionList3);
            ColorMap colorMap1 = new ColorMap() { Background1 = A.ColorSchemeIndexValues.Light1, Text1 = A.ColorSchemeIndexValues.Dark1, Background2 = A.ColorSchemeIndexValues.Light2, Text2 = A.ColorSchemeIndexValues.Dark2, Accent1 = A.ColorSchemeIndexValues.Accent1, Accent2 = A.ColorSchemeIndexValues.Accent2, Accent3 = A.ColorSchemeIndexValues.Accent3, Accent4 = A.ColorSchemeIndexValues.Accent4, Accent5 = A.ColorSchemeIndexValues.Accent5, Accent6 = A.ColorSchemeIndexValues.Accent6, Hyperlink = A.ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = A.ColorSchemeIndexValues.FollowedHyperlink };

            SlideLayoutIdList slideLayoutIdList1 = new SlideLayoutIdList();
            SlideLayoutId slideLayoutId1 = new SlideLayoutId() { Id = (UInt32Value)2147483661U, RelationshipId = "rId1" };
            SlideLayoutId slideLayoutId2 = new SlideLayoutId() { Id = (UInt32Value)2147483662U, RelationshipId = "rId2" };
            SlideLayoutId slideLayoutId3 = new SlideLayoutId() { Id = (UInt32Value)2147483663U, RelationshipId = "rId3" };
            SlideLayoutId slideLayoutId4 = new SlideLayoutId() { Id = (UInt32Value)2147483664U, RelationshipId = "rId4" };
            SlideLayoutId slideLayoutId5 = new SlideLayoutId() { Id = (UInt32Value)2147483665U, RelationshipId = "rId5" };
            SlideLayoutId slideLayoutId6 = new SlideLayoutId() { Id = (UInt32Value)2147483666U, RelationshipId = "rId6" };
            SlideLayoutId slideLayoutId7 = new SlideLayoutId() { Id = (UInt32Value)2147483667U, RelationshipId = "rId7" };
            SlideLayoutId slideLayoutId8 = new SlideLayoutId() { Id = (UInt32Value)2147483668U, RelationshipId = "rId8" };
            SlideLayoutId slideLayoutId9 = new SlideLayoutId() { Id = (UInt32Value)2147483669U, RelationshipId = "rId9" };
            SlideLayoutId slideLayoutId10 = new SlideLayoutId() { Id = (UInt32Value)2147483670U, RelationshipId = "rId10" };
            SlideLayoutId slideLayoutId11 = new SlideLayoutId() { Id = (UInt32Value)2147483671U, RelationshipId = "rId11" };

            slideLayoutIdList1.Append(slideLayoutId1);
            slideLayoutIdList1.Append(slideLayoutId2);
            slideLayoutIdList1.Append(slideLayoutId3);
            slideLayoutIdList1.Append(slideLayoutId4);
            slideLayoutIdList1.Append(slideLayoutId5);
            slideLayoutIdList1.Append(slideLayoutId6);
            slideLayoutIdList1.Append(slideLayoutId7);
            slideLayoutIdList1.Append(slideLayoutId8);
            slideLayoutIdList1.Append(slideLayoutId9);
            slideLayoutIdList1.Append(slideLayoutId10);
            slideLayoutIdList1.Append(slideLayoutId11);

            TextStyles textStyles1 = new TextStyles();

            TitleStyle titleStyle1 = new TitleStyle();

            A.Level1ParagraphProperties level1ParagraphProperties7 = new A.Level1ParagraphProperties() { Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing1 = new A.LineSpacing();
            A.SpacingPercent spacingPercent1 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing1.Append(spacingPercent1);

            A.SpaceBefore spaceBefore1 = new A.SpaceBefore();
            A.SpacingPercent spacingPercent2 = new A.SpacingPercent() { Val = 0 };

            spaceBefore1.Append(spacingPercent2);
            A.NoBullet noBullet10 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties24 = new A.DefaultRunProperties() { FontSize = 4400, Kerning = 1200 };

            A.SolidFill solidFill13 = new A.SolidFill();
            A.SchemeColor schemeColor26 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill13.Append(schemeColor26);
            A.LatinFont latinFont10 = new A.LatinFont() { Typeface = "+mj-lt" };
            A.EastAsianFont eastAsianFont10 = new A.EastAsianFont() { Typeface = "+mj-ea" };
            A.ComplexScriptFont complexScriptFont10 = new A.ComplexScriptFont() { Typeface = "+mj-cs" };

            defaultRunProperties24.Append(solidFill13);
            defaultRunProperties24.Append(latinFont10);
            defaultRunProperties24.Append(eastAsianFont10);
            defaultRunProperties24.Append(complexScriptFont10);

            level1ParagraphProperties7.Append(lineSpacing1);
            level1ParagraphProperties7.Append(spaceBefore1);
            level1ParagraphProperties7.Append(noBullet10);
            level1ParagraphProperties7.Append(defaultRunProperties24);

            titleStyle1.Append(level1ParagraphProperties7);

            BodyStyle bodyStyle1 = new BodyStyle();

            A.Level1ParagraphProperties level1ParagraphProperties8 = new A.Level1ParagraphProperties() { LeftMargin = 228600, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing2 = new A.LineSpacing();
            A.SpacingPercent spacingPercent3 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing2.Append(spacingPercent3);

            A.SpaceBefore spaceBefore2 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints1 = new A.SpacingPoints() { Val = 1000 };

            spaceBefore2.Append(spacingPoints1);
            A.BulletFont bulletFont1 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet1 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties25 = new A.DefaultRunProperties() { FontSize = 2800, Kerning = 1200 };

            A.SolidFill solidFill14 = new A.SolidFill();
            A.SchemeColor schemeColor27 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill14.Append(schemeColor27);
            A.LatinFont latinFont11 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont11 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont11 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties25.Append(solidFill14);
            defaultRunProperties25.Append(latinFont11);
            defaultRunProperties25.Append(eastAsianFont11);
            defaultRunProperties25.Append(complexScriptFont11);

            level1ParagraphProperties8.Append(lineSpacing2);
            level1ParagraphProperties8.Append(spaceBefore2);
            level1ParagraphProperties8.Append(bulletFont1);
            level1ParagraphProperties8.Append(characterBullet1);
            level1ParagraphProperties8.Append(defaultRunProperties25);

            A.Level2ParagraphProperties level2ParagraphProperties3 = new A.Level2ParagraphProperties() { LeftMargin = 685800, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing3 = new A.LineSpacing();
            A.SpacingPercent spacingPercent4 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing3.Append(spacingPercent4);

            A.SpaceBefore spaceBefore3 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints2 = new A.SpacingPoints() { Val = 500 };

            spaceBefore3.Append(spacingPoints2);
            A.BulletFont bulletFont2 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet2 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties26 = new A.DefaultRunProperties() { FontSize = 2400, Kerning = 1200 };

            A.SolidFill solidFill15 = new A.SolidFill();
            A.SchemeColor schemeColor28 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill15.Append(schemeColor28);
            A.LatinFont latinFont12 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont12 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont12 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties26.Append(solidFill15);
            defaultRunProperties26.Append(latinFont12);
            defaultRunProperties26.Append(eastAsianFont12);
            defaultRunProperties26.Append(complexScriptFont12);

            level2ParagraphProperties3.Append(lineSpacing3);
            level2ParagraphProperties3.Append(spaceBefore3);
            level2ParagraphProperties3.Append(bulletFont2);
            level2ParagraphProperties3.Append(characterBullet2);
            level2ParagraphProperties3.Append(defaultRunProperties26);

            A.Level3ParagraphProperties level3ParagraphProperties3 = new A.Level3ParagraphProperties() { LeftMargin = 1143000, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing4 = new A.LineSpacing();
            A.SpacingPercent spacingPercent5 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing4.Append(spacingPercent5);

            A.SpaceBefore spaceBefore4 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints3 = new A.SpacingPoints() { Val = 500 };

            spaceBefore4.Append(spacingPoints3);
            A.BulletFont bulletFont3 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet3 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties27 = new A.DefaultRunProperties() { FontSize = 2000, Kerning = 1200 };

            A.SolidFill solidFill16 = new A.SolidFill();
            A.SchemeColor schemeColor29 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill16.Append(schemeColor29);
            A.LatinFont latinFont13 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont13 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont13 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties27.Append(solidFill16);
            defaultRunProperties27.Append(latinFont13);
            defaultRunProperties27.Append(eastAsianFont13);
            defaultRunProperties27.Append(complexScriptFont13);

            level3ParagraphProperties3.Append(lineSpacing4);
            level3ParagraphProperties3.Append(spaceBefore4);
            level3ParagraphProperties3.Append(bulletFont3);
            level3ParagraphProperties3.Append(characterBullet3);
            level3ParagraphProperties3.Append(defaultRunProperties27);

            A.Level4ParagraphProperties level4ParagraphProperties3 = new A.Level4ParagraphProperties() { LeftMargin = 1600200, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing5 = new A.LineSpacing();
            A.SpacingPercent spacingPercent6 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing5.Append(spacingPercent6);

            A.SpaceBefore spaceBefore5 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints4 = new A.SpacingPoints() { Val = 500 };

            spaceBefore5.Append(spacingPoints4);
            A.BulletFont bulletFont4 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet4 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties28 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill17 = new A.SolidFill();
            A.SchemeColor schemeColor30 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill17.Append(schemeColor30);
            A.LatinFont latinFont14 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont14 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont14 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties28.Append(solidFill17);
            defaultRunProperties28.Append(latinFont14);
            defaultRunProperties28.Append(eastAsianFont14);
            defaultRunProperties28.Append(complexScriptFont14);

            level4ParagraphProperties3.Append(lineSpacing5);
            level4ParagraphProperties3.Append(spaceBefore5);
            level4ParagraphProperties3.Append(bulletFont4);
            level4ParagraphProperties3.Append(characterBullet4);
            level4ParagraphProperties3.Append(defaultRunProperties28);

            A.Level5ParagraphProperties level5ParagraphProperties3 = new A.Level5ParagraphProperties() { LeftMargin = 2057400, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing6 = new A.LineSpacing();
            A.SpacingPercent spacingPercent7 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing6.Append(spacingPercent7);

            A.SpaceBefore spaceBefore6 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints5 = new A.SpacingPoints() { Val = 500 };

            spaceBefore6.Append(spacingPoints5);
            A.BulletFont bulletFont5 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet5 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties29 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill18 = new A.SolidFill();
            A.SchemeColor schemeColor31 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill18.Append(schemeColor31);
            A.LatinFont latinFont15 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont15 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont15 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties29.Append(solidFill18);
            defaultRunProperties29.Append(latinFont15);
            defaultRunProperties29.Append(eastAsianFont15);
            defaultRunProperties29.Append(complexScriptFont15);

            level5ParagraphProperties3.Append(lineSpacing6);
            level5ParagraphProperties3.Append(spaceBefore6);
            level5ParagraphProperties3.Append(bulletFont5);
            level5ParagraphProperties3.Append(characterBullet5);
            level5ParagraphProperties3.Append(defaultRunProperties29);

            A.Level6ParagraphProperties level6ParagraphProperties3 = new A.Level6ParagraphProperties() { LeftMargin = 2514600, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing7 = new A.LineSpacing();
            A.SpacingPercent spacingPercent8 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing7.Append(spacingPercent8);

            A.SpaceBefore spaceBefore7 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints6 = new A.SpacingPoints() { Val = 500 };

            spaceBefore7.Append(spacingPoints6);
            A.BulletFont bulletFont6 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet6 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties30 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill19 = new A.SolidFill();
            A.SchemeColor schemeColor32 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill19.Append(schemeColor32);
            A.LatinFont latinFont16 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont16 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont16 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties30.Append(solidFill19);
            defaultRunProperties30.Append(latinFont16);
            defaultRunProperties30.Append(eastAsianFont16);
            defaultRunProperties30.Append(complexScriptFont16);

            level6ParagraphProperties3.Append(lineSpacing7);
            level6ParagraphProperties3.Append(spaceBefore7);
            level6ParagraphProperties3.Append(bulletFont6);
            level6ParagraphProperties3.Append(characterBullet6);
            level6ParagraphProperties3.Append(defaultRunProperties30);

            A.Level7ParagraphProperties level7ParagraphProperties3 = new A.Level7ParagraphProperties() { LeftMargin = 2971800, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing8 = new A.LineSpacing();
            A.SpacingPercent spacingPercent9 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing8.Append(spacingPercent9);

            A.SpaceBefore spaceBefore8 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints7 = new A.SpacingPoints() { Val = 500 };

            spaceBefore8.Append(spacingPoints7);
            A.BulletFont bulletFont7 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet7 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties31 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill20 = new A.SolidFill();
            A.SchemeColor schemeColor33 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill20.Append(schemeColor33);
            A.LatinFont latinFont17 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont17 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont17 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties31.Append(solidFill20);
            defaultRunProperties31.Append(latinFont17);
            defaultRunProperties31.Append(eastAsianFont17);
            defaultRunProperties31.Append(complexScriptFont17);

            level7ParagraphProperties3.Append(lineSpacing8);
            level7ParagraphProperties3.Append(spaceBefore8);
            level7ParagraphProperties3.Append(bulletFont7);
            level7ParagraphProperties3.Append(characterBullet7);
            level7ParagraphProperties3.Append(defaultRunProperties31);

            A.Level8ParagraphProperties level8ParagraphProperties3 = new A.Level8ParagraphProperties() { LeftMargin = 3429000, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing9 = new A.LineSpacing();
            A.SpacingPercent spacingPercent10 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing9.Append(spacingPercent10);

            A.SpaceBefore spaceBefore9 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints8 = new A.SpacingPoints() { Val = 500 };

            spaceBefore9.Append(spacingPoints8);
            A.BulletFont bulletFont8 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet8 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties32 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill21 = new A.SolidFill();
            A.SchemeColor schemeColor34 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill21.Append(schemeColor34);
            A.LatinFont latinFont18 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont18 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont18 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties32.Append(solidFill21);
            defaultRunProperties32.Append(latinFont18);
            defaultRunProperties32.Append(eastAsianFont18);
            defaultRunProperties32.Append(complexScriptFont18);

            level8ParagraphProperties3.Append(lineSpacing9);
            level8ParagraphProperties3.Append(spaceBefore9);
            level8ParagraphProperties3.Append(bulletFont8);
            level8ParagraphProperties3.Append(characterBullet8);
            level8ParagraphProperties3.Append(defaultRunProperties32);

            A.Level9ParagraphProperties level9ParagraphProperties3 = new A.Level9ParagraphProperties() { LeftMargin = 3886200, Indent = -228600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.LineSpacing lineSpacing10 = new A.LineSpacing();
            A.SpacingPercent spacingPercent11 = new A.SpacingPercent() { Val = 90000 };

            lineSpacing10.Append(spacingPercent11);

            A.SpaceBefore spaceBefore10 = new A.SpaceBefore();
            A.SpacingPoints spacingPoints9 = new A.SpacingPoints() { Val = 500 };

            spaceBefore10.Append(spacingPoints9);
            A.BulletFont bulletFont9 = new A.BulletFont() { Typeface = "Arial", Panose = "020B0604020202020204", PitchFamily = 34, CharacterSet = 0 };
            A.CharacterBullet characterBullet9 = new A.CharacterBullet() { Char = "?" };

            A.DefaultRunProperties defaultRunProperties33 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill22 = new A.SolidFill();
            A.SchemeColor schemeColor35 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill22.Append(schemeColor35);
            A.LatinFont latinFont19 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont19 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont19 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties33.Append(solidFill22);
            defaultRunProperties33.Append(latinFont19);
            defaultRunProperties33.Append(eastAsianFont19);
            defaultRunProperties33.Append(complexScriptFont19);

            level9ParagraphProperties3.Append(lineSpacing10);
            level9ParagraphProperties3.Append(spaceBefore10);
            level9ParagraphProperties3.Append(bulletFont9);
            level9ParagraphProperties3.Append(characterBullet9);
            level9ParagraphProperties3.Append(defaultRunProperties33);

            bodyStyle1.Append(level1ParagraphProperties8);
            bodyStyle1.Append(level2ParagraphProperties3);
            bodyStyle1.Append(level3ParagraphProperties3);
            bodyStyle1.Append(level4ParagraphProperties3);
            bodyStyle1.Append(level5ParagraphProperties3);
            bodyStyle1.Append(level6ParagraphProperties3);
            bodyStyle1.Append(level7ParagraphProperties3);
            bodyStyle1.Append(level8ParagraphProperties3);
            bodyStyle1.Append(level9ParagraphProperties3);

            OtherStyle otherStyle1 = new OtherStyle();

            A.DefaultParagraphProperties defaultParagraphProperties2 = new A.DefaultParagraphProperties();
            A.DefaultRunProperties defaultRunProperties34 = new A.DefaultRunProperties() { Language = "en-US" };

            defaultParagraphProperties2.Append(defaultRunProperties34);

            A.Level1ParagraphProperties level1ParagraphProperties9 = new A.Level1ParagraphProperties() { LeftMargin = 0, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties35 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill23 = new A.SolidFill();
            A.SchemeColor schemeColor36 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill23.Append(schemeColor36);
            A.LatinFont latinFont20 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont20 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont20 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties35.Append(solidFill23);
            defaultRunProperties35.Append(latinFont20);
            defaultRunProperties35.Append(eastAsianFont20);
            defaultRunProperties35.Append(complexScriptFont20);

            level1ParagraphProperties9.Append(defaultRunProperties35);

            A.Level2ParagraphProperties level2ParagraphProperties4 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties36 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill24 = new A.SolidFill();
            A.SchemeColor schemeColor37 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill24.Append(schemeColor37);
            A.LatinFont latinFont21 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont21 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont21 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties36.Append(solidFill24);
            defaultRunProperties36.Append(latinFont21);
            defaultRunProperties36.Append(eastAsianFont21);
            defaultRunProperties36.Append(complexScriptFont21);

            level2ParagraphProperties4.Append(defaultRunProperties36);

            A.Level3ParagraphProperties level3ParagraphProperties4 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties37 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill25 = new A.SolidFill();
            A.SchemeColor schemeColor38 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill25.Append(schemeColor38);
            A.LatinFont latinFont22 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont22 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont22 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties37.Append(solidFill25);
            defaultRunProperties37.Append(latinFont22);
            defaultRunProperties37.Append(eastAsianFont22);
            defaultRunProperties37.Append(complexScriptFont22);

            level3ParagraphProperties4.Append(defaultRunProperties37);

            A.Level4ParagraphProperties level4ParagraphProperties4 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties38 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill26 = new A.SolidFill();
            A.SchemeColor schemeColor39 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill26.Append(schemeColor39);
            A.LatinFont latinFont23 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont23 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont23 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties38.Append(solidFill26);
            defaultRunProperties38.Append(latinFont23);
            defaultRunProperties38.Append(eastAsianFont23);
            defaultRunProperties38.Append(complexScriptFont23);

            level4ParagraphProperties4.Append(defaultRunProperties38);

            A.Level5ParagraphProperties level5ParagraphProperties4 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties39 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill27 = new A.SolidFill();
            A.SchemeColor schemeColor40 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill27.Append(schemeColor40);
            A.LatinFont latinFont24 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont24 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont24 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties39.Append(solidFill27);
            defaultRunProperties39.Append(latinFont24);
            defaultRunProperties39.Append(eastAsianFont24);
            defaultRunProperties39.Append(complexScriptFont24);

            level5ParagraphProperties4.Append(defaultRunProperties39);

            A.Level6ParagraphProperties level6ParagraphProperties4 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties40 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill28 = new A.SolidFill();
            A.SchemeColor schemeColor41 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill28.Append(schemeColor41);
            A.LatinFont latinFont25 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont25 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont25 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties40.Append(solidFill28);
            defaultRunProperties40.Append(latinFont25);
            defaultRunProperties40.Append(eastAsianFont25);
            defaultRunProperties40.Append(complexScriptFont25);

            level6ParagraphProperties4.Append(defaultRunProperties40);

            A.Level7ParagraphProperties level7ParagraphProperties4 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties41 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill29 = new A.SolidFill();
            A.SchemeColor schemeColor42 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill29.Append(schemeColor42);
            A.LatinFont latinFont26 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont26 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont26 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties41.Append(solidFill29);
            defaultRunProperties41.Append(latinFont26);
            defaultRunProperties41.Append(eastAsianFont26);
            defaultRunProperties41.Append(complexScriptFont26);

            level7ParagraphProperties4.Append(defaultRunProperties41);

            A.Level8ParagraphProperties level8ParagraphProperties4 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties42 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill30 = new A.SolidFill();
            A.SchemeColor schemeColor43 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill30.Append(schemeColor43);
            A.LatinFont latinFont27 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont27 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont27 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties42.Append(solidFill30);
            defaultRunProperties42.Append(latinFont27);
            defaultRunProperties42.Append(eastAsianFont27);
            defaultRunProperties42.Append(complexScriptFont27);

            level8ParagraphProperties4.Append(defaultRunProperties42);

            A.Level9ParagraphProperties level9ParagraphProperties4 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Alignment = A.TextAlignmentTypeValues.Left, DefaultTabSize = 914400, RightToLeft = false, EastAsianLineBreak = true, LatinLineBreak = true, Height = true };

            A.DefaultRunProperties defaultRunProperties43 = new A.DefaultRunProperties() { FontSize = 1800, Kerning = 1200 };

            A.SolidFill solidFill31 = new A.SolidFill();
            A.SchemeColor schemeColor44 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill31.Append(schemeColor44);
            A.LatinFont latinFont28 = new A.LatinFont() { Typeface = "+mn-lt" };
            A.EastAsianFont eastAsianFont28 = new A.EastAsianFont() { Typeface = "+mn-ea" };
            A.ComplexScriptFont complexScriptFont28 = new A.ComplexScriptFont() { Typeface = "+mn-cs" };

            defaultRunProperties43.Append(solidFill31);
            defaultRunProperties43.Append(latinFont28);
            defaultRunProperties43.Append(eastAsianFont28);
            defaultRunProperties43.Append(complexScriptFont28);

            level9ParagraphProperties4.Append(defaultRunProperties43);

            otherStyle1.Append(defaultParagraphProperties2);
            otherStyle1.Append(level1ParagraphProperties9);
            otherStyle1.Append(level2ParagraphProperties4);
            otherStyle1.Append(level3ParagraphProperties4);
            otherStyle1.Append(level4ParagraphProperties4);
            otherStyle1.Append(level5ParagraphProperties4);
            otherStyle1.Append(level6ParagraphProperties4);
            otherStyle1.Append(level7ParagraphProperties4);
            otherStyle1.Append(level8ParagraphProperties4);
            otherStyle1.Append(level9ParagraphProperties4);

            textStyles1.Append(titleStyle1);
            textStyles1.Append(bodyStyle1);
            textStyles1.Append(otherStyle1);

            slideMaster1.Append(commonSlideData3);
            slideMaster1.Append(colorMap1);
            slideMaster1.Append(slideLayoutIdList1);
            slideMaster1.Append(textStyles1);

            slideMasterPart1.SlideMaster = slideMaster1;
        }

        // Generates content of slideLayoutPart2.
        private void GenerateSlideLayoutPart2Content(SlideLayoutPart slideLayoutPart2)
        {
            SlideLayout slideLayout2 = new SlideLayout() { Type = SlideLayoutValues.ObjectText, Preserve = true };
            slideLayout2.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout2.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData4 = new CommonSlideData() { Name = "캡션 있는 콘텐츠" };

            ShapeTree shapeTree4 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties5 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties18 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties5 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties18 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties5.Append(nonVisualDrawingProperties18);
            nonVisualGroupShapeProperties5.Append(nonVisualGroupShapeDrawingProperties5);
            nonVisualGroupShapeProperties5.Append(applicationNonVisualDrawingProperties18);

            GroupShapeProperties groupShapeProperties5 = new GroupShapeProperties();

            A.TransformGroup transformGroup5 = new A.TransformGroup();
            A.Offset offset15 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents15 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset5 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents5 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup5.Append(offset15);
            transformGroup5.Append(extents15);
            transformGroup5.Append(childOffset5);
            transformGroup5.Append(childExtents5);

            groupShapeProperties5.Append(transformGroup5);

            Shape shape11 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties11 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties19 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties11 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks11 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties11.Append(shapeLocks11);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties19 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape11 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties19.Append(placeholderShape11);

            nonVisualShapeProperties11.Append(nonVisualDrawingProperties19);
            nonVisualShapeProperties11.Append(nonVisualShapeDrawingProperties11);
            nonVisualShapeProperties11.Append(applicationNonVisualDrawingProperties19);

            ShapeProperties shapeProperties14 = new ShapeProperties();

            A.Transform2D transform2D11 = new A.Transform2D();
            A.Offset offset16 = new A.Offset() { X = 629841L, Y = 457200L };
            A.Extents extents16 = new A.Extents() { Cx = 2949178L, Cy = 1600200L };

            transform2D11.Append(offset16);
            transform2D11.Append(extents16);

            shapeProperties14.Append(transform2D11);

            TextBody textBody11 = new TextBody();
            A.BodyProperties bodyProperties11 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle11 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties10 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties44 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties10.Append(defaultRunProperties44);

            listStyle11.Append(level1ParagraphProperties10);

            A.Paragraph paragraph15 = new A.Paragraph();

            A.Run run9 = new A.Run();

            A.RunProperties runProperties13 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties13.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text13 = new A.Text();
            text13.Text = "마스터 제목 스타일 편집";

            run9.Append(runProperties13);
            run9.Append(text13);
            A.EndParagraphRunProperties endParagraphRunProperties11 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph15.Append(run9);
            paragraph15.Append(endParagraphRunProperties11);

            textBody11.Append(bodyProperties11);
            textBody11.Append(listStyle11);
            textBody11.Append(paragraph15);

            shape11.Append(nonVisualShapeProperties11);
            shape11.Append(shapeProperties14);
            shape11.Append(textBody11);

            Shape shape12 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties12 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties20 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties12 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks12 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties12.Append(shapeLocks12);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties20 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape12 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties20.Append(placeholderShape12);

            nonVisualShapeProperties12.Append(nonVisualDrawingProperties20);
            nonVisualShapeProperties12.Append(nonVisualShapeDrawingProperties12);
            nonVisualShapeProperties12.Append(applicationNonVisualDrawingProperties20);

            ShapeProperties shapeProperties15 = new ShapeProperties();

            A.Transform2D transform2D12 = new A.Transform2D();
            A.Offset offset17 = new A.Offset() { X = 3887391L, Y = 987426L };
            A.Extents extents17 = new A.Extents() { Cx = 4629150L, Cy = 4873625L };

            transform2D12.Append(offset17);
            transform2D12.Append(extents17);

            shapeProperties15.Append(transform2D12);

            TextBody textBody12 = new TextBody();
            A.BodyProperties bodyProperties12 = new A.BodyProperties();

            A.ListStyle listStyle12 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties11 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties45 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties11.Append(defaultRunProperties45);

            A.Level2ParagraphProperties level2ParagraphProperties5 = new A.Level2ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties46 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties5.Append(defaultRunProperties46);

            A.Level3ParagraphProperties level3ParagraphProperties5 = new A.Level3ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties47 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties5.Append(defaultRunProperties47);

            A.Level4ParagraphProperties level4ParagraphProperties5 = new A.Level4ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties48 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties5.Append(defaultRunProperties48);

            A.Level5ParagraphProperties level5ParagraphProperties5 = new A.Level5ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties49 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties5.Append(defaultRunProperties49);

            A.Level6ParagraphProperties level6ParagraphProperties5 = new A.Level6ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties50 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties5.Append(defaultRunProperties50);

            A.Level7ParagraphProperties level7ParagraphProperties5 = new A.Level7ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties51 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties5.Append(defaultRunProperties51);

            A.Level8ParagraphProperties level8ParagraphProperties5 = new A.Level8ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties52 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties5.Append(defaultRunProperties52);

            A.Level9ParagraphProperties level9ParagraphProperties5 = new A.Level9ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties53 = new A.DefaultRunProperties() { FontSize = 2000 };

            level9ParagraphProperties5.Append(defaultRunProperties53);

            listStyle12.Append(level1ParagraphProperties11);
            listStyle12.Append(level2ParagraphProperties5);
            listStyle12.Append(level3ParagraphProperties5);
            listStyle12.Append(level4ParagraphProperties5);
            listStyle12.Append(level5ParagraphProperties5);
            listStyle12.Append(level6ParagraphProperties5);
            listStyle12.Append(level7ParagraphProperties5);
            listStyle12.Append(level8ParagraphProperties5);
            listStyle12.Append(level9ParagraphProperties5);

            A.Paragraph paragraph16 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties6 = new A.ParagraphProperties() { Level = 0 };

            A.Run run10 = new A.Run();

            A.RunProperties runProperties14 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties14.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text14 = new A.Text();
            text14.Text = "마스터 텍스트 스타일을 편집합니다";

            run10.Append(runProperties14);
            run10.Append(text14);

            paragraph16.Append(paragraphProperties6);
            paragraph16.Append(run10);

            A.Paragraph paragraph17 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties7 = new A.ParagraphProperties() { Level = 1 };

            A.Run run11 = new A.Run();

            A.RunProperties runProperties15 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties15.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text15 = new A.Text();
            text15.Text = "둘째 수준";

            run11.Append(runProperties15);
            run11.Append(text15);

            paragraph17.Append(paragraphProperties7);
            paragraph17.Append(run11);

            A.Paragraph paragraph18 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties8 = new A.ParagraphProperties() { Level = 2 };

            A.Run run12 = new A.Run();

            A.RunProperties runProperties16 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties16.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text16 = new A.Text();
            text16.Text = "셋째 수준";

            run12.Append(runProperties16);
            run12.Append(text16);

            paragraph18.Append(paragraphProperties8);
            paragraph18.Append(run12);

            A.Paragraph paragraph19 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties9 = new A.ParagraphProperties() { Level = 3 };

            A.Run run13 = new A.Run();

            A.RunProperties runProperties17 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties17.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text17 = new A.Text();
            text17.Text = "넷째 수준";

            run13.Append(runProperties17);
            run13.Append(text17);

            paragraph19.Append(paragraphProperties9);
            paragraph19.Append(run13);

            A.Paragraph paragraph20 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties10 = new A.ParagraphProperties() { Level = 4 };

            A.Run run14 = new A.Run();

            A.RunProperties runProperties18 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties18.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text18 = new A.Text();
            text18.Text = "다섯째 수준";

            run14.Append(runProperties18);
            run14.Append(text18);
            A.EndParagraphRunProperties endParagraphRunProperties12 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph20.Append(paragraphProperties10);
            paragraph20.Append(run14);
            paragraph20.Append(endParagraphRunProperties12);

            textBody12.Append(bodyProperties12);
            textBody12.Append(listStyle12);
            textBody12.Append(paragraph16);
            textBody12.Append(paragraph17);
            textBody12.Append(paragraph18);
            textBody12.Append(paragraph19);
            textBody12.Append(paragraph20);

            shape12.Append(nonVisualShapeProperties12);
            shape12.Append(shapeProperties15);
            shape12.Append(textBody12);

            Shape shape13 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties13 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties21 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties13 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks13 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties13.Append(shapeLocks13);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties21 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape13 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties21.Append(placeholderShape13);

            nonVisualShapeProperties13.Append(nonVisualDrawingProperties21);
            nonVisualShapeProperties13.Append(nonVisualShapeDrawingProperties13);
            nonVisualShapeProperties13.Append(applicationNonVisualDrawingProperties21);

            ShapeProperties shapeProperties16 = new ShapeProperties();

            A.Transform2D transform2D13 = new A.Transform2D();
            A.Offset offset18 = new A.Offset() { X = 629841L, Y = 2057400L };
            A.Extents extents18 = new A.Extents() { Cx = 2949178L, Cy = 3811588L };

            transform2D13.Append(offset18);
            transform2D13.Append(extents18);

            shapeProperties16.Append(transform2D13);

            TextBody textBody13 = new TextBody();
            A.BodyProperties bodyProperties13 = new A.BodyProperties();

            A.ListStyle listStyle13 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties12 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet11 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties54 = new A.DefaultRunProperties() { FontSize = 1600 };

            level1ParagraphProperties12.Append(noBullet11);
            level1ParagraphProperties12.Append(defaultRunProperties54);

            A.Level2ParagraphProperties level2ParagraphProperties6 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet12 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties55 = new A.DefaultRunProperties() { FontSize = 1400 };

            level2ParagraphProperties6.Append(noBullet12);
            level2ParagraphProperties6.Append(defaultRunProperties55);

            A.Level3ParagraphProperties level3ParagraphProperties6 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet13 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties56 = new A.DefaultRunProperties() { FontSize = 1200 };

            level3ParagraphProperties6.Append(noBullet13);
            level3ParagraphProperties6.Append(defaultRunProperties56);

            A.Level4ParagraphProperties level4ParagraphProperties6 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet14 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties57 = new A.DefaultRunProperties() { FontSize = 1000 };

            level4ParagraphProperties6.Append(noBullet14);
            level4ParagraphProperties6.Append(defaultRunProperties57);

            A.Level5ParagraphProperties level5ParagraphProperties6 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet15 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties58 = new A.DefaultRunProperties() { FontSize = 1000 };

            level5ParagraphProperties6.Append(noBullet15);
            level5ParagraphProperties6.Append(defaultRunProperties58);

            A.Level6ParagraphProperties level6ParagraphProperties6 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet16 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties59 = new A.DefaultRunProperties() { FontSize = 1000 };

            level6ParagraphProperties6.Append(noBullet16);
            level6ParagraphProperties6.Append(defaultRunProperties59);

            A.Level7ParagraphProperties level7ParagraphProperties6 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet17 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties60 = new A.DefaultRunProperties() { FontSize = 1000 };

            level7ParagraphProperties6.Append(noBullet17);
            level7ParagraphProperties6.Append(defaultRunProperties60);

            A.Level8ParagraphProperties level8ParagraphProperties6 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet18 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties61 = new A.DefaultRunProperties() { FontSize = 1000 };

            level8ParagraphProperties6.Append(noBullet18);
            level8ParagraphProperties6.Append(defaultRunProperties61);

            A.Level9ParagraphProperties level9ParagraphProperties6 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet19 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties62 = new A.DefaultRunProperties() { FontSize = 1000 };

            level9ParagraphProperties6.Append(noBullet19);
            level9ParagraphProperties6.Append(defaultRunProperties62);

            listStyle13.Append(level1ParagraphProperties12);
            listStyle13.Append(level2ParagraphProperties6);
            listStyle13.Append(level3ParagraphProperties6);
            listStyle13.Append(level4ParagraphProperties6);
            listStyle13.Append(level5ParagraphProperties6);
            listStyle13.Append(level6ParagraphProperties6);
            listStyle13.Append(level7ParagraphProperties6);
            listStyle13.Append(level8ParagraphProperties6);
            listStyle13.Append(level9ParagraphProperties6);

            A.Paragraph paragraph21 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties11 = new A.ParagraphProperties() { Level = 0 };

            A.Run run15 = new A.Run();

            A.RunProperties runProperties19 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties19.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text19 = new A.Text();
            text19.Text = "마스터 텍스트 스타일을 편집합니다";

            run15.Append(runProperties19);
            run15.Append(text19);

            paragraph21.Append(paragraphProperties11);
            paragraph21.Append(run15);

            textBody13.Append(bodyProperties13);
            textBody13.Append(listStyle13);
            textBody13.Append(paragraph21);

            shape13.Append(nonVisualShapeProperties13);
            shape13.Append(shapeProperties16);
            shape13.Append(textBody13);

            Shape shape14 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties14 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties22 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties14 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks14 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties14.Append(shapeLocks14);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties22 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape14 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties22.Append(placeholderShape14);

            nonVisualShapeProperties14.Append(nonVisualDrawingProperties22);
            nonVisualShapeProperties14.Append(nonVisualShapeDrawingProperties14);
            nonVisualShapeProperties14.Append(applicationNonVisualDrawingProperties22);
            ShapeProperties shapeProperties17 = new ShapeProperties();

            TextBody textBody14 = new TextBody();
            A.BodyProperties bodyProperties14 = new A.BodyProperties();
            A.ListStyle listStyle14 = new A.ListStyle();

            A.Paragraph paragraph22 = new A.Paragraph();

            A.Field field5 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties20 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties20.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text20 = new A.Text();
            text20.Text = "2015-03-31";

            field5.Append(runProperties20);
            field5.Append(text20);
            A.EndParagraphRunProperties endParagraphRunProperties13 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph22.Append(field5);
            paragraph22.Append(endParagraphRunProperties13);

            textBody14.Append(bodyProperties14);
            textBody14.Append(listStyle14);
            textBody14.Append(paragraph22);

            shape14.Append(nonVisualShapeProperties14);
            shape14.Append(shapeProperties17);
            shape14.Append(textBody14);

            Shape shape15 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties15 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties23 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties15 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks15 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties15.Append(shapeLocks15);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties23 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape15 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties23.Append(placeholderShape15);

            nonVisualShapeProperties15.Append(nonVisualDrawingProperties23);
            nonVisualShapeProperties15.Append(nonVisualShapeDrawingProperties15);
            nonVisualShapeProperties15.Append(applicationNonVisualDrawingProperties23);
            ShapeProperties shapeProperties18 = new ShapeProperties();

            TextBody textBody15 = new TextBody();
            A.BodyProperties bodyProperties15 = new A.BodyProperties();
            A.ListStyle listStyle15 = new A.ListStyle();

            A.Paragraph paragraph23 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties14 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph23.Append(endParagraphRunProperties14);

            textBody15.Append(bodyProperties15);
            textBody15.Append(listStyle15);
            textBody15.Append(paragraph23);

            shape15.Append(nonVisualShapeProperties15);
            shape15.Append(shapeProperties18);
            shape15.Append(textBody15);

            Shape shape16 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties16 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties24 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties16 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks16 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties16.Append(shapeLocks16);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties24 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape16 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties24.Append(placeholderShape16);

            nonVisualShapeProperties16.Append(nonVisualDrawingProperties24);
            nonVisualShapeProperties16.Append(nonVisualShapeDrawingProperties16);
            nonVisualShapeProperties16.Append(applicationNonVisualDrawingProperties24);
            ShapeProperties shapeProperties19 = new ShapeProperties();

            TextBody textBody16 = new TextBody();
            A.BodyProperties bodyProperties16 = new A.BodyProperties();
            A.ListStyle listStyle16 = new A.ListStyle();

            A.Paragraph paragraph24 = new A.Paragraph();

            A.Field field6 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties21 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties21.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text21 = new A.Text();
            text21.Text = "?#?";

            field6.Append(runProperties21);
            field6.Append(text21);
            A.EndParagraphRunProperties endParagraphRunProperties15 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph24.Append(field6);
            paragraph24.Append(endParagraphRunProperties15);

            textBody16.Append(bodyProperties16);
            textBody16.Append(listStyle16);
            textBody16.Append(paragraph24);

            shape16.Append(nonVisualShapeProperties16);
            shape16.Append(shapeProperties19);
            shape16.Append(textBody16);

            shapeTree4.Append(nonVisualGroupShapeProperties5);
            shapeTree4.Append(groupShapeProperties5);
            shapeTree4.Append(shape11);
            shapeTree4.Append(shape12);
            shapeTree4.Append(shape13);
            shapeTree4.Append(shape14);
            shapeTree4.Append(shape15);
            shapeTree4.Append(shape16);

            CommonSlideDataExtensionList commonSlideDataExtensionList4 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension4 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId4 = new P14.CreationId() { Val = (UInt32Value)2842968272U };
            creationId4.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension4.Append(creationId4);

            commonSlideDataExtensionList4.Append(commonSlideDataExtension4);

            commonSlideData4.Append(shapeTree4);
            commonSlideData4.Append(commonSlideDataExtensionList4);

            ColorMapOverride colorMapOverride3 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping3 = new A.MasterColorMapping();

            colorMapOverride3.Append(masterColorMapping3);

            slideLayout2.Append(commonSlideData4);
            slideLayout2.Append(colorMapOverride3);

            slideLayoutPart2.SlideLayout = slideLayout2;
        }

        // Generates content of slideLayoutPart3.
        private void GenerateSlideLayoutPart3Content(SlideLayoutPart slideLayoutPart3)
        {
            SlideLayout slideLayout3 = new SlideLayout() { Type = SlideLayoutValues.SectionHeader, Preserve = true };
            slideLayout3.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout3.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData5 = new CommonSlideData() { Name = "구역 머리글" };

            ShapeTree shapeTree5 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties6 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties25 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties6 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties25 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties6.Append(nonVisualDrawingProperties25);
            nonVisualGroupShapeProperties6.Append(nonVisualGroupShapeDrawingProperties6);
            nonVisualGroupShapeProperties6.Append(applicationNonVisualDrawingProperties25);

            GroupShapeProperties groupShapeProperties6 = new GroupShapeProperties();

            A.TransformGroup transformGroup6 = new A.TransformGroup();
            A.Offset offset19 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents19 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset6 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents6 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup6.Append(offset19);
            transformGroup6.Append(extents19);
            transformGroup6.Append(childOffset6);
            transformGroup6.Append(childExtents6);

            groupShapeProperties6.Append(transformGroup6);

            Shape shape17 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties17 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties26 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties17 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks17 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties17.Append(shapeLocks17);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties26 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape17 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties26.Append(placeholderShape17);

            nonVisualShapeProperties17.Append(nonVisualDrawingProperties26);
            nonVisualShapeProperties17.Append(nonVisualShapeDrawingProperties17);
            nonVisualShapeProperties17.Append(applicationNonVisualDrawingProperties26);

            ShapeProperties shapeProperties20 = new ShapeProperties();

            A.Transform2D transform2D14 = new A.Transform2D();
            A.Offset offset20 = new A.Offset() { X = 623888L, Y = 1709739L };
            A.Extents extents20 = new A.Extents() { Cx = 7886700L, Cy = 2852737L };

            transform2D14.Append(offset20);
            transform2D14.Append(extents20);

            shapeProperties20.Append(transform2D14);

            TextBody textBody17 = new TextBody();
            A.BodyProperties bodyProperties17 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle17 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties13 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties63 = new A.DefaultRunProperties() { FontSize = 6000 };

            level1ParagraphProperties13.Append(defaultRunProperties63);

            listStyle17.Append(level1ParagraphProperties13);

            A.Paragraph paragraph25 = new A.Paragraph();

            A.Run run16 = new A.Run();

            A.RunProperties runProperties22 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties22.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text22 = new A.Text();
            text22.Text = "마스터 제목 스타일 편집";

            run16.Append(runProperties22);
            run16.Append(text22);
            A.EndParagraphRunProperties endParagraphRunProperties16 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph25.Append(run16);
            paragraph25.Append(endParagraphRunProperties16);

            textBody17.Append(bodyProperties17);
            textBody17.Append(listStyle17);
            textBody17.Append(paragraph25);

            shape17.Append(nonVisualShapeProperties17);
            shape17.Append(shapeProperties20);
            shape17.Append(textBody17);

            Shape shape18 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties18 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties27 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties18 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks18 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties18.Append(shapeLocks18);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties27 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape18 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties27.Append(placeholderShape18);

            nonVisualShapeProperties18.Append(nonVisualDrawingProperties27);
            nonVisualShapeProperties18.Append(nonVisualShapeDrawingProperties18);
            nonVisualShapeProperties18.Append(applicationNonVisualDrawingProperties27);

            ShapeProperties shapeProperties21 = new ShapeProperties();

            A.Transform2D transform2D15 = new A.Transform2D();
            A.Offset offset21 = new A.Offset() { X = 623888L, Y = 4589464L };
            A.Extents extents21 = new A.Extents() { Cx = 7886700L, Cy = 1500187L };

            transform2D15.Append(offset21);
            transform2D15.Append(extents21);

            shapeProperties21.Append(transform2D15);

            TextBody textBody18 = new TextBody();
            A.BodyProperties bodyProperties18 = new A.BodyProperties();

            A.ListStyle listStyle18 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties14 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet20 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties64 = new A.DefaultRunProperties() { FontSize = 2400 };

            A.SolidFill solidFill32 = new A.SolidFill();
            A.SchemeColor schemeColor45 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };

            solidFill32.Append(schemeColor45);

            defaultRunProperties64.Append(solidFill32);

            level1ParagraphProperties14.Append(noBullet20);
            level1ParagraphProperties14.Append(defaultRunProperties64);

            A.Level2ParagraphProperties level2ParagraphProperties7 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet21 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties65 = new A.DefaultRunProperties() { FontSize = 2000 };

            A.SolidFill solidFill33 = new A.SolidFill();

            A.SchemeColor schemeColor46 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint4 = new A.Tint() { Val = 75000 };

            schemeColor46.Append(tint4);

            solidFill33.Append(schemeColor46);

            defaultRunProperties65.Append(solidFill33);

            level2ParagraphProperties7.Append(noBullet21);
            level2ParagraphProperties7.Append(defaultRunProperties65);

            A.Level3ParagraphProperties level3ParagraphProperties7 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet22 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties66 = new A.DefaultRunProperties() { FontSize = 1800 };

            A.SolidFill solidFill34 = new A.SolidFill();

            A.SchemeColor schemeColor47 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint5 = new A.Tint() { Val = 75000 };

            schemeColor47.Append(tint5);

            solidFill34.Append(schemeColor47);

            defaultRunProperties66.Append(solidFill34);

            level3ParagraphProperties7.Append(noBullet22);
            level3ParagraphProperties7.Append(defaultRunProperties66);

            A.Level4ParagraphProperties level4ParagraphProperties7 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet23 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties67 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill35 = new A.SolidFill();

            A.SchemeColor schemeColor48 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint6 = new A.Tint() { Val = 75000 };

            schemeColor48.Append(tint6);

            solidFill35.Append(schemeColor48);

            defaultRunProperties67.Append(solidFill35);

            level4ParagraphProperties7.Append(noBullet23);
            level4ParagraphProperties7.Append(defaultRunProperties67);

            A.Level5ParagraphProperties level5ParagraphProperties7 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet24 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties68 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill36 = new A.SolidFill();

            A.SchemeColor schemeColor49 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint7 = new A.Tint() { Val = 75000 };

            schemeColor49.Append(tint7);

            solidFill36.Append(schemeColor49);

            defaultRunProperties68.Append(solidFill36);

            level5ParagraphProperties7.Append(noBullet24);
            level5ParagraphProperties7.Append(defaultRunProperties68);

            A.Level6ParagraphProperties level6ParagraphProperties7 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet25 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties69 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill37 = new A.SolidFill();

            A.SchemeColor schemeColor50 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint8 = new A.Tint() { Val = 75000 };

            schemeColor50.Append(tint8);

            solidFill37.Append(schemeColor50);

            defaultRunProperties69.Append(solidFill37);

            level6ParagraphProperties7.Append(noBullet25);
            level6ParagraphProperties7.Append(defaultRunProperties69);

            A.Level7ParagraphProperties level7ParagraphProperties7 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet26 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties70 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill38 = new A.SolidFill();

            A.SchemeColor schemeColor51 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint9 = new A.Tint() { Val = 75000 };

            schemeColor51.Append(tint9);

            solidFill38.Append(schemeColor51);

            defaultRunProperties70.Append(solidFill38);

            level7ParagraphProperties7.Append(noBullet26);
            level7ParagraphProperties7.Append(defaultRunProperties70);

            A.Level8ParagraphProperties level8ParagraphProperties7 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet27 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties71 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill39 = new A.SolidFill();

            A.SchemeColor schemeColor52 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint10 = new A.Tint() { Val = 75000 };

            schemeColor52.Append(tint10);

            solidFill39.Append(schemeColor52);

            defaultRunProperties71.Append(solidFill39);

            level8ParagraphProperties7.Append(noBullet27);
            level8ParagraphProperties7.Append(defaultRunProperties71);

            A.Level9ParagraphProperties level9ParagraphProperties7 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet28 = new A.NoBullet();

            A.DefaultRunProperties defaultRunProperties72 = new A.DefaultRunProperties() { FontSize = 1600 };

            A.SolidFill solidFill40 = new A.SolidFill();

            A.SchemeColor schemeColor53 = new A.SchemeColor() { Val = A.SchemeColorValues.Text1 };
            A.Tint tint11 = new A.Tint() { Val = 75000 };

            schemeColor53.Append(tint11);

            solidFill40.Append(schemeColor53);

            defaultRunProperties72.Append(solidFill40);

            level9ParagraphProperties7.Append(noBullet28);
            level9ParagraphProperties7.Append(defaultRunProperties72);

            listStyle18.Append(level1ParagraphProperties14);
            listStyle18.Append(level2ParagraphProperties7);
            listStyle18.Append(level3ParagraphProperties7);
            listStyle18.Append(level4ParagraphProperties7);
            listStyle18.Append(level5ParagraphProperties7);
            listStyle18.Append(level6ParagraphProperties7);
            listStyle18.Append(level7ParagraphProperties7);
            listStyle18.Append(level8ParagraphProperties7);
            listStyle18.Append(level9ParagraphProperties7);

            A.Paragraph paragraph26 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties12 = new A.ParagraphProperties() { Level = 0 };

            A.Run run17 = new A.Run();

            A.RunProperties runProperties23 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties23.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text23 = new A.Text();
            text23.Text = "마스터 텍스트 스타일을 편집합니다";

            run17.Append(runProperties23);
            run17.Append(text23);

            paragraph26.Append(paragraphProperties12);
            paragraph26.Append(run17);

            textBody18.Append(bodyProperties18);
            textBody18.Append(listStyle18);
            textBody18.Append(paragraph26);

            shape18.Append(nonVisualShapeProperties18);
            shape18.Append(shapeProperties21);
            shape18.Append(textBody18);

            Shape shape19 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties19 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties28 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties19 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks19 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties19.Append(shapeLocks19);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties28 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape19 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties28.Append(placeholderShape19);

            nonVisualShapeProperties19.Append(nonVisualDrawingProperties28);
            nonVisualShapeProperties19.Append(nonVisualShapeDrawingProperties19);
            nonVisualShapeProperties19.Append(applicationNonVisualDrawingProperties28);
            ShapeProperties shapeProperties22 = new ShapeProperties();

            TextBody textBody19 = new TextBody();
            A.BodyProperties bodyProperties19 = new A.BodyProperties();
            A.ListStyle listStyle19 = new A.ListStyle();

            A.Paragraph paragraph27 = new A.Paragraph();

            A.Field field7 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties24 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties24.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text24 = new A.Text();
            text24.Text = "2015-03-31";

            field7.Append(runProperties24);
            field7.Append(text24);
            A.EndParagraphRunProperties endParagraphRunProperties17 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph27.Append(field7);
            paragraph27.Append(endParagraphRunProperties17);

            textBody19.Append(bodyProperties19);
            textBody19.Append(listStyle19);
            textBody19.Append(paragraph27);

            shape19.Append(nonVisualShapeProperties19);
            shape19.Append(shapeProperties22);
            shape19.Append(textBody19);

            Shape shape20 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties20 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties29 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties20 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks20 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties20.Append(shapeLocks20);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties29 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape20 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties29.Append(placeholderShape20);

            nonVisualShapeProperties20.Append(nonVisualDrawingProperties29);
            nonVisualShapeProperties20.Append(nonVisualShapeDrawingProperties20);
            nonVisualShapeProperties20.Append(applicationNonVisualDrawingProperties29);
            ShapeProperties shapeProperties23 = new ShapeProperties();

            TextBody textBody20 = new TextBody();
            A.BodyProperties bodyProperties20 = new A.BodyProperties();
            A.ListStyle listStyle20 = new A.ListStyle();

            A.Paragraph paragraph28 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties18 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph28.Append(endParagraphRunProperties18);

            textBody20.Append(bodyProperties20);
            textBody20.Append(listStyle20);
            textBody20.Append(paragraph28);

            shape20.Append(nonVisualShapeProperties20);
            shape20.Append(shapeProperties23);
            shape20.Append(textBody20);

            Shape shape21 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties21 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties30 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties21 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks21 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties21.Append(shapeLocks21);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties30 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape21 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties30.Append(placeholderShape21);

            nonVisualShapeProperties21.Append(nonVisualDrawingProperties30);
            nonVisualShapeProperties21.Append(nonVisualShapeDrawingProperties21);
            nonVisualShapeProperties21.Append(applicationNonVisualDrawingProperties30);
            ShapeProperties shapeProperties24 = new ShapeProperties();

            TextBody textBody21 = new TextBody();
            A.BodyProperties bodyProperties21 = new A.BodyProperties();
            A.ListStyle listStyle21 = new A.ListStyle();

            A.Paragraph paragraph29 = new A.Paragraph();

            A.Field field8 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties25 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties25.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text25 = new A.Text();
            text25.Text = "?#?";

            field8.Append(runProperties25);
            field8.Append(text25);
            A.EndParagraphRunProperties endParagraphRunProperties19 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph29.Append(field8);
            paragraph29.Append(endParagraphRunProperties19);

            textBody21.Append(bodyProperties21);
            textBody21.Append(listStyle21);
            textBody21.Append(paragraph29);

            shape21.Append(nonVisualShapeProperties21);
            shape21.Append(shapeProperties24);
            shape21.Append(textBody21);

            shapeTree5.Append(nonVisualGroupShapeProperties6);
            shapeTree5.Append(groupShapeProperties6);
            shapeTree5.Append(shape17);
            shapeTree5.Append(shape18);
            shapeTree5.Append(shape19);
            shapeTree5.Append(shape20);
            shapeTree5.Append(shape21);

            CommonSlideDataExtensionList commonSlideDataExtensionList5 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension5 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId5 = new P14.CreationId() { Val = (UInt32Value)2882165043U };
            creationId5.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension5.Append(creationId5);

            commonSlideDataExtensionList5.Append(commonSlideDataExtension5);

            commonSlideData5.Append(shapeTree5);
            commonSlideData5.Append(commonSlideDataExtensionList5);

            ColorMapOverride colorMapOverride4 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping4 = new A.MasterColorMapping();

            colorMapOverride4.Append(masterColorMapping4);

            slideLayout3.Append(commonSlideData5);
            slideLayout3.Append(colorMapOverride4);

            slideLayoutPart3.SlideLayout = slideLayout3;
        }

        // Generates content of slideLayoutPart4.
        private void GenerateSlideLayoutPart4Content(SlideLayoutPart slideLayoutPart4)
        {
            SlideLayout slideLayout4 = new SlideLayout() { Type = SlideLayoutValues.Blank, Preserve = true };
            slideLayout4.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout4.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout4.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData6 = new CommonSlideData() { Name = "빈 화면" };

            ShapeTree shapeTree6 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties7 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties31 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties7 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties31 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties7.Append(nonVisualDrawingProperties31);
            nonVisualGroupShapeProperties7.Append(nonVisualGroupShapeDrawingProperties7);
            nonVisualGroupShapeProperties7.Append(applicationNonVisualDrawingProperties31);

            GroupShapeProperties groupShapeProperties7 = new GroupShapeProperties();

            A.TransformGroup transformGroup7 = new A.TransformGroup();
            A.Offset offset22 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents22 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset7 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents7 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup7.Append(offset22);
            transformGroup7.Append(extents22);
            transformGroup7.Append(childOffset7);
            transformGroup7.Append(childExtents7);

            groupShapeProperties7.Append(transformGroup7);

            Shape shape22 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties22 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties32 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Date Placeholder 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties22 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks22 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties22.Append(shapeLocks22);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties32 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape22 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties32.Append(placeholderShape22);

            nonVisualShapeProperties22.Append(nonVisualDrawingProperties32);
            nonVisualShapeProperties22.Append(nonVisualShapeDrawingProperties22);
            nonVisualShapeProperties22.Append(applicationNonVisualDrawingProperties32);
            ShapeProperties shapeProperties25 = new ShapeProperties();

            TextBody textBody22 = new TextBody();
            A.BodyProperties bodyProperties22 = new A.BodyProperties();
            A.ListStyle listStyle22 = new A.ListStyle();

            A.Paragraph paragraph30 = new A.Paragraph();

            A.Field field9 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties26 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties26.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text26 = new A.Text();
            text26.Text = "2015-03-31";

            field9.Append(runProperties26);
            field9.Append(text26);
            A.EndParagraphRunProperties endParagraphRunProperties20 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph30.Append(field9);
            paragraph30.Append(endParagraphRunProperties20);

            textBody22.Append(bodyProperties22);
            textBody22.Append(listStyle22);
            textBody22.Append(paragraph30);

            shape22.Append(nonVisualShapeProperties22);
            shape22.Append(shapeProperties25);
            shape22.Append(textBody22);

            Shape shape23 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties23 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties33 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Footer Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties23 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks23 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties23.Append(shapeLocks23);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties33 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape23 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties33.Append(placeholderShape23);

            nonVisualShapeProperties23.Append(nonVisualDrawingProperties33);
            nonVisualShapeProperties23.Append(nonVisualShapeDrawingProperties23);
            nonVisualShapeProperties23.Append(applicationNonVisualDrawingProperties33);
            ShapeProperties shapeProperties26 = new ShapeProperties();

            TextBody textBody23 = new TextBody();
            A.BodyProperties bodyProperties23 = new A.BodyProperties();
            A.ListStyle listStyle23 = new A.ListStyle();

            A.Paragraph paragraph31 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties21 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph31.Append(endParagraphRunProperties21);

            textBody23.Append(bodyProperties23);
            textBody23.Append(listStyle23);
            textBody23.Append(paragraph31);

            shape23.Append(nonVisualShapeProperties23);
            shape23.Append(shapeProperties26);
            shape23.Append(textBody23);

            Shape shape24 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties24 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties34 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Slide Number Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties24 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks24 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties24.Append(shapeLocks24);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties34 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape24 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties34.Append(placeholderShape24);

            nonVisualShapeProperties24.Append(nonVisualDrawingProperties34);
            nonVisualShapeProperties24.Append(nonVisualShapeDrawingProperties24);
            nonVisualShapeProperties24.Append(applicationNonVisualDrawingProperties34);
            ShapeProperties shapeProperties27 = new ShapeProperties();

            TextBody textBody24 = new TextBody();
            A.BodyProperties bodyProperties24 = new A.BodyProperties();
            A.ListStyle listStyle24 = new A.ListStyle();

            A.Paragraph paragraph32 = new A.Paragraph();

            A.Field field10 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties27 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties27.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text27 = new A.Text();
            text27.Text = "?#?";

            field10.Append(runProperties27);
            field10.Append(text27);
            A.EndParagraphRunProperties endParagraphRunProperties22 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph32.Append(field10);
            paragraph32.Append(endParagraphRunProperties22);

            textBody24.Append(bodyProperties24);
            textBody24.Append(listStyle24);
            textBody24.Append(paragraph32);

            shape24.Append(nonVisualShapeProperties24);
            shape24.Append(shapeProperties27);
            shape24.Append(textBody24);

            shapeTree6.Append(nonVisualGroupShapeProperties7);
            shapeTree6.Append(groupShapeProperties7);
            shapeTree6.Append(shape22);
            shapeTree6.Append(shape23);
            shapeTree6.Append(shape24);

            CommonSlideDataExtensionList commonSlideDataExtensionList6 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension6 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId6 = new P14.CreationId() { Val = (UInt32Value)902786099U };
            creationId6.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension6.Append(creationId6);

            commonSlideDataExtensionList6.Append(commonSlideDataExtension6);

            commonSlideData6.Append(shapeTree6);
            commonSlideData6.Append(commonSlideDataExtensionList6);

            ColorMapOverride colorMapOverride5 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping5 = new A.MasterColorMapping();

            colorMapOverride5.Append(masterColorMapping5);

            slideLayout4.Append(commonSlideData6);
            slideLayout4.Append(colorMapOverride5);

            slideLayoutPart4.SlideLayout = slideLayout4;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Office 테마" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Office 테마" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "44546A" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "E7E6E6" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "5B9BD5" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "ED7D31" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "A5A5A5" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "FFC000" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4472C4" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "70AD47" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0563C1" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "954F72" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Office 테마" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont29 = new A.LatinFont() { Typeface = "Calibri Light", Panose = "020F0302020204030204" };
            A.EastAsianFont eastAsianFont29 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont29 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋?" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont29);
            majorFont1.Append(eastAsianFont29);
            majorFont1.Append(complexScriptFont29);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont30 = new A.LatinFont() { Typeface = "Calibri", Panose = "020F0502020204030204" };
            A.EastAsianFont eastAsianFont30 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont30 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ Ｐゴシック" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋?" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont30);
            minorFont1.Append(eastAsianFont30);
            minorFont1.Append(complexScriptFont30);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Office 테마" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill41 = new A.SolidFill();
            A.SchemeColor schemeColor54 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill41.Append(schemeColor54);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor55 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation1 = new A.LuminanceModulation() { Val = 110000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 105000 };
            A.Tint tint12 = new A.Tint() { Val = 67000 };

            schemeColor55.Append(luminanceModulation1);
            schemeColor55.Append(saturationModulation1);
            schemeColor55.Append(tint12);

            gradientStop1.Append(schemeColor55);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor56 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation2 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 103000 };
            A.Tint tint13 = new A.Tint() { Val = 73000 };

            schemeColor56.Append(luminanceModulation2);
            schemeColor56.Append(saturationModulation2);
            schemeColor56.Append(tint13);

            gradientStop2.Append(schemeColor56);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor57 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation3 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 109000 };
            A.Tint tint14 = new A.Tint() { Val = 81000 };

            schemeColor57.Append(luminanceModulation3);
            schemeColor57.Append(saturationModulation3);
            schemeColor57.Append(tint14);

            gradientStop3.Append(schemeColor57);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor58 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 103000 };
            A.LuminanceModulation luminanceModulation4 = new A.LuminanceModulation() { Val = 102000 };
            A.Tint tint15 = new A.Tint() { Val = 94000 };

            schemeColor58.Append(saturationModulation4);
            schemeColor58.Append(luminanceModulation4);
            schemeColor58.Append(tint15);

            gradientStop4.Append(schemeColor58);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor59 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 110000 };
            A.LuminanceModulation luminanceModulation5 = new A.LuminanceModulation() { Val = 100000 };
            A.Shade shade1 = new A.Shade() { Val = 100000 };

            schemeColor59.Append(saturationModulation5);
            schemeColor59.Append(luminanceModulation5);
            schemeColor59.Append(shade1);

            gradientStop5.Append(schemeColor59);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor60 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation6 = new A.LuminanceModulation() { Val = 99000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 120000 };
            A.Shade shade2 = new A.Shade() { Val = 78000 };

            schemeColor60.Append(luminanceModulation6);
            schemeColor60.Append(saturationModulation6);
            schemeColor60.Append(shade2);

            gradientStop6.Append(schemeColor60);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill41);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline4 = new A.Outline() { Width = 6350, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill42 = new A.SolidFill();
            A.SchemeColor schemeColor61 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill42.Append(schemeColor61);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter1 = new A.Miter() { Limit = 800000 };

            outline4.Append(solidFill42);
            outline4.Append(presetDash1);
            outline4.Append(miter1);

            A.Outline outline5 = new A.Outline() { Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill43 = new A.SolidFill();
            A.SchemeColor schemeColor62 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill43.Append(schemeColor62);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter2 = new A.Miter() { Limit = 800000 };

            outline5.Append(solidFill43);
            outline5.Append(presetDash2);
            outline5.Append(miter2);

            A.Outline outline6 = new A.Outline() { Width = 19050, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill44 = new A.SolidFill();
            A.SchemeColor schemeColor63 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill44.Append(schemeColor63);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter3 = new A.Miter() { Limit = 800000 };

            outline6.Append(solidFill44);
            outline6.Append(presetDash3);
            outline6.Append(miter3);

            lineStyleList1.Append(outline4);
            lineStyleList1.Append(outline5);
            lineStyleList1.Append(outline6);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();
            A.EffectList effectList1 = new A.EffectList();

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();
            A.EffectList effectList2 = new A.EffectList();

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 57150L, Distance = 19050L, Direction = 5400000, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 63000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList3.Append(outerShadow1);

            effectStyle3.Append(effectList3);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill45 = new A.SolidFill();
            A.SchemeColor schemeColor64 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill45.Append(schemeColor64);

            A.SolidFill solidFill46 = new A.SolidFill();

            A.SchemeColor schemeColor65 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint16 = new A.Tint() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 170000 };

            schemeColor65.Append(tint16);
            schemeColor65.Append(saturationModulation7);

            solidFill46.Append(schemeColor65);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor66 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint17 = new A.Tint() { Val = 93000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 150000 };
            A.Shade shade3 = new A.Shade() { Val = 98000 };
            A.LuminanceModulation luminanceModulation7 = new A.LuminanceModulation() { Val = 102000 };

            schemeColor66.Append(tint17);
            schemeColor66.Append(saturationModulation8);
            schemeColor66.Append(shade3);
            schemeColor66.Append(luminanceModulation7);

            gradientStop7.Append(schemeColor66);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor67 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint18 = new A.Tint() { Val = 98000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 130000 };
            A.Shade shade4 = new A.Shade() { Val = 90000 };
            A.LuminanceModulation luminanceModulation8 = new A.LuminanceModulation() { Val = 103000 };

            schemeColor67.Append(tint18);
            schemeColor67.Append(saturationModulation9);
            schemeColor67.Append(shade4);
            schemeColor67.Append(luminanceModulation8);

            gradientStop8.Append(schemeColor67);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor68 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade5 = new A.Shade() { Val = 63000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 120000 };

            schemeColor68.Append(shade5);
            schemeColor68.Append(saturationModulation10);

            gradientStop9.Append(schemeColor68);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);
            A.LinearGradientFill linearGradientFill3 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(linearGradientFill3);

            backgroundFillStyleList1.Append(solidFill45);
            backgroundFillStyleList1.Append(solidFill46);
            backgroundFillStyleList1.Append(gradientFill3);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            A.OfficeStyleSheetExtensionList officeStyleSheetExtensionList1 = new A.OfficeStyleSheetExtensionList();

            A.OfficeStyleSheetExtension officeStyleSheetExtension1 = new A.OfficeStyleSheetExtension() { Uri = "{05A4C25C-085E-4340-85A3-A5531E510DB2}" };

            Thm15.ThemeFamily themeFamily1 = new Thm15.ThemeFamily() { Name = "Office Theme", Id = "{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}", Vid = "{4A3C46E8-61CC-4603-A589-7422A47A8E4A}" };
            themeFamily1.AddNamespaceDeclaration("thm15", "http://schemas.microsoft.com/office/thememl/2012/main");

            officeStyleSheetExtension1.Append(themeFamily1);

            officeStyleSheetExtensionList1.Append(officeStyleSheetExtension1);

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);
            theme1.Append(officeStyleSheetExtensionList1);

            themePart1.Theme = theme1;
        }

        // Generates content of slideLayoutPart5.
        private void GenerateSlideLayoutPart5Content(SlideLayoutPart slideLayoutPart5)
        {
            SlideLayout slideLayout5 = new SlideLayout() { Type = SlideLayoutValues.Object, Preserve = true };
            slideLayout5.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout5.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout5.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData7 = new CommonSlideData() { Name = "제목 및 내용" };

            ShapeTree shapeTree7 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties8 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties35 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties8 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties35 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties8.Append(nonVisualDrawingProperties35);
            nonVisualGroupShapeProperties8.Append(nonVisualGroupShapeDrawingProperties8);
            nonVisualGroupShapeProperties8.Append(applicationNonVisualDrawingProperties35);

            GroupShapeProperties groupShapeProperties8 = new GroupShapeProperties();

            A.TransformGroup transformGroup8 = new A.TransformGroup();
            A.Offset offset23 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents23 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset8 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents8 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup8.Append(offset23);
            transformGroup8.Append(extents23);
            transformGroup8.Append(childOffset8);
            transformGroup8.Append(childExtents8);

            groupShapeProperties8.Append(transformGroup8);

            Shape shape25 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties25 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties36 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties25 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks25 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties25.Append(shapeLocks25);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties36 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape25 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties36.Append(placeholderShape25);

            nonVisualShapeProperties25.Append(nonVisualDrawingProperties36);
            nonVisualShapeProperties25.Append(nonVisualShapeDrawingProperties25);
            nonVisualShapeProperties25.Append(applicationNonVisualDrawingProperties36);
            ShapeProperties shapeProperties28 = new ShapeProperties();

            TextBody textBody25 = new TextBody();
            A.BodyProperties bodyProperties25 = new A.BodyProperties();
            A.ListStyle listStyle25 = new A.ListStyle();

            A.Paragraph paragraph33 = new A.Paragraph();

            A.Run run18 = new A.Run();

            A.RunProperties runProperties28 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties28.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text28 = new A.Text();
            text28.Text = "마스터 제목 스타일 편집";

            run18.Append(runProperties28);
            run18.Append(text28);
            A.EndParagraphRunProperties endParagraphRunProperties23 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph33.Append(run18);
            paragraph33.Append(endParagraphRunProperties23);

            textBody25.Append(bodyProperties25);
            textBody25.Append(listStyle25);
            textBody25.Append(paragraph33);

            shape25.Append(nonVisualShapeProperties25);
            shape25.Append(shapeProperties28);
            shape25.Append(textBody25);

            Shape shape26 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties26 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties37 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties26 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks26 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties26.Append(shapeLocks26);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties37 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape26 = new PlaceholderShape() { Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties37.Append(placeholderShape26);

            nonVisualShapeProperties26.Append(nonVisualDrawingProperties37);
            nonVisualShapeProperties26.Append(nonVisualShapeDrawingProperties26);
            nonVisualShapeProperties26.Append(applicationNonVisualDrawingProperties37);
            ShapeProperties shapeProperties29 = new ShapeProperties();

            TextBody textBody26 = new TextBody();
            A.BodyProperties bodyProperties26 = new A.BodyProperties();
            A.ListStyle listStyle26 = new A.ListStyle();

            A.Paragraph paragraph34 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties13 = new A.ParagraphProperties() { Level = 0 };

            A.Run run19 = new A.Run();

            A.RunProperties runProperties29 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties29.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text29 = new A.Text();
            text29.Text = "마스터 텍스트 스타일을 편집합니다";

            run19.Append(runProperties29);
            run19.Append(text29);

            paragraph34.Append(paragraphProperties13);
            paragraph34.Append(run19);

            A.Paragraph paragraph35 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties14 = new A.ParagraphProperties() { Level = 1 };

            A.Run run20 = new A.Run();

            A.RunProperties runProperties30 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties30.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text30 = new A.Text();
            text30.Text = "둘째 수준";

            run20.Append(runProperties30);
            run20.Append(text30);

            paragraph35.Append(paragraphProperties14);
            paragraph35.Append(run20);

            A.Paragraph paragraph36 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties15 = new A.ParagraphProperties() { Level = 2 };

            A.Run run21 = new A.Run();

            A.RunProperties runProperties31 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties31.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text31 = new A.Text();
            text31.Text = "셋째 수준";

            run21.Append(runProperties31);
            run21.Append(text31);

            paragraph36.Append(paragraphProperties15);
            paragraph36.Append(run21);

            A.Paragraph paragraph37 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties16 = new A.ParagraphProperties() { Level = 3 };

            A.Run run22 = new A.Run();

            A.RunProperties runProperties32 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties32.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text32 = new A.Text();
            text32.Text = "넷째 수준";

            run22.Append(runProperties32);
            run22.Append(text32);

            paragraph37.Append(paragraphProperties16);
            paragraph37.Append(run22);

            A.Paragraph paragraph38 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties17 = new A.ParagraphProperties() { Level = 4 };

            A.Run run23 = new A.Run();

            A.RunProperties runProperties33 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties33.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text33 = new A.Text();
            text33.Text = "다섯째 수준";

            run23.Append(runProperties33);
            run23.Append(text33);
            A.EndParagraphRunProperties endParagraphRunProperties24 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph38.Append(paragraphProperties17);
            paragraph38.Append(run23);
            paragraph38.Append(endParagraphRunProperties24);

            textBody26.Append(bodyProperties26);
            textBody26.Append(listStyle26);
            textBody26.Append(paragraph34);
            textBody26.Append(paragraph35);
            textBody26.Append(paragraph36);
            textBody26.Append(paragraph37);
            textBody26.Append(paragraph38);

            shape26.Append(nonVisualShapeProperties26);
            shape26.Append(shapeProperties29);
            shape26.Append(textBody26);

            Shape shape27 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties27 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties38 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties27 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks27 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties27.Append(shapeLocks27);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties38 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape27 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties38.Append(placeholderShape27);

            nonVisualShapeProperties27.Append(nonVisualDrawingProperties38);
            nonVisualShapeProperties27.Append(nonVisualShapeDrawingProperties27);
            nonVisualShapeProperties27.Append(applicationNonVisualDrawingProperties38);
            ShapeProperties shapeProperties30 = new ShapeProperties();

            TextBody textBody27 = new TextBody();
            A.BodyProperties bodyProperties27 = new A.BodyProperties();
            A.ListStyle listStyle27 = new A.ListStyle();

            A.Paragraph paragraph39 = new A.Paragraph();

            A.Field field11 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties34 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties34.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text34 = new A.Text();
            text34.Text = "2015-03-31";

            field11.Append(runProperties34);
            field11.Append(text34);
            A.EndParagraphRunProperties endParagraphRunProperties25 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph39.Append(field11);
            paragraph39.Append(endParagraphRunProperties25);

            textBody27.Append(bodyProperties27);
            textBody27.Append(listStyle27);
            textBody27.Append(paragraph39);

            shape27.Append(nonVisualShapeProperties27);
            shape27.Append(shapeProperties30);
            shape27.Append(textBody27);

            Shape shape28 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties28 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties39 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties28 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks28 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties28.Append(shapeLocks28);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties39 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape28 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties39.Append(placeholderShape28);

            nonVisualShapeProperties28.Append(nonVisualDrawingProperties39);
            nonVisualShapeProperties28.Append(nonVisualShapeDrawingProperties28);
            nonVisualShapeProperties28.Append(applicationNonVisualDrawingProperties39);
            ShapeProperties shapeProperties31 = new ShapeProperties();

            TextBody textBody28 = new TextBody();
            A.BodyProperties bodyProperties28 = new A.BodyProperties();
            A.ListStyle listStyle28 = new A.ListStyle();

            A.Paragraph paragraph40 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties26 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph40.Append(endParagraphRunProperties26);

            textBody28.Append(bodyProperties28);
            textBody28.Append(listStyle28);
            textBody28.Append(paragraph40);

            shape28.Append(nonVisualShapeProperties28);
            shape28.Append(shapeProperties31);
            shape28.Append(textBody28);

            Shape shape29 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties29 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties40 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties29 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks29 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties29.Append(shapeLocks29);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties40 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape29 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties40.Append(placeholderShape29);

            nonVisualShapeProperties29.Append(nonVisualDrawingProperties40);
            nonVisualShapeProperties29.Append(nonVisualShapeDrawingProperties29);
            nonVisualShapeProperties29.Append(applicationNonVisualDrawingProperties40);
            ShapeProperties shapeProperties32 = new ShapeProperties();

            TextBody textBody29 = new TextBody();
            A.BodyProperties bodyProperties29 = new A.BodyProperties();
            A.ListStyle listStyle29 = new A.ListStyle();

            A.Paragraph paragraph41 = new A.Paragraph();

            A.Field field12 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties35 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties35.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text35 = new A.Text();
            text35.Text = "?#?";

            field12.Append(runProperties35);
            field12.Append(text35);
            A.EndParagraphRunProperties endParagraphRunProperties27 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph41.Append(field12);
            paragraph41.Append(endParagraphRunProperties27);

            textBody29.Append(bodyProperties29);
            textBody29.Append(listStyle29);
            textBody29.Append(paragraph41);

            shape29.Append(nonVisualShapeProperties29);
            shape29.Append(shapeProperties32);
            shape29.Append(textBody29);

            shapeTree7.Append(nonVisualGroupShapeProperties8);
            shapeTree7.Append(groupShapeProperties8);
            shapeTree7.Append(shape25);
            shapeTree7.Append(shape26);
            shapeTree7.Append(shape27);
            shapeTree7.Append(shape28);
            shapeTree7.Append(shape29);

            CommonSlideDataExtensionList commonSlideDataExtensionList7 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension7 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId7 = new P14.CreationId() { Val = (UInt32Value)3598684010U };
            creationId7.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension7.Append(creationId7);

            commonSlideDataExtensionList7.Append(commonSlideDataExtension7);

            commonSlideData7.Append(shapeTree7);
            commonSlideData7.Append(commonSlideDataExtensionList7);

            ColorMapOverride colorMapOverride6 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping6 = new A.MasterColorMapping();

            colorMapOverride6.Append(masterColorMapping6);

            slideLayout5.Append(commonSlideData7);
            slideLayout5.Append(colorMapOverride6);

            slideLayoutPart5.SlideLayout = slideLayout5;
        }

        // Generates content of slideLayoutPart6.
        private void GenerateSlideLayoutPart6Content(SlideLayoutPart slideLayoutPart6)
        {
            SlideLayout slideLayout6 = new SlideLayout() { Type = SlideLayoutValues.TitleOnly, Preserve = true };
            slideLayout6.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout6.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout6.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData8 = new CommonSlideData() { Name = "제목만" };

            ShapeTree shapeTree8 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties9 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties41 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties9 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties41 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties9.Append(nonVisualDrawingProperties41);
            nonVisualGroupShapeProperties9.Append(nonVisualGroupShapeDrawingProperties9);
            nonVisualGroupShapeProperties9.Append(applicationNonVisualDrawingProperties41);

            GroupShapeProperties groupShapeProperties9 = new GroupShapeProperties();

            A.TransformGroup transformGroup9 = new A.TransformGroup();
            A.Offset offset24 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents24 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset9 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents9 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup9.Append(offset24);
            transformGroup9.Append(extents24);
            transformGroup9.Append(childOffset9);
            transformGroup9.Append(childExtents9);

            groupShapeProperties9.Append(transformGroup9);

            Shape shape30 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties30 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties42 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties30 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks30 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties30.Append(shapeLocks30);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties42 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape30 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties42.Append(placeholderShape30);

            nonVisualShapeProperties30.Append(nonVisualDrawingProperties42);
            nonVisualShapeProperties30.Append(nonVisualShapeDrawingProperties30);
            nonVisualShapeProperties30.Append(applicationNonVisualDrawingProperties42);
            ShapeProperties shapeProperties33 = new ShapeProperties();

            TextBody textBody30 = new TextBody();
            A.BodyProperties bodyProperties30 = new A.BodyProperties();
            A.ListStyle listStyle30 = new A.ListStyle();

            A.Paragraph paragraph42 = new A.Paragraph();

            A.Run run24 = new A.Run();

            A.RunProperties runProperties36 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties36.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text36 = new A.Text();
            text36.Text = "마스터 제목 스타일 편집";

            run24.Append(runProperties36);
            run24.Append(text36);
            A.EndParagraphRunProperties endParagraphRunProperties28 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph42.Append(run24);
            paragraph42.Append(endParagraphRunProperties28);

            textBody30.Append(bodyProperties30);
            textBody30.Append(listStyle30);
            textBody30.Append(paragraph42);

            shape30.Append(nonVisualShapeProperties30);
            shape30.Append(shapeProperties33);
            shape30.Append(textBody30);

            Shape shape31 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties31 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties43 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Date Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties31 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks31 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties31.Append(shapeLocks31);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties43 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape31 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties43.Append(placeholderShape31);

            nonVisualShapeProperties31.Append(nonVisualDrawingProperties43);
            nonVisualShapeProperties31.Append(nonVisualShapeDrawingProperties31);
            nonVisualShapeProperties31.Append(applicationNonVisualDrawingProperties43);
            ShapeProperties shapeProperties34 = new ShapeProperties();

            TextBody textBody31 = new TextBody();
            A.BodyProperties bodyProperties31 = new A.BodyProperties();
            A.ListStyle listStyle31 = new A.ListStyle();

            A.Paragraph paragraph43 = new A.Paragraph();

            A.Field field13 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties37 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties37.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text37 = new A.Text();
            text37.Text = "2015-03-31";

            field13.Append(runProperties37);
            field13.Append(text37);
            A.EndParagraphRunProperties endParagraphRunProperties29 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph43.Append(field13);
            paragraph43.Append(endParagraphRunProperties29);

            textBody31.Append(bodyProperties31);
            textBody31.Append(listStyle31);
            textBody31.Append(paragraph43);

            shape31.Append(nonVisualShapeProperties31);
            shape31.Append(shapeProperties34);
            shape31.Append(textBody31);

            Shape shape32 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties32 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties44 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Footer Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties32 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks32 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties32.Append(shapeLocks32);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties44 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape32 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties44.Append(placeholderShape32);

            nonVisualShapeProperties32.Append(nonVisualDrawingProperties44);
            nonVisualShapeProperties32.Append(nonVisualShapeDrawingProperties32);
            nonVisualShapeProperties32.Append(applicationNonVisualDrawingProperties44);
            ShapeProperties shapeProperties35 = new ShapeProperties();

            TextBody textBody32 = new TextBody();
            A.BodyProperties bodyProperties32 = new A.BodyProperties();
            A.ListStyle listStyle32 = new A.ListStyle();

            A.Paragraph paragraph44 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties30 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph44.Append(endParagraphRunProperties30);

            textBody32.Append(bodyProperties32);
            textBody32.Append(listStyle32);
            textBody32.Append(paragraph44);

            shape32.Append(nonVisualShapeProperties32);
            shape32.Append(shapeProperties35);
            shape32.Append(textBody32);

            Shape shape33 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties33 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties45 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Slide Number Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties33 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks33 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties33.Append(shapeLocks33);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties45 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape33 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties45.Append(placeholderShape33);

            nonVisualShapeProperties33.Append(nonVisualDrawingProperties45);
            nonVisualShapeProperties33.Append(nonVisualShapeDrawingProperties33);
            nonVisualShapeProperties33.Append(applicationNonVisualDrawingProperties45);
            ShapeProperties shapeProperties36 = new ShapeProperties();

            TextBody textBody33 = new TextBody();
            A.BodyProperties bodyProperties33 = new A.BodyProperties();
            A.ListStyle listStyle33 = new A.ListStyle();

            A.Paragraph paragraph45 = new A.Paragraph();

            A.Field field14 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties38 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties38.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text38 = new A.Text();
            text38.Text = "?#?";

            field14.Append(runProperties38);
            field14.Append(text38);
            A.EndParagraphRunProperties endParagraphRunProperties31 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph45.Append(field14);
            paragraph45.Append(endParagraphRunProperties31);

            textBody33.Append(bodyProperties33);
            textBody33.Append(listStyle33);
            textBody33.Append(paragraph45);

            shape33.Append(nonVisualShapeProperties33);
            shape33.Append(shapeProperties36);
            shape33.Append(textBody33);

            shapeTree8.Append(nonVisualGroupShapeProperties9);
            shapeTree8.Append(groupShapeProperties9);
            shapeTree8.Append(shape30);
            shapeTree8.Append(shape31);
            shapeTree8.Append(shape32);
            shapeTree8.Append(shape33);

            CommonSlideDataExtensionList commonSlideDataExtensionList8 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension8 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId8 = new P14.CreationId() { Val = (UInt32Value)2109037186U };
            creationId8.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension8.Append(creationId8);

            commonSlideDataExtensionList8.Append(commonSlideDataExtension8);

            commonSlideData8.Append(shapeTree8);
            commonSlideData8.Append(commonSlideDataExtensionList8);

            ColorMapOverride colorMapOverride7 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping7 = new A.MasterColorMapping();

            colorMapOverride7.Append(masterColorMapping7);

            slideLayout6.Append(commonSlideData8);
            slideLayout6.Append(colorMapOverride7);

            slideLayoutPart6.SlideLayout = slideLayout6;
        }

        // Generates content of slideLayoutPart7.
        private void GenerateSlideLayoutPart7Content(SlideLayoutPart slideLayoutPart7)
        {
            SlideLayout slideLayout7 = new SlideLayout() { Type = SlideLayoutValues.VerticalTitleAndText, Preserve = true };
            slideLayout7.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout7.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout7.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData9 = new CommonSlideData() { Name = "세로 제목 및 텍스트" };

            ShapeTree shapeTree9 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties10 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties46 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties10 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties46 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties10.Append(nonVisualDrawingProperties46);
            nonVisualGroupShapeProperties10.Append(nonVisualGroupShapeDrawingProperties10);
            nonVisualGroupShapeProperties10.Append(applicationNonVisualDrawingProperties46);

            GroupShapeProperties groupShapeProperties10 = new GroupShapeProperties();

            A.TransformGroup transformGroup10 = new A.TransformGroup();
            A.Offset offset25 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents25 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset10 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents10 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup10.Append(offset25);
            transformGroup10.Append(extents25);
            transformGroup10.Append(childOffset10);
            transformGroup10.Append(childExtents10);

            groupShapeProperties10.Append(transformGroup10);

            Shape shape34 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties34 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties47 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Vertical Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties34 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks34 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties34.Append(shapeLocks34);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties47 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape34 = new PlaceholderShape() { Type = PlaceholderValues.Title, Orientation = DirectionValues.Vertical };

            applicationNonVisualDrawingProperties47.Append(placeholderShape34);

            nonVisualShapeProperties34.Append(nonVisualDrawingProperties47);
            nonVisualShapeProperties34.Append(nonVisualShapeDrawingProperties34);
            nonVisualShapeProperties34.Append(applicationNonVisualDrawingProperties47);

            ShapeProperties shapeProperties37 = new ShapeProperties();

            A.Transform2D transform2D16 = new A.Transform2D();
            A.Offset offset26 = new A.Offset() { X = 6543675L, Y = 365125L };
            A.Extents extents26 = new A.Extents() { Cx = 1971675L, Cy = 5811838L };

            transform2D16.Append(offset26);
            transform2D16.Append(extents26);

            shapeProperties37.Append(transform2D16);

            TextBody textBody34 = new TextBody();
            A.BodyProperties bodyProperties34 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle34 = new A.ListStyle();

            A.Paragraph paragraph46 = new A.Paragraph();

            A.Run run25 = new A.Run();

            A.RunProperties runProperties39 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties39.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text39 = new A.Text();
            text39.Text = "마스터 제목 스타일 편집";

            run25.Append(runProperties39);
            run25.Append(text39);
            A.EndParagraphRunProperties endParagraphRunProperties32 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph46.Append(run25);
            paragraph46.Append(endParagraphRunProperties32);

            textBody34.Append(bodyProperties34);
            textBody34.Append(listStyle34);
            textBody34.Append(paragraph46);

            shape34.Append(nonVisualShapeProperties34);
            shape34.Append(shapeProperties37);
            shape34.Append(textBody34);

            Shape shape35 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties35 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties48 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties35 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks35 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties35.Append(shapeLocks35);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties48 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape35 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties48.Append(placeholderShape35);

            nonVisualShapeProperties35.Append(nonVisualDrawingProperties48);
            nonVisualShapeProperties35.Append(nonVisualShapeDrawingProperties35);
            nonVisualShapeProperties35.Append(applicationNonVisualDrawingProperties48);

            ShapeProperties shapeProperties38 = new ShapeProperties();

            A.Transform2D transform2D17 = new A.Transform2D();
            A.Offset offset27 = new A.Offset() { X = 628650L, Y = 365125L };
            A.Extents extents27 = new A.Extents() { Cx = 5800725L, Cy = 5811838L };

            transform2D17.Append(offset27);
            transform2D17.Append(extents27);

            shapeProperties38.Append(transform2D17);

            TextBody textBody35 = new TextBody();
            A.BodyProperties bodyProperties35 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle35 = new A.ListStyle();

            A.Paragraph paragraph47 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties18 = new A.ParagraphProperties() { Level = 0 };

            A.Run run26 = new A.Run();

            A.RunProperties runProperties40 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties40.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text40 = new A.Text();
            text40.Text = "마스터 텍스트 스타일을 편집합니다";

            run26.Append(runProperties40);
            run26.Append(text40);

            paragraph47.Append(paragraphProperties18);
            paragraph47.Append(run26);

            A.Paragraph paragraph48 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties19 = new A.ParagraphProperties() { Level = 1 };

            A.Run run27 = new A.Run();

            A.RunProperties runProperties41 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties41.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text41 = new A.Text();
            text41.Text = "둘째 수준";

            run27.Append(runProperties41);
            run27.Append(text41);

            paragraph48.Append(paragraphProperties19);
            paragraph48.Append(run27);

            A.Paragraph paragraph49 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties20 = new A.ParagraphProperties() { Level = 2 };

            A.Run run28 = new A.Run();

            A.RunProperties runProperties42 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties42.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text42 = new A.Text();
            text42.Text = "셋째 수준";

            run28.Append(runProperties42);
            run28.Append(text42);

            paragraph49.Append(paragraphProperties20);
            paragraph49.Append(run28);

            A.Paragraph paragraph50 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties21 = new A.ParagraphProperties() { Level = 3 };

            A.Run run29 = new A.Run();

            A.RunProperties runProperties43 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties43.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text43 = new A.Text();
            text43.Text = "넷째 수준";

            run29.Append(runProperties43);
            run29.Append(text43);

            paragraph50.Append(paragraphProperties21);
            paragraph50.Append(run29);

            A.Paragraph paragraph51 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties22 = new A.ParagraphProperties() { Level = 4 };

            A.Run run30 = new A.Run();

            A.RunProperties runProperties44 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties44.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text44 = new A.Text();
            text44.Text = "다섯째 수준";

            run30.Append(runProperties44);
            run30.Append(text44);
            A.EndParagraphRunProperties endParagraphRunProperties33 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph51.Append(paragraphProperties22);
            paragraph51.Append(run30);
            paragraph51.Append(endParagraphRunProperties33);

            textBody35.Append(bodyProperties35);
            textBody35.Append(listStyle35);
            textBody35.Append(paragraph47);
            textBody35.Append(paragraph48);
            textBody35.Append(paragraph49);
            textBody35.Append(paragraph50);
            textBody35.Append(paragraph51);

            shape35.Append(nonVisualShapeProperties35);
            shape35.Append(shapeProperties38);
            shape35.Append(textBody35);

            Shape shape36 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties36 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties49 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties36 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks36 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties36.Append(shapeLocks36);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties49 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape36 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties49.Append(placeholderShape36);

            nonVisualShapeProperties36.Append(nonVisualDrawingProperties49);
            nonVisualShapeProperties36.Append(nonVisualShapeDrawingProperties36);
            nonVisualShapeProperties36.Append(applicationNonVisualDrawingProperties49);
            ShapeProperties shapeProperties39 = new ShapeProperties();

            TextBody textBody36 = new TextBody();
            A.BodyProperties bodyProperties36 = new A.BodyProperties();
            A.ListStyle listStyle36 = new A.ListStyle();

            A.Paragraph paragraph52 = new A.Paragraph();

            A.Field field15 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties45 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties45.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text45 = new A.Text();
            text45.Text = "2015-03-31";

            field15.Append(runProperties45);
            field15.Append(text45);
            A.EndParagraphRunProperties endParagraphRunProperties34 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph52.Append(field15);
            paragraph52.Append(endParagraphRunProperties34);

            textBody36.Append(bodyProperties36);
            textBody36.Append(listStyle36);
            textBody36.Append(paragraph52);

            shape36.Append(nonVisualShapeProperties36);
            shape36.Append(shapeProperties39);
            shape36.Append(textBody36);

            Shape shape37 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties37 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties50 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties37 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks37 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties37.Append(shapeLocks37);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties50 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape37 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties50.Append(placeholderShape37);

            nonVisualShapeProperties37.Append(nonVisualDrawingProperties50);
            nonVisualShapeProperties37.Append(nonVisualShapeDrawingProperties37);
            nonVisualShapeProperties37.Append(applicationNonVisualDrawingProperties50);
            ShapeProperties shapeProperties40 = new ShapeProperties();

            TextBody textBody37 = new TextBody();
            A.BodyProperties bodyProperties37 = new A.BodyProperties();
            A.ListStyle listStyle37 = new A.ListStyle();

            A.Paragraph paragraph53 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties35 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph53.Append(endParagraphRunProperties35);

            textBody37.Append(bodyProperties37);
            textBody37.Append(listStyle37);
            textBody37.Append(paragraph53);

            shape37.Append(nonVisualShapeProperties37);
            shape37.Append(shapeProperties40);
            shape37.Append(textBody37);

            Shape shape38 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties38 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties51 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties38 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks38 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties38.Append(shapeLocks38);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties51 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape38 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties51.Append(placeholderShape38);

            nonVisualShapeProperties38.Append(nonVisualDrawingProperties51);
            nonVisualShapeProperties38.Append(nonVisualShapeDrawingProperties38);
            nonVisualShapeProperties38.Append(applicationNonVisualDrawingProperties51);
            ShapeProperties shapeProperties41 = new ShapeProperties();

            TextBody textBody38 = new TextBody();
            A.BodyProperties bodyProperties38 = new A.BodyProperties();
            A.ListStyle listStyle38 = new A.ListStyle();

            A.Paragraph paragraph54 = new A.Paragraph();

            A.Field field16 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties46 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties46.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text46 = new A.Text();
            text46.Text = "?#?";

            field16.Append(runProperties46);
            field16.Append(text46);
            A.EndParagraphRunProperties endParagraphRunProperties36 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph54.Append(field16);
            paragraph54.Append(endParagraphRunProperties36);

            textBody38.Append(bodyProperties38);
            textBody38.Append(listStyle38);
            textBody38.Append(paragraph54);

            shape38.Append(nonVisualShapeProperties38);
            shape38.Append(shapeProperties41);
            shape38.Append(textBody38);

            shapeTree9.Append(nonVisualGroupShapeProperties10);
            shapeTree9.Append(groupShapeProperties10);
            shapeTree9.Append(shape34);
            shapeTree9.Append(shape35);
            shapeTree9.Append(shape36);
            shapeTree9.Append(shape37);
            shapeTree9.Append(shape38);

            CommonSlideDataExtensionList commonSlideDataExtensionList9 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension9 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId9 = new P14.CreationId() { Val = (UInt32Value)3928659267U };
            creationId9.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension9.Append(creationId9);

            commonSlideDataExtensionList9.Append(commonSlideDataExtension9);

            commonSlideData9.Append(shapeTree9);
            commonSlideData9.Append(commonSlideDataExtensionList9);

            ColorMapOverride colorMapOverride8 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping8 = new A.MasterColorMapping();

            colorMapOverride8.Append(masterColorMapping8);

            slideLayout7.Append(commonSlideData9);
            slideLayout7.Append(colorMapOverride8);

            slideLayoutPart7.SlideLayout = slideLayout7;
        }

        // Generates content of slideLayoutPart8.
        private void GenerateSlideLayoutPart8Content(SlideLayoutPart slideLayoutPart8)
        {
            SlideLayout slideLayout8 = new SlideLayout() { Type = SlideLayoutValues.TwoTextAndTwoObjects, Preserve = true };
            slideLayout8.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout8.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout8.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData10 = new CommonSlideData() { Name = "비교" };

            ShapeTree shapeTree10 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties11 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties52 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties11 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties52 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties11.Append(nonVisualDrawingProperties52);
            nonVisualGroupShapeProperties11.Append(nonVisualGroupShapeDrawingProperties11);
            nonVisualGroupShapeProperties11.Append(applicationNonVisualDrawingProperties52);

            GroupShapeProperties groupShapeProperties11 = new GroupShapeProperties();

            A.TransformGroup transformGroup11 = new A.TransformGroup();
            A.Offset offset28 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents28 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset11 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents11 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup11.Append(offset28);
            transformGroup11.Append(extents28);
            transformGroup11.Append(childOffset11);
            transformGroup11.Append(childExtents11);

            groupShapeProperties11.Append(transformGroup11);

            Shape shape39 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties39 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties53 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties39 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks39 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties39.Append(shapeLocks39);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties53 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape39 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties53.Append(placeholderShape39);

            nonVisualShapeProperties39.Append(nonVisualDrawingProperties53);
            nonVisualShapeProperties39.Append(nonVisualShapeDrawingProperties39);
            nonVisualShapeProperties39.Append(applicationNonVisualDrawingProperties53);

            ShapeProperties shapeProperties42 = new ShapeProperties();

            A.Transform2D transform2D18 = new A.Transform2D();
            A.Offset offset29 = new A.Offset() { X = 629841L, Y = 365126L };
            A.Extents extents29 = new A.Extents() { Cx = 7886700L, Cy = 1325563L };

            transform2D18.Append(offset29);
            transform2D18.Append(extents29);

            shapeProperties42.Append(transform2D18);

            TextBody textBody39 = new TextBody();
            A.BodyProperties bodyProperties39 = new A.BodyProperties();
            A.ListStyle listStyle39 = new A.ListStyle();

            A.Paragraph paragraph55 = new A.Paragraph();

            A.Run run31 = new A.Run();

            A.RunProperties runProperties47 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties47.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text47 = new A.Text();
            text47.Text = "마스터 제목 스타일 편집";

            run31.Append(runProperties47);
            run31.Append(text47);
            A.EndParagraphRunProperties endParagraphRunProperties37 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph55.Append(run31);
            paragraph55.Append(endParagraphRunProperties37);

            textBody39.Append(bodyProperties39);
            textBody39.Append(listStyle39);
            textBody39.Append(paragraph55);

            shape39.Append(nonVisualShapeProperties39);
            shape39.Append(shapeProperties42);
            shape39.Append(textBody39);

            Shape shape40 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties40 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties54 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties40 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks40 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties40.Append(shapeLocks40);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties54 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape40 = new PlaceholderShape() { Type = PlaceholderValues.Body, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties54.Append(placeholderShape40);

            nonVisualShapeProperties40.Append(nonVisualDrawingProperties54);
            nonVisualShapeProperties40.Append(nonVisualShapeDrawingProperties40);
            nonVisualShapeProperties40.Append(applicationNonVisualDrawingProperties54);

            ShapeProperties shapeProperties43 = new ShapeProperties();

            A.Transform2D transform2D19 = new A.Transform2D();
            A.Offset offset30 = new A.Offset() { X = 629842L, Y = 1681163L };
            A.Extents extents30 = new A.Extents() { Cx = 3868340L, Cy = 823912L };

            transform2D19.Append(offset30);
            transform2D19.Append(extents30);

            shapeProperties43.Append(transform2D19);

            TextBody textBody40 = new TextBody();
            A.BodyProperties bodyProperties40 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle40 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties15 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet29 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties73 = new A.DefaultRunProperties() { FontSize = 2400, Bold = true };

            level1ParagraphProperties15.Append(noBullet29);
            level1ParagraphProperties15.Append(defaultRunProperties73);

            A.Level2ParagraphProperties level2ParagraphProperties8 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet30 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties74 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties8.Append(noBullet30);
            level2ParagraphProperties8.Append(defaultRunProperties74);

            A.Level3ParagraphProperties level3ParagraphProperties8 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet31 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties75 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties8.Append(noBullet31);
            level3ParagraphProperties8.Append(defaultRunProperties75);

            A.Level4ParagraphProperties level4ParagraphProperties8 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet32 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties76 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties8.Append(noBullet32);
            level4ParagraphProperties8.Append(defaultRunProperties76);

            A.Level5ParagraphProperties level5ParagraphProperties8 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet33 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties77 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties8.Append(noBullet33);
            level5ParagraphProperties8.Append(defaultRunProperties77);

            A.Level6ParagraphProperties level6ParagraphProperties8 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet34 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties78 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties8.Append(noBullet34);
            level6ParagraphProperties8.Append(defaultRunProperties78);

            A.Level7ParagraphProperties level7ParagraphProperties8 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet35 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties79 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties8.Append(noBullet35);
            level7ParagraphProperties8.Append(defaultRunProperties79);

            A.Level8ParagraphProperties level8ParagraphProperties8 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet36 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties80 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties8.Append(noBullet36);
            level8ParagraphProperties8.Append(defaultRunProperties80);

            A.Level9ParagraphProperties level9ParagraphProperties8 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet37 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties81 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level9ParagraphProperties8.Append(noBullet37);
            level9ParagraphProperties8.Append(defaultRunProperties81);

            listStyle40.Append(level1ParagraphProperties15);
            listStyle40.Append(level2ParagraphProperties8);
            listStyle40.Append(level3ParagraphProperties8);
            listStyle40.Append(level4ParagraphProperties8);
            listStyle40.Append(level5ParagraphProperties8);
            listStyle40.Append(level6ParagraphProperties8);
            listStyle40.Append(level7ParagraphProperties8);
            listStyle40.Append(level8ParagraphProperties8);
            listStyle40.Append(level9ParagraphProperties8);

            A.Paragraph paragraph56 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties23 = new A.ParagraphProperties() { Level = 0 };

            A.Run run32 = new A.Run();

            A.RunProperties runProperties48 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties48.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text48 = new A.Text();
            text48.Text = "마스터 텍스트 스타일을 편집합니다";

            run32.Append(runProperties48);
            run32.Append(text48);

            paragraph56.Append(paragraphProperties23);
            paragraph56.Append(run32);

            textBody40.Append(bodyProperties40);
            textBody40.Append(listStyle40);
            textBody40.Append(paragraph56);

            shape40.Append(nonVisualShapeProperties40);
            shape40.Append(shapeProperties43);
            shape40.Append(textBody40);

            Shape shape41 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties41 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties55 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties41 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks41 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties41.Append(shapeLocks41);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties55 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape41 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties55.Append(placeholderShape41);

            nonVisualShapeProperties41.Append(nonVisualDrawingProperties55);
            nonVisualShapeProperties41.Append(nonVisualShapeDrawingProperties41);
            nonVisualShapeProperties41.Append(applicationNonVisualDrawingProperties55);

            ShapeProperties shapeProperties44 = new ShapeProperties();

            A.Transform2D transform2D20 = new A.Transform2D();
            A.Offset offset31 = new A.Offset() { X = 629842L, Y = 2505075L };
            A.Extents extents31 = new A.Extents() { Cx = 3868340L, Cy = 3684588L };

            transform2D20.Append(offset31);
            transform2D20.Append(extents31);

            shapeProperties44.Append(transform2D20);

            TextBody textBody41 = new TextBody();
            A.BodyProperties bodyProperties41 = new A.BodyProperties();
            A.ListStyle listStyle41 = new A.ListStyle();

            A.Paragraph paragraph57 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties24 = new A.ParagraphProperties() { Level = 0 };

            A.Run run33 = new A.Run();

            A.RunProperties runProperties49 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties49.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text49 = new A.Text();
            text49.Text = "마스터 텍스트 스타일을 편집합니다";

            run33.Append(runProperties49);
            run33.Append(text49);

            paragraph57.Append(paragraphProperties24);
            paragraph57.Append(run33);

            A.Paragraph paragraph58 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties25 = new A.ParagraphProperties() { Level = 1 };

            A.Run run34 = new A.Run();

            A.RunProperties runProperties50 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties50.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text50 = new A.Text();
            text50.Text = "둘째 수준";

            run34.Append(runProperties50);
            run34.Append(text50);

            paragraph58.Append(paragraphProperties25);
            paragraph58.Append(run34);

            A.Paragraph paragraph59 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties26 = new A.ParagraphProperties() { Level = 2 };

            A.Run run35 = new A.Run();

            A.RunProperties runProperties51 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties51.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text51 = new A.Text();
            text51.Text = "셋째 수준";

            run35.Append(runProperties51);
            run35.Append(text51);

            paragraph59.Append(paragraphProperties26);
            paragraph59.Append(run35);

            A.Paragraph paragraph60 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties27 = new A.ParagraphProperties() { Level = 3 };

            A.Run run36 = new A.Run();

            A.RunProperties runProperties52 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties52.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text52 = new A.Text();
            text52.Text = "넷째 수준";

            run36.Append(runProperties52);
            run36.Append(text52);

            paragraph60.Append(paragraphProperties27);
            paragraph60.Append(run36);

            A.Paragraph paragraph61 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties28 = new A.ParagraphProperties() { Level = 4 };

            A.Run run37 = new A.Run();

            A.RunProperties runProperties53 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties53.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text53 = new A.Text();
            text53.Text = "다섯째 수준";

            run37.Append(runProperties53);
            run37.Append(text53);
            A.EndParagraphRunProperties endParagraphRunProperties38 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph61.Append(paragraphProperties28);
            paragraph61.Append(run37);
            paragraph61.Append(endParagraphRunProperties38);

            textBody41.Append(bodyProperties41);
            textBody41.Append(listStyle41);
            textBody41.Append(paragraph57);
            textBody41.Append(paragraph58);
            textBody41.Append(paragraph59);
            textBody41.Append(paragraph60);
            textBody41.Append(paragraph61);

            shape41.Append(nonVisualShapeProperties41);
            shape41.Append(shapeProperties44);
            shape41.Append(textBody41);

            Shape shape42 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties42 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties56 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Text Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties42 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks42 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties42.Append(shapeLocks42);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties56 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape42 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)3U };

            applicationNonVisualDrawingProperties56.Append(placeholderShape42);

            nonVisualShapeProperties42.Append(nonVisualDrawingProperties56);
            nonVisualShapeProperties42.Append(nonVisualShapeDrawingProperties42);
            nonVisualShapeProperties42.Append(applicationNonVisualDrawingProperties56);

            ShapeProperties shapeProperties45 = new ShapeProperties();

            A.Transform2D transform2D21 = new A.Transform2D();
            A.Offset offset32 = new A.Offset() { X = 4629150L, Y = 1681163L };
            A.Extents extents32 = new A.Extents() { Cx = 3887391L, Cy = 823912L };

            transform2D21.Append(offset32);
            transform2D21.Append(extents32);

            shapeProperties45.Append(transform2D21);

            TextBody textBody42 = new TextBody();
            A.BodyProperties bodyProperties42 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle42 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties16 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet38 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties82 = new A.DefaultRunProperties() { FontSize = 2400, Bold = true };

            level1ParagraphProperties16.Append(noBullet38);
            level1ParagraphProperties16.Append(defaultRunProperties82);

            A.Level2ParagraphProperties level2ParagraphProperties9 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet39 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties83 = new A.DefaultRunProperties() { FontSize = 2000, Bold = true };

            level2ParagraphProperties9.Append(noBullet39);
            level2ParagraphProperties9.Append(defaultRunProperties83);

            A.Level3ParagraphProperties level3ParagraphProperties9 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet40 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties84 = new A.DefaultRunProperties() { FontSize = 1800, Bold = true };

            level3ParagraphProperties9.Append(noBullet40);
            level3ParagraphProperties9.Append(defaultRunProperties84);

            A.Level4ParagraphProperties level4ParagraphProperties9 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet41 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties85 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level4ParagraphProperties9.Append(noBullet41);
            level4ParagraphProperties9.Append(defaultRunProperties85);

            A.Level5ParagraphProperties level5ParagraphProperties9 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet42 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties86 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level5ParagraphProperties9.Append(noBullet42);
            level5ParagraphProperties9.Append(defaultRunProperties86);

            A.Level6ParagraphProperties level6ParagraphProperties9 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet43 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties87 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level6ParagraphProperties9.Append(noBullet43);
            level6ParagraphProperties9.Append(defaultRunProperties87);

            A.Level7ParagraphProperties level7ParagraphProperties9 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet44 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties88 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level7ParagraphProperties9.Append(noBullet44);
            level7ParagraphProperties9.Append(defaultRunProperties88);

            A.Level8ParagraphProperties level8ParagraphProperties9 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet45 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties89 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level8ParagraphProperties9.Append(noBullet45);
            level8ParagraphProperties9.Append(defaultRunProperties89);

            A.Level9ParagraphProperties level9ParagraphProperties9 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet46 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties90 = new A.DefaultRunProperties() { FontSize = 1600, Bold = true };

            level9ParagraphProperties9.Append(noBullet46);
            level9ParagraphProperties9.Append(defaultRunProperties90);

            listStyle42.Append(level1ParagraphProperties16);
            listStyle42.Append(level2ParagraphProperties9);
            listStyle42.Append(level3ParagraphProperties9);
            listStyle42.Append(level4ParagraphProperties9);
            listStyle42.Append(level5ParagraphProperties9);
            listStyle42.Append(level6ParagraphProperties9);
            listStyle42.Append(level7ParagraphProperties9);
            listStyle42.Append(level8ParagraphProperties9);
            listStyle42.Append(level9ParagraphProperties9);

            A.Paragraph paragraph62 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties29 = new A.ParagraphProperties() { Level = 0 };

            A.Run run38 = new A.Run();

            A.RunProperties runProperties54 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties54.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text54 = new A.Text();
            text54.Text = "마스터 텍스트 스타일을 편집합니다";

            run38.Append(runProperties54);
            run38.Append(text54);

            paragraph62.Append(paragraphProperties29);
            paragraph62.Append(run38);

            textBody42.Append(bodyProperties42);
            textBody42.Append(listStyle42);
            textBody42.Append(paragraph62);

            shape42.Append(nonVisualShapeProperties42);
            shape42.Append(shapeProperties45);
            shape42.Append(textBody42);

            Shape shape43 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties43 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties57 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Content Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties43 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks43 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties43.Append(shapeLocks43);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties57 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape43 = new PlaceholderShape() { Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)4U };

            applicationNonVisualDrawingProperties57.Append(placeholderShape43);

            nonVisualShapeProperties43.Append(nonVisualDrawingProperties57);
            nonVisualShapeProperties43.Append(nonVisualShapeDrawingProperties43);
            nonVisualShapeProperties43.Append(applicationNonVisualDrawingProperties57);

            ShapeProperties shapeProperties46 = new ShapeProperties();

            A.Transform2D transform2D22 = new A.Transform2D();
            A.Offset offset33 = new A.Offset() { X = 4629150L, Y = 2505075L };
            A.Extents extents33 = new A.Extents() { Cx = 3887391L, Cy = 3684588L };

            transform2D22.Append(offset33);
            transform2D22.Append(extents33);

            shapeProperties46.Append(transform2D22);

            TextBody textBody43 = new TextBody();
            A.BodyProperties bodyProperties43 = new A.BodyProperties();
            A.ListStyle listStyle43 = new A.ListStyle();

            A.Paragraph paragraph63 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties30 = new A.ParagraphProperties() { Level = 0 };

            A.Run run39 = new A.Run();

            A.RunProperties runProperties55 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties55.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text55 = new A.Text();
            text55.Text = "마스터 텍스트 스타일을 편집합니다";

            run39.Append(runProperties55);
            run39.Append(text55);

            paragraph63.Append(paragraphProperties30);
            paragraph63.Append(run39);

            A.Paragraph paragraph64 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties31 = new A.ParagraphProperties() { Level = 1 };

            A.Run run40 = new A.Run();

            A.RunProperties runProperties56 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties56.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text56 = new A.Text();
            text56.Text = "둘째 수준";

            run40.Append(runProperties56);
            run40.Append(text56);

            paragraph64.Append(paragraphProperties31);
            paragraph64.Append(run40);

            A.Paragraph paragraph65 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties32 = new A.ParagraphProperties() { Level = 2 };

            A.Run run41 = new A.Run();

            A.RunProperties runProperties57 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties57.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text57 = new A.Text();
            text57.Text = "셋째 수준";

            run41.Append(runProperties57);
            run41.Append(text57);

            paragraph65.Append(paragraphProperties32);
            paragraph65.Append(run41);

            A.Paragraph paragraph66 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties33 = new A.ParagraphProperties() { Level = 3 };

            A.Run run42 = new A.Run();

            A.RunProperties runProperties58 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties58.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text58 = new A.Text();
            text58.Text = "넷째 수준";

            run42.Append(runProperties58);
            run42.Append(text58);

            paragraph66.Append(paragraphProperties33);
            paragraph66.Append(run42);

            A.Paragraph paragraph67 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties34 = new A.ParagraphProperties() { Level = 4 };

            A.Run run43 = new A.Run();

            A.RunProperties runProperties59 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties59.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text59 = new A.Text();
            text59.Text = "다섯째 수준";

            run43.Append(runProperties59);
            run43.Append(text59);
            A.EndParagraphRunProperties endParagraphRunProperties39 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph67.Append(paragraphProperties34);
            paragraph67.Append(run43);
            paragraph67.Append(endParagraphRunProperties39);

            textBody43.Append(bodyProperties43);
            textBody43.Append(listStyle43);
            textBody43.Append(paragraph63);
            textBody43.Append(paragraph64);
            textBody43.Append(paragraph65);
            textBody43.Append(paragraph66);
            textBody43.Append(paragraph67);

            shape43.Append(nonVisualShapeProperties43);
            shape43.Append(shapeProperties46);
            shape43.Append(textBody43);

            Shape shape44 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties44 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties58 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Date Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties44 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks44 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties44.Append(shapeLocks44);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties58 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape44 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties58.Append(placeholderShape44);

            nonVisualShapeProperties44.Append(nonVisualDrawingProperties58);
            nonVisualShapeProperties44.Append(nonVisualShapeDrawingProperties44);
            nonVisualShapeProperties44.Append(applicationNonVisualDrawingProperties58);
            ShapeProperties shapeProperties47 = new ShapeProperties();

            TextBody textBody44 = new TextBody();
            A.BodyProperties bodyProperties44 = new A.BodyProperties();
            A.ListStyle listStyle44 = new A.ListStyle();

            A.Paragraph paragraph68 = new A.Paragraph();

            A.Field field17 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties60 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties60.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text60 = new A.Text();
            text60.Text = "2015-03-31";

            field17.Append(runProperties60);
            field17.Append(text60);
            A.EndParagraphRunProperties endParagraphRunProperties40 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph68.Append(field17);
            paragraph68.Append(endParagraphRunProperties40);

            textBody44.Append(bodyProperties44);
            textBody44.Append(listStyle44);
            textBody44.Append(paragraph68);

            shape44.Append(nonVisualShapeProperties44);
            shape44.Append(shapeProperties47);
            shape44.Append(textBody44);

            Shape shape45 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties45 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties59 = new NonVisualDrawingProperties() { Id = (UInt32Value)8U, Name = "Footer Placeholder 7" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties45 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks45 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties45.Append(shapeLocks45);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties59 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape45 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties59.Append(placeholderShape45);

            nonVisualShapeProperties45.Append(nonVisualDrawingProperties59);
            nonVisualShapeProperties45.Append(nonVisualShapeDrawingProperties45);
            nonVisualShapeProperties45.Append(applicationNonVisualDrawingProperties59);
            ShapeProperties shapeProperties48 = new ShapeProperties();

            TextBody textBody45 = new TextBody();
            A.BodyProperties bodyProperties45 = new A.BodyProperties();
            A.ListStyle listStyle45 = new A.ListStyle();

            A.Paragraph paragraph69 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties41 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph69.Append(endParagraphRunProperties41);

            textBody45.Append(bodyProperties45);
            textBody45.Append(listStyle45);
            textBody45.Append(paragraph69);

            shape45.Append(nonVisualShapeProperties45);
            shape45.Append(shapeProperties48);
            shape45.Append(textBody45);

            Shape shape46 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties46 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties60 = new NonVisualDrawingProperties() { Id = (UInt32Value)9U, Name = "Slide Number Placeholder 8" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties46 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks46 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties46.Append(shapeLocks46);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties60 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape46 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties60.Append(placeholderShape46);

            nonVisualShapeProperties46.Append(nonVisualDrawingProperties60);
            nonVisualShapeProperties46.Append(nonVisualShapeDrawingProperties46);
            nonVisualShapeProperties46.Append(applicationNonVisualDrawingProperties60);
            ShapeProperties shapeProperties49 = new ShapeProperties();

            TextBody textBody46 = new TextBody();
            A.BodyProperties bodyProperties46 = new A.BodyProperties();
            A.ListStyle listStyle46 = new A.ListStyle();

            A.Paragraph paragraph70 = new A.Paragraph();

            A.Field field18 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties61 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties61.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text61 = new A.Text();
            text61.Text = "?#?";

            field18.Append(runProperties61);
            field18.Append(text61);
            A.EndParagraphRunProperties endParagraphRunProperties42 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph70.Append(field18);
            paragraph70.Append(endParagraphRunProperties42);

            textBody46.Append(bodyProperties46);
            textBody46.Append(listStyle46);
            textBody46.Append(paragraph70);

            shape46.Append(nonVisualShapeProperties46);
            shape46.Append(shapeProperties49);
            shape46.Append(textBody46);

            shapeTree10.Append(nonVisualGroupShapeProperties11);
            shapeTree10.Append(groupShapeProperties11);
            shapeTree10.Append(shape39);
            shapeTree10.Append(shape40);
            shapeTree10.Append(shape41);
            shapeTree10.Append(shape42);
            shapeTree10.Append(shape43);
            shapeTree10.Append(shape44);
            shapeTree10.Append(shape45);
            shapeTree10.Append(shape46);

            CommonSlideDataExtensionList commonSlideDataExtensionList10 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension10 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId10 = new P14.CreationId() { Val = (UInt32Value)3529694141U };
            creationId10.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension10.Append(creationId10);

            commonSlideDataExtensionList10.Append(commonSlideDataExtension10);

            commonSlideData10.Append(shapeTree10);
            commonSlideData10.Append(commonSlideDataExtensionList10);

            ColorMapOverride colorMapOverride9 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping9 = new A.MasterColorMapping();

            colorMapOverride9.Append(masterColorMapping9);

            slideLayout8.Append(commonSlideData10);
            slideLayout8.Append(colorMapOverride9);

            slideLayoutPart8.SlideLayout = slideLayout8;
        }

        // Generates content of slideLayoutPart9.
        private void GenerateSlideLayoutPart9Content(SlideLayoutPart slideLayoutPart9)
        {
            SlideLayout slideLayout9 = new SlideLayout() { Type = SlideLayoutValues.VerticalText, Preserve = true };
            slideLayout9.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout9.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout9.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData11 = new CommonSlideData() { Name = "제목 및 세로 텍스트" };

            ShapeTree shapeTree11 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties12 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties61 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties12 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties61 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties12.Append(nonVisualDrawingProperties61);
            nonVisualGroupShapeProperties12.Append(nonVisualGroupShapeDrawingProperties12);
            nonVisualGroupShapeProperties12.Append(applicationNonVisualDrawingProperties61);

            GroupShapeProperties groupShapeProperties12 = new GroupShapeProperties();

            A.TransformGroup transformGroup12 = new A.TransformGroup();
            A.Offset offset34 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents34 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset12 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents12 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup12.Append(offset34);
            transformGroup12.Append(extents34);
            transformGroup12.Append(childOffset12);
            transformGroup12.Append(childExtents12);

            groupShapeProperties12.Append(transformGroup12);

            Shape shape47 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties47 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties62 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties47 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks47 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties47.Append(shapeLocks47);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties62 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape47 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties62.Append(placeholderShape47);

            nonVisualShapeProperties47.Append(nonVisualDrawingProperties62);
            nonVisualShapeProperties47.Append(nonVisualShapeDrawingProperties47);
            nonVisualShapeProperties47.Append(applicationNonVisualDrawingProperties62);
            ShapeProperties shapeProperties50 = new ShapeProperties();

            TextBody textBody47 = new TextBody();
            A.BodyProperties bodyProperties47 = new A.BodyProperties();
            A.ListStyle listStyle47 = new A.ListStyle();

            A.Paragraph paragraph71 = new A.Paragraph();

            A.Run run44 = new A.Run();

            A.RunProperties runProperties62 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties62.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text62 = new A.Text();
            text62.Text = "마스터 제목 스타일 편집";

            run44.Append(runProperties62);
            run44.Append(text62);
            A.EndParagraphRunProperties endParagraphRunProperties43 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph71.Append(run44);
            paragraph71.Append(endParagraphRunProperties43);

            textBody47.Append(bodyProperties47);
            textBody47.Append(listStyle47);
            textBody47.Append(paragraph71);

            shape47.Append(nonVisualShapeProperties47);
            shape47.Append(shapeProperties50);
            shape47.Append(textBody47);

            Shape shape48 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties48 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties63 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Vertical Text Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties48 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks48 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties48.Append(shapeLocks48);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties63 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape48 = new PlaceholderShape() { Type = PlaceholderValues.Body, Orientation = DirectionValues.Vertical, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties63.Append(placeholderShape48);

            nonVisualShapeProperties48.Append(nonVisualDrawingProperties63);
            nonVisualShapeProperties48.Append(nonVisualShapeDrawingProperties48);
            nonVisualShapeProperties48.Append(applicationNonVisualDrawingProperties63);
            ShapeProperties shapeProperties51 = new ShapeProperties();

            TextBody textBody48 = new TextBody();
            A.BodyProperties bodyProperties48 = new A.BodyProperties() { Vertical = A.TextVerticalValues.EastAsianVetical };
            A.ListStyle listStyle48 = new A.ListStyle();

            A.Paragraph paragraph72 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties35 = new A.ParagraphProperties() { Level = 0 };

            A.Run run45 = new A.Run();

            A.RunProperties runProperties63 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties63.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text63 = new A.Text();
            text63.Text = "마스터 텍스트 스타일을 편집합니다";

            run45.Append(runProperties63);
            run45.Append(text63);

            paragraph72.Append(paragraphProperties35);
            paragraph72.Append(run45);

            A.Paragraph paragraph73 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties36 = new A.ParagraphProperties() { Level = 1 };

            A.Run run46 = new A.Run();

            A.RunProperties runProperties64 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties64.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text64 = new A.Text();
            text64.Text = "둘째 수준";

            run46.Append(runProperties64);
            run46.Append(text64);

            paragraph73.Append(paragraphProperties36);
            paragraph73.Append(run46);

            A.Paragraph paragraph74 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties37 = new A.ParagraphProperties() { Level = 2 };

            A.Run run47 = new A.Run();

            A.RunProperties runProperties65 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties65.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text65 = new A.Text();
            text65.Text = "셋째 수준";

            run47.Append(runProperties65);
            run47.Append(text65);

            paragraph74.Append(paragraphProperties37);
            paragraph74.Append(run47);

            A.Paragraph paragraph75 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties38 = new A.ParagraphProperties() { Level = 3 };

            A.Run run48 = new A.Run();

            A.RunProperties runProperties66 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties66.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text66 = new A.Text();
            text66.Text = "넷째 수준";

            run48.Append(runProperties66);
            run48.Append(text66);

            paragraph75.Append(paragraphProperties38);
            paragraph75.Append(run48);

            A.Paragraph paragraph76 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties39 = new A.ParagraphProperties() { Level = 4 };

            A.Run run49 = new A.Run();

            A.RunProperties runProperties67 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties67.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text67 = new A.Text();
            text67.Text = "다섯째 수준";

            run49.Append(runProperties67);
            run49.Append(text67);
            A.EndParagraphRunProperties endParagraphRunProperties44 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph76.Append(paragraphProperties39);
            paragraph76.Append(run49);
            paragraph76.Append(endParagraphRunProperties44);

            textBody48.Append(bodyProperties48);
            textBody48.Append(listStyle48);
            textBody48.Append(paragraph72);
            textBody48.Append(paragraph73);
            textBody48.Append(paragraph74);
            textBody48.Append(paragraph75);
            textBody48.Append(paragraph76);

            shape48.Append(nonVisualShapeProperties48);
            shape48.Append(shapeProperties51);
            shape48.Append(textBody48);

            Shape shape49 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties49 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties64 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Date Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties49 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks49 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties49.Append(shapeLocks49);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties64 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape49 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties64.Append(placeholderShape49);

            nonVisualShapeProperties49.Append(nonVisualDrawingProperties64);
            nonVisualShapeProperties49.Append(nonVisualShapeDrawingProperties49);
            nonVisualShapeProperties49.Append(applicationNonVisualDrawingProperties64);
            ShapeProperties shapeProperties52 = new ShapeProperties();

            TextBody textBody49 = new TextBody();
            A.BodyProperties bodyProperties49 = new A.BodyProperties();
            A.ListStyle listStyle49 = new A.ListStyle();

            A.Paragraph paragraph77 = new A.Paragraph();

            A.Field field19 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties68 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties68.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text68 = new A.Text();
            text68.Text = "2015-03-31";

            field19.Append(runProperties68);
            field19.Append(text68);
            A.EndParagraphRunProperties endParagraphRunProperties45 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph77.Append(field19);
            paragraph77.Append(endParagraphRunProperties45);

            textBody49.Append(bodyProperties49);
            textBody49.Append(listStyle49);
            textBody49.Append(paragraph77);

            shape49.Append(nonVisualShapeProperties49);
            shape49.Append(shapeProperties52);
            shape49.Append(textBody49);

            Shape shape50 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties50 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties65 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Footer Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties50 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks50 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties50.Append(shapeLocks50);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties65 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape50 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties65.Append(placeholderShape50);

            nonVisualShapeProperties50.Append(nonVisualDrawingProperties65);
            nonVisualShapeProperties50.Append(nonVisualShapeDrawingProperties50);
            nonVisualShapeProperties50.Append(applicationNonVisualDrawingProperties65);
            ShapeProperties shapeProperties53 = new ShapeProperties();

            TextBody textBody50 = new TextBody();
            A.BodyProperties bodyProperties50 = new A.BodyProperties();
            A.ListStyle listStyle50 = new A.ListStyle();

            A.Paragraph paragraph78 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties46 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph78.Append(endParagraphRunProperties46);

            textBody50.Append(bodyProperties50);
            textBody50.Append(listStyle50);
            textBody50.Append(paragraph78);

            shape50.Append(nonVisualShapeProperties50);
            shape50.Append(shapeProperties53);
            shape50.Append(textBody50);

            Shape shape51 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties51 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties66 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Slide Number Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties51 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks51 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties51.Append(shapeLocks51);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties66 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape51 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties66.Append(placeholderShape51);

            nonVisualShapeProperties51.Append(nonVisualDrawingProperties66);
            nonVisualShapeProperties51.Append(nonVisualShapeDrawingProperties51);
            nonVisualShapeProperties51.Append(applicationNonVisualDrawingProperties66);
            ShapeProperties shapeProperties54 = new ShapeProperties();

            TextBody textBody51 = new TextBody();
            A.BodyProperties bodyProperties51 = new A.BodyProperties();
            A.ListStyle listStyle51 = new A.ListStyle();

            A.Paragraph paragraph79 = new A.Paragraph();

            A.Field field20 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties69 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties69.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text69 = new A.Text();
            text69.Text = "?#?";

            field20.Append(runProperties69);
            field20.Append(text69);
            A.EndParagraphRunProperties endParagraphRunProperties47 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph79.Append(field20);
            paragraph79.Append(endParagraphRunProperties47);

            textBody51.Append(bodyProperties51);
            textBody51.Append(listStyle51);
            textBody51.Append(paragraph79);

            shape51.Append(nonVisualShapeProperties51);
            shape51.Append(shapeProperties54);
            shape51.Append(textBody51);

            shapeTree11.Append(nonVisualGroupShapeProperties12);
            shapeTree11.Append(groupShapeProperties12);
            shapeTree11.Append(shape47);
            shapeTree11.Append(shape48);
            shapeTree11.Append(shape49);
            shapeTree11.Append(shape50);
            shapeTree11.Append(shape51);

            CommonSlideDataExtensionList commonSlideDataExtensionList11 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension11 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId11 = new P14.CreationId() { Val = (UInt32Value)754929581U };
            creationId11.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension11.Append(creationId11);

            commonSlideDataExtensionList11.Append(commonSlideDataExtension11);

            commonSlideData11.Append(shapeTree11);
            commonSlideData11.Append(commonSlideDataExtensionList11);

            ColorMapOverride colorMapOverride10 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping10 = new A.MasterColorMapping();

            colorMapOverride10.Append(masterColorMapping10);

            slideLayout9.Append(commonSlideData11);
            slideLayout9.Append(colorMapOverride10);

            slideLayoutPart9.SlideLayout = slideLayout9;
        }

        // Generates content of slideLayoutPart10.
        private void GenerateSlideLayoutPart10Content(SlideLayoutPart slideLayoutPart10)
        {
            SlideLayout slideLayout10 = new SlideLayout() { Type = SlideLayoutValues.TwoObjects, Preserve = true };
            slideLayout10.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout10.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout10.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData12 = new CommonSlideData() { Name = "콘텐츠 2개" };

            ShapeTree shapeTree12 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties13 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties67 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties13 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties67 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties13.Append(nonVisualDrawingProperties67);
            nonVisualGroupShapeProperties13.Append(nonVisualGroupShapeDrawingProperties13);
            nonVisualGroupShapeProperties13.Append(applicationNonVisualDrawingProperties67);

            GroupShapeProperties groupShapeProperties13 = new GroupShapeProperties();

            A.TransformGroup transformGroup13 = new A.TransformGroup();
            A.Offset offset35 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents35 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset13 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents13 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup13.Append(offset35);
            transformGroup13.Append(extents35);
            transformGroup13.Append(childOffset13);
            transformGroup13.Append(childExtents13);

            groupShapeProperties13.Append(transformGroup13);

            Shape shape52 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties52 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties68 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties52 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks52 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties52.Append(shapeLocks52);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties68 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape52 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties68.Append(placeholderShape52);

            nonVisualShapeProperties52.Append(nonVisualDrawingProperties68);
            nonVisualShapeProperties52.Append(nonVisualShapeDrawingProperties52);
            nonVisualShapeProperties52.Append(applicationNonVisualDrawingProperties68);
            ShapeProperties shapeProperties55 = new ShapeProperties();

            TextBody textBody52 = new TextBody();
            A.BodyProperties bodyProperties52 = new A.BodyProperties();
            A.ListStyle listStyle52 = new A.ListStyle();

            A.Paragraph paragraph80 = new A.Paragraph();

            A.Run run50 = new A.Run();

            A.RunProperties runProperties70 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties70.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text70 = new A.Text();
            text70.Text = "마스터 제목 스타일 편집";

            run50.Append(runProperties70);
            run50.Append(text70);
            A.EndParagraphRunProperties endParagraphRunProperties48 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph80.Append(run50);
            paragraph80.Append(endParagraphRunProperties48);

            textBody52.Append(bodyProperties52);
            textBody52.Append(listStyle52);
            textBody52.Append(paragraph80);

            shape52.Append(nonVisualShapeProperties52);
            shape52.Append(shapeProperties55);
            shape52.Append(textBody52);

            Shape shape53 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties53 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties69 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Content Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties53 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks53 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties53.Append(shapeLocks53);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties69 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape53 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties69.Append(placeholderShape53);

            nonVisualShapeProperties53.Append(nonVisualDrawingProperties69);
            nonVisualShapeProperties53.Append(nonVisualShapeDrawingProperties53);
            nonVisualShapeProperties53.Append(applicationNonVisualDrawingProperties69);

            ShapeProperties shapeProperties56 = new ShapeProperties();

            A.Transform2D transform2D23 = new A.Transform2D();
            A.Offset offset36 = new A.Offset() { X = 628650L, Y = 1825625L };
            A.Extents extents36 = new A.Extents() { Cx = 3886200L, Cy = 4351338L };

            transform2D23.Append(offset36);
            transform2D23.Append(extents36);

            shapeProperties56.Append(transform2D23);

            TextBody textBody53 = new TextBody();
            A.BodyProperties bodyProperties53 = new A.BodyProperties();
            A.ListStyle listStyle53 = new A.ListStyle();

            A.Paragraph paragraph81 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties40 = new A.ParagraphProperties() { Level = 0 };

            A.Run run51 = new A.Run();

            A.RunProperties runProperties71 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties71.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text71 = new A.Text();
            text71.Text = "마스터 텍스트 스타일을 편집합니다";

            run51.Append(runProperties71);
            run51.Append(text71);

            paragraph81.Append(paragraphProperties40);
            paragraph81.Append(run51);

            A.Paragraph paragraph82 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties41 = new A.ParagraphProperties() { Level = 1 };

            A.Run run52 = new A.Run();

            A.RunProperties runProperties72 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties72.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text72 = new A.Text();
            text72.Text = "둘째 수준";

            run52.Append(runProperties72);
            run52.Append(text72);

            paragraph82.Append(paragraphProperties41);
            paragraph82.Append(run52);

            A.Paragraph paragraph83 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties42 = new A.ParagraphProperties() { Level = 2 };

            A.Run run53 = new A.Run();

            A.RunProperties runProperties73 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties73.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text73 = new A.Text();
            text73.Text = "셋째 수준";

            run53.Append(runProperties73);
            run53.Append(text73);

            paragraph83.Append(paragraphProperties42);
            paragraph83.Append(run53);

            A.Paragraph paragraph84 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties43 = new A.ParagraphProperties() { Level = 3 };

            A.Run run54 = new A.Run();

            A.RunProperties runProperties74 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties74.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text74 = new A.Text();
            text74.Text = "넷째 수준";

            run54.Append(runProperties74);
            run54.Append(text74);

            paragraph84.Append(paragraphProperties43);
            paragraph84.Append(run54);

            A.Paragraph paragraph85 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties44 = new A.ParagraphProperties() { Level = 4 };

            A.Run run55 = new A.Run();

            A.RunProperties runProperties75 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties75.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text75 = new A.Text();
            text75.Text = "다섯째 수준";

            run55.Append(runProperties75);
            run55.Append(text75);
            A.EndParagraphRunProperties endParagraphRunProperties49 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph85.Append(paragraphProperties44);
            paragraph85.Append(run55);
            paragraph85.Append(endParagraphRunProperties49);

            textBody53.Append(bodyProperties53);
            textBody53.Append(listStyle53);
            textBody53.Append(paragraph81);
            textBody53.Append(paragraph82);
            textBody53.Append(paragraph83);
            textBody53.Append(paragraph84);
            textBody53.Append(paragraph85);

            shape53.Append(nonVisualShapeProperties53);
            shape53.Append(shapeProperties56);
            shape53.Append(textBody53);

            Shape shape54 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties54 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties70 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Content Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties54 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks54 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties54.Append(shapeLocks54);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties70 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape54 = new PlaceholderShape() { Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties70.Append(placeholderShape54);

            nonVisualShapeProperties54.Append(nonVisualDrawingProperties70);
            nonVisualShapeProperties54.Append(nonVisualShapeDrawingProperties54);
            nonVisualShapeProperties54.Append(applicationNonVisualDrawingProperties70);

            ShapeProperties shapeProperties57 = new ShapeProperties();

            A.Transform2D transform2D24 = new A.Transform2D();
            A.Offset offset37 = new A.Offset() { X = 4629150L, Y = 1825625L };
            A.Extents extents37 = new A.Extents() { Cx = 3886200L, Cy = 4351338L };

            transform2D24.Append(offset37);
            transform2D24.Append(extents37);

            shapeProperties57.Append(transform2D24);

            TextBody textBody54 = new TextBody();
            A.BodyProperties bodyProperties54 = new A.BodyProperties();
            A.ListStyle listStyle54 = new A.ListStyle();

            A.Paragraph paragraph86 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties45 = new A.ParagraphProperties() { Level = 0 };

            A.Run run56 = new A.Run();

            A.RunProperties runProperties76 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties76.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text76 = new A.Text();
            text76.Text = "마스터 텍스트 스타일을 편집합니다";

            run56.Append(runProperties76);
            run56.Append(text76);

            paragraph86.Append(paragraphProperties45);
            paragraph86.Append(run56);

            A.Paragraph paragraph87 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties46 = new A.ParagraphProperties() { Level = 1 };

            A.Run run57 = new A.Run();

            A.RunProperties runProperties77 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties77.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text77 = new A.Text();
            text77.Text = "둘째 수준";

            run57.Append(runProperties77);
            run57.Append(text77);

            paragraph87.Append(paragraphProperties46);
            paragraph87.Append(run57);

            A.Paragraph paragraph88 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties47 = new A.ParagraphProperties() { Level = 2 };

            A.Run run58 = new A.Run();

            A.RunProperties runProperties78 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties78.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text78 = new A.Text();
            text78.Text = "셋째 수준";

            run58.Append(runProperties78);
            run58.Append(text78);

            paragraph88.Append(paragraphProperties47);
            paragraph88.Append(run58);

            A.Paragraph paragraph89 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties48 = new A.ParagraphProperties() { Level = 3 };

            A.Run run59 = new A.Run();

            A.RunProperties runProperties79 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties79.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text79 = new A.Text();
            text79.Text = "넷째 수준";

            run59.Append(runProperties79);
            run59.Append(text79);

            paragraph89.Append(paragraphProperties48);
            paragraph89.Append(run59);

            A.Paragraph paragraph90 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties49 = new A.ParagraphProperties() { Level = 4 };

            A.Run run60 = new A.Run();

            A.RunProperties runProperties80 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties80.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text80 = new A.Text();
            text80.Text = "다섯째 수준";

            run60.Append(runProperties80);
            run60.Append(text80);
            A.EndParagraphRunProperties endParagraphRunProperties50 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph90.Append(paragraphProperties49);
            paragraph90.Append(run60);
            paragraph90.Append(endParagraphRunProperties50);

            textBody54.Append(bodyProperties54);
            textBody54.Append(listStyle54);
            textBody54.Append(paragraph86);
            textBody54.Append(paragraph87);
            textBody54.Append(paragraph88);
            textBody54.Append(paragraph89);
            textBody54.Append(paragraph90);

            shape54.Append(nonVisualShapeProperties54);
            shape54.Append(shapeProperties57);
            shape54.Append(textBody54);

            Shape shape55 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties55 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties71 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties55 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks55 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties55.Append(shapeLocks55);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties71 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape55 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties71.Append(placeholderShape55);

            nonVisualShapeProperties55.Append(nonVisualDrawingProperties71);
            nonVisualShapeProperties55.Append(nonVisualShapeDrawingProperties55);
            nonVisualShapeProperties55.Append(applicationNonVisualDrawingProperties71);
            ShapeProperties shapeProperties58 = new ShapeProperties();

            TextBody textBody55 = new TextBody();
            A.BodyProperties bodyProperties55 = new A.BodyProperties();
            A.ListStyle listStyle55 = new A.ListStyle();

            A.Paragraph paragraph91 = new A.Paragraph();

            A.Field field21 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties81 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties81.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text81 = new A.Text();
            text81.Text = "2015-03-31";

            field21.Append(runProperties81);
            field21.Append(text81);
            A.EndParagraphRunProperties endParagraphRunProperties51 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph91.Append(field21);
            paragraph91.Append(endParagraphRunProperties51);

            textBody55.Append(bodyProperties55);
            textBody55.Append(listStyle55);
            textBody55.Append(paragraph91);

            shape55.Append(nonVisualShapeProperties55);
            shape55.Append(shapeProperties58);
            shape55.Append(textBody55);

            Shape shape56 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties56 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties72 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties56 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks56 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties56.Append(shapeLocks56);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties72 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape56 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties72.Append(placeholderShape56);

            nonVisualShapeProperties56.Append(nonVisualDrawingProperties72);
            nonVisualShapeProperties56.Append(nonVisualShapeDrawingProperties56);
            nonVisualShapeProperties56.Append(applicationNonVisualDrawingProperties72);
            ShapeProperties shapeProperties59 = new ShapeProperties();

            TextBody textBody56 = new TextBody();
            A.BodyProperties bodyProperties56 = new A.BodyProperties();
            A.ListStyle listStyle56 = new A.ListStyle();

            A.Paragraph paragraph92 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties52 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph92.Append(endParagraphRunProperties52);

            textBody56.Append(bodyProperties56);
            textBody56.Append(listStyle56);
            textBody56.Append(paragraph92);

            shape56.Append(nonVisualShapeProperties56);
            shape56.Append(shapeProperties59);
            shape56.Append(textBody56);

            Shape shape57 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties57 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties73 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties57 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks57 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties57.Append(shapeLocks57);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties73 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape57 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties73.Append(placeholderShape57);

            nonVisualShapeProperties57.Append(nonVisualDrawingProperties73);
            nonVisualShapeProperties57.Append(nonVisualShapeDrawingProperties57);
            nonVisualShapeProperties57.Append(applicationNonVisualDrawingProperties73);
            ShapeProperties shapeProperties60 = new ShapeProperties();

            TextBody textBody57 = new TextBody();
            A.BodyProperties bodyProperties57 = new A.BodyProperties();
            A.ListStyle listStyle57 = new A.ListStyle();

            A.Paragraph paragraph93 = new A.Paragraph();

            A.Field field22 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties82 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties82.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text82 = new A.Text();
            text82.Text = "?#?";

            field22.Append(runProperties82);
            field22.Append(text82);
            A.EndParagraphRunProperties endParagraphRunProperties53 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph93.Append(field22);
            paragraph93.Append(endParagraphRunProperties53);

            textBody57.Append(bodyProperties57);
            textBody57.Append(listStyle57);
            textBody57.Append(paragraph93);

            shape57.Append(nonVisualShapeProperties57);
            shape57.Append(shapeProperties60);
            shape57.Append(textBody57);

            shapeTree12.Append(nonVisualGroupShapeProperties13);
            shapeTree12.Append(groupShapeProperties13);
            shapeTree12.Append(shape52);
            shapeTree12.Append(shape53);
            shapeTree12.Append(shape54);
            shapeTree12.Append(shape55);
            shapeTree12.Append(shape56);
            shapeTree12.Append(shape57);

            CommonSlideDataExtensionList commonSlideDataExtensionList12 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension12 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId12 = new P14.CreationId() { Val = (UInt32Value)3171296169U };
            creationId12.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension12.Append(creationId12);

            commonSlideDataExtensionList12.Append(commonSlideDataExtension12);

            commonSlideData12.Append(shapeTree12);
            commonSlideData12.Append(commonSlideDataExtensionList12);

            ColorMapOverride colorMapOverride11 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping11 = new A.MasterColorMapping();

            colorMapOverride11.Append(masterColorMapping11);

            slideLayout10.Append(commonSlideData12);
            slideLayout10.Append(colorMapOverride11);

            slideLayoutPart10.SlideLayout = slideLayout10;
        }

        // Generates content of slideLayoutPart11.
        private void GenerateSlideLayoutPart11Content(SlideLayoutPart slideLayoutPart11)
        {
            SlideLayout slideLayout11 = new SlideLayout() { Type = SlideLayoutValues.PictureText, Preserve = true };
            slideLayout11.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            slideLayout11.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            slideLayout11.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            CommonSlideData commonSlideData13 = new CommonSlideData() { Name = "캡션 있는 그림" };

            ShapeTree shapeTree13 = new ShapeTree();

            NonVisualGroupShapeProperties nonVisualGroupShapeProperties14 = new NonVisualGroupShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties74 = new NonVisualDrawingProperties() { Id = (UInt32Value)1U, Name = "" };
            NonVisualGroupShapeDrawingProperties nonVisualGroupShapeDrawingProperties14 = new NonVisualGroupShapeDrawingProperties();
            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties74 = new ApplicationNonVisualDrawingProperties();

            nonVisualGroupShapeProperties14.Append(nonVisualDrawingProperties74);
            nonVisualGroupShapeProperties14.Append(nonVisualGroupShapeDrawingProperties14);
            nonVisualGroupShapeProperties14.Append(applicationNonVisualDrawingProperties74);

            GroupShapeProperties groupShapeProperties14 = new GroupShapeProperties();

            A.TransformGroup transformGroup14 = new A.TransformGroup();
            A.Offset offset38 = new A.Offset() { X = 0L, Y = 0L };
            A.Extents extents38 = new A.Extents() { Cx = 0L, Cy = 0L };
            A.ChildOffset childOffset14 = new A.ChildOffset() { X = 0L, Y = 0L };
            A.ChildExtents childExtents14 = new A.ChildExtents() { Cx = 0L, Cy = 0L };

            transformGroup14.Append(offset38);
            transformGroup14.Append(extents38);
            transformGroup14.Append(childOffset14);
            transformGroup14.Append(childExtents14);

            groupShapeProperties14.Append(transformGroup14);

            Shape shape58 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties58 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties75 = new NonVisualDrawingProperties() { Id = (UInt32Value)2U, Name = "Title 1" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties58 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks58 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties58.Append(shapeLocks58);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties75 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape58 = new PlaceholderShape() { Type = PlaceholderValues.Title };

            applicationNonVisualDrawingProperties75.Append(placeholderShape58);

            nonVisualShapeProperties58.Append(nonVisualDrawingProperties75);
            nonVisualShapeProperties58.Append(nonVisualShapeDrawingProperties58);
            nonVisualShapeProperties58.Append(applicationNonVisualDrawingProperties75);

            ShapeProperties shapeProperties61 = new ShapeProperties();

            A.Transform2D transform2D25 = new A.Transform2D();
            A.Offset offset39 = new A.Offset() { X = 629841L, Y = 457200L };
            A.Extents extents39 = new A.Extents() { Cx = 2949178L, Cy = 1600200L };

            transform2D25.Append(offset39);
            transform2D25.Append(extents39);

            shapeProperties61.Append(transform2D25);

            TextBody textBody58 = new TextBody();
            A.BodyProperties bodyProperties58 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Bottom };

            A.ListStyle listStyle58 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties17 = new A.Level1ParagraphProperties();
            A.DefaultRunProperties defaultRunProperties91 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties17.Append(defaultRunProperties91);

            listStyle58.Append(level1ParagraphProperties17);

            A.Paragraph paragraph94 = new A.Paragraph();

            A.Run run61 = new A.Run();

            A.RunProperties runProperties83 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties83.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text83 = new A.Text();
            text83.Text = "마스터 제목 스타일 편집";

            run61.Append(runProperties83);
            run61.Append(text83);
            A.EndParagraphRunProperties endParagraphRunProperties54 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph94.Append(run61);
            paragraph94.Append(endParagraphRunProperties54);

            textBody58.Append(bodyProperties58);
            textBody58.Append(listStyle58);
            textBody58.Append(paragraph94);

            shape58.Append(nonVisualShapeProperties58);
            shape58.Append(shapeProperties61);
            shape58.Append(textBody58);

            Shape shape59 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties59 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties76 = new NonVisualDrawingProperties() { Id = (UInt32Value)3U, Name = "Picture Placeholder 2" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties59 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks59 = new A.ShapeLocks() { NoGrouping = true, NoChangeAspect = true };

            nonVisualShapeDrawingProperties59.Append(shapeLocks59);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties76 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape59 = new PlaceholderShape() { Type = PlaceholderValues.Picture, Index = (UInt32Value)1U };

            applicationNonVisualDrawingProperties76.Append(placeholderShape59);

            nonVisualShapeProperties59.Append(nonVisualDrawingProperties76);
            nonVisualShapeProperties59.Append(nonVisualShapeDrawingProperties59);
            nonVisualShapeProperties59.Append(applicationNonVisualDrawingProperties76);

            ShapeProperties shapeProperties62 = new ShapeProperties();

            A.Transform2D transform2D26 = new A.Transform2D();
            A.Offset offset40 = new A.Offset() { X = 3887391L, Y = 987426L };
            A.Extents extents40 = new A.Extents() { Cx = 4629150L, Cy = 4873625L };

            transform2D26.Append(offset40);
            transform2D26.Append(extents40);

            shapeProperties62.Append(transform2D26);

            TextBody textBody59 = new TextBody();
            A.BodyProperties bodyProperties59 = new A.BodyProperties() { Anchor = A.TextAnchoringTypeValues.Top };

            A.ListStyle listStyle59 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties18 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet47 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties92 = new A.DefaultRunProperties() { FontSize = 3200 };

            level1ParagraphProperties18.Append(noBullet47);
            level1ParagraphProperties18.Append(defaultRunProperties92);

            A.Level2ParagraphProperties level2ParagraphProperties10 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet48 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties93 = new A.DefaultRunProperties() { FontSize = 2800 };

            level2ParagraphProperties10.Append(noBullet48);
            level2ParagraphProperties10.Append(defaultRunProperties93);

            A.Level3ParagraphProperties level3ParagraphProperties10 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet49 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties94 = new A.DefaultRunProperties() { FontSize = 2400 };

            level3ParagraphProperties10.Append(noBullet49);
            level3ParagraphProperties10.Append(defaultRunProperties94);

            A.Level4ParagraphProperties level4ParagraphProperties10 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet50 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties95 = new A.DefaultRunProperties() { FontSize = 2000 };

            level4ParagraphProperties10.Append(noBullet50);
            level4ParagraphProperties10.Append(defaultRunProperties95);

            A.Level5ParagraphProperties level5ParagraphProperties10 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet51 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties96 = new A.DefaultRunProperties() { FontSize = 2000 };

            level5ParagraphProperties10.Append(noBullet51);
            level5ParagraphProperties10.Append(defaultRunProperties96);

            A.Level6ParagraphProperties level6ParagraphProperties10 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet52 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties97 = new A.DefaultRunProperties() { FontSize = 2000 };

            level6ParagraphProperties10.Append(noBullet52);
            level6ParagraphProperties10.Append(defaultRunProperties97);

            A.Level7ParagraphProperties level7ParagraphProperties10 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet53 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties98 = new A.DefaultRunProperties() { FontSize = 2000 };

            level7ParagraphProperties10.Append(noBullet53);
            level7ParagraphProperties10.Append(defaultRunProperties98);

            A.Level8ParagraphProperties level8ParagraphProperties10 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet54 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties99 = new A.DefaultRunProperties() { FontSize = 2000 };

            level8ParagraphProperties10.Append(noBullet54);
            level8ParagraphProperties10.Append(defaultRunProperties99);

            A.Level9ParagraphProperties level9ParagraphProperties10 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet55 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties100 = new A.DefaultRunProperties() { FontSize = 2000 };

            level9ParagraphProperties10.Append(noBullet55);
            level9ParagraphProperties10.Append(defaultRunProperties100);

            listStyle59.Append(level1ParagraphProperties18);
            listStyle59.Append(level2ParagraphProperties10);
            listStyle59.Append(level3ParagraphProperties10);
            listStyle59.Append(level4ParagraphProperties10);
            listStyle59.Append(level5ParagraphProperties10);
            listStyle59.Append(level6ParagraphProperties10);
            listStyle59.Append(level7ParagraphProperties10);
            listStyle59.Append(level8ParagraphProperties10);
            listStyle59.Append(level9ParagraphProperties10);

            A.Paragraph paragraph95 = new A.Paragraph();

            A.Run run62 = new A.Run();

            A.RunProperties runProperties84 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties84.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text84 = new A.Text();
            text84.Text = "그림을 추가하려면 아이콘을 클릭하십시오";

            run62.Append(runProperties84);
            run62.Append(text84);
            A.EndParagraphRunProperties endParagraphRunProperties55 = new A.EndParagraphRunProperties() { Language = "en-US", Dirty = false };

            paragraph95.Append(run62);
            paragraph95.Append(endParagraphRunProperties55);

            textBody59.Append(bodyProperties59);
            textBody59.Append(listStyle59);
            textBody59.Append(paragraph95);

            shape59.Append(nonVisualShapeProperties59);
            shape59.Append(shapeProperties62);
            shape59.Append(textBody59);

            Shape shape60 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties60 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties77 = new NonVisualDrawingProperties() { Id = (UInt32Value)4U, Name = "Text Placeholder 3" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties60 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks60 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties60.Append(shapeLocks60);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties77 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape60 = new PlaceholderShape() { Type = PlaceholderValues.Body, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)2U };

            applicationNonVisualDrawingProperties77.Append(placeholderShape60);

            nonVisualShapeProperties60.Append(nonVisualDrawingProperties77);
            nonVisualShapeProperties60.Append(nonVisualShapeDrawingProperties60);
            nonVisualShapeProperties60.Append(applicationNonVisualDrawingProperties77);

            ShapeProperties shapeProperties63 = new ShapeProperties();

            A.Transform2D transform2D27 = new A.Transform2D();
            A.Offset offset41 = new A.Offset() { X = 629841L, Y = 2057400L };
            A.Extents extents41 = new A.Extents() { Cx = 2949178L, Cy = 3811588L };

            transform2D27.Append(offset41);
            transform2D27.Append(extents41);

            shapeProperties63.Append(transform2D27);

            TextBody textBody60 = new TextBody();
            A.BodyProperties bodyProperties60 = new A.BodyProperties();

            A.ListStyle listStyle60 = new A.ListStyle();

            A.Level1ParagraphProperties level1ParagraphProperties19 = new A.Level1ParagraphProperties() { LeftMargin = 0, Indent = 0 };
            A.NoBullet noBullet56 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties101 = new A.DefaultRunProperties() { FontSize = 1600 };

            level1ParagraphProperties19.Append(noBullet56);
            level1ParagraphProperties19.Append(defaultRunProperties101);

            A.Level2ParagraphProperties level2ParagraphProperties11 = new A.Level2ParagraphProperties() { LeftMargin = 457200, Indent = 0 };
            A.NoBullet noBullet57 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties102 = new A.DefaultRunProperties() { FontSize = 1400 };

            level2ParagraphProperties11.Append(noBullet57);
            level2ParagraphProperties11.Append(defaultRunProperties102);

            A.Level3ParagraphProperties level3ParagraphProperties11 = new A.Level3ParagraphProperties() { LeftMargin = 914400, Indent = 0 };
            A.NoBullet noBullet58 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties103 = new A.DefaultRunProperties() { FontSize = 1200 };

            level3ParagraphProperties11.Append(noBullet58);
            level3ParagraphProperties11.Append(defaultRunProperties103);

            A.Level4ParagraphProperties level4ParagraphProperties11 = new A.Level4ParagraphProperties() { LeftMargin = 1371600, Indent = 0 };
            A.NoBullet noBullet59 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties104 = new A.DefaultRunProperties() { FontSize = 1000 };

            level4ParagraphProperties11.Append(noBullet59);
            level4ParagraphProperties11.Append(defaultRunProperties104);

            A.Level5ParagraphProperties level5ParagraphProperties11 = new A.Level5ParagraphProperties() { LeftMargin = 1828800, Indent = 0 };
            A.NoBullet noBullet60 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties105 = new A.DefaultRunProperties() { FontSize = 1000 };

            level5ParagraphProperties11.Append(noBullet60);
            level5ParagraphProperties11.Append(defaultRunProperties105);

            A.Level6ParagraphProperties level6ParagraphProperties11 = new A.Level6ParagraphProperties() { LeftMargin = 2286000, Indent = 0 };
            A.NoBullet noBullet61 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties106 = new A.DefaultRunProperties() { FontSize = 1000 };

            level6ParagraphProperties11.Append(noBullet61);
            level6ParagraphProperties11.Append(defaultRunProperties106);

            A.Level7ParagraphProperties level7ParagraphProperties11 = new A.Level7ParagraphProperties() { LeftMargin = 2743200, Indent = 0 };
            A.NoBullet noBullet62 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties107 = new A.DefaultRunProperties() { FontSize = 1000 };

            level7ParagraphProperties11.Append(noBullet62);
            level7ParagraphProperties11.Append(defaultRunProperties107);

            A.Level8ParagraphProperties level8ParagraphProperties11 = new A.Level8ParagraphProperties() { LeftMargin = 3200400, Indent = 0 };
            A.NoBullet noBullet63 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties108 = new A.DefaultRunProperties() { FontSize = 1000 };

            level8ParagraphProperties11.Append(noBullet63);
            level8ParagraphProperties11.Append(defaultRunProperties108);

            A.Level9ParagraphProperties level9ParagraphProperties11 = new A.Level9ParagraphProperties() { LeftMargin = 3657600, Indent = 0 };
            A.NoBullet noBullet64 = new A.NoBullet();
            A.DefaultRunProperties defaultRunProperties109 = new A.DefaultRunProperties() { FontSize = 1000 };

            level9ParagraphProperties11.Append(noBullet64);
            level9ParagraphProperties11.Append(defaultRunProperties109);

            listStyle60.Append(level1ParagraphProperties19);
            listStyle60.Append(level2ParagraphProperties11);
            listStyle60.Append(level3ParagraphProperties11);
            listStyle60.Append(level4ParagraphProperties11);
            listStyle60.Append(level5ParagraphProperties11);
            listStyle60.Append(level6ParagraphProperties11);
            listStyle60.Append(level7ParagraphProperties11);
            listStyle60.Append(level8ParagraphProperties11);
            listStyle60.Append(level9ParagraphProperties11);

            A.Paragraph paragraph96 = new A.Paragraph();
            A.ParagraphProperties paragraphProperties50 = new A.ParagraphProperties() { Level = 0 };

            A.Run run63 = new A.Run();

            A.RunProperties runProperties85 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties85.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text85 = new A.Text();
            text85.Text = "마스터 텍스트 스타일을 편집합니다";

            run63.Append(runProperties85);
            run63.Append(text85);

            paragraph96.Append(paragraphProperties50);
            paragraph96.Append(run63);

            textBody60.Append(bodyProperties60);
            textBody60.Append(listStyle60);
            textBody60.Append(paragraph96);

            shape60.Append(nonVisualShapeProperties60);
            shape60.Append(shapeProperties63);
            shape60.Append(textBody60);

            Shape shape61 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties61 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties78 = new NonVisualDrawingProperties() { Id = (UInt32Value)5U, Name = "Date Placeholder 4" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties61 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks61 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties61.Append(shapeLocks61);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties78 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape61 = new PlaceholderShape() { Type = PlaceholderValues.DateAndTime, Size = PlaceholderSizeValues.Half, Index = (UInt32Value)10U };

            applicationNonVisualDrawingProperties78.Append(placeholderShape61);

            nonVisualShapeProperties61.Append(nonVisualDrawingProperties78);
            nonVisualShapeProperties61.Append(nonVisualShapeDrawingProperties61);
            nonVisualShapeProperties61.Append(applicationNonVisualDrawingProperties78);
            ShapeProperties shapeProperties64 = new ShapeProperties();

            TextBody textBody61 = new TextBody();
            A.BodyProperties bodyProperties61 = new A.BodyProperties();
            A.ListStyle listStyle61 = new A.ListStyle();

            A.Paragraph paragraph97 = new A.Paragraph();

            A.Field field23 = new A.Field() { Id = "{C8F7DFEB-1EC8-4B68-801E-5BE83E1B4C77}", Type = "datetimeFigureOut" };

            A.RunProperties runProperties86 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties86.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text86 = new A.Text();
            text86.Text = "2015-03-31";

            field23.Append(runProperties86);
            field23.Append(text86);
            A.EndParagraphRunProperties endParagraphRunProperties56 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph97.Append(field23);
            paragraph97.Append(endParagraphRunProperties56);

            textBody61.Append(bodyProperties61);
            textBody61.Append(listStyle61);
            textBody61.Append(paragraph97);

            shape61.Append(nonVisualShapeProperties61);
            shape61.Append(shapeProperties64);
            shape61.Append(textBody61);

            Shape shape62 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties62 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties79 = new NonVisualDrawingProperties() { Id = (UInt32Value)6U, Name = "Footer Placeholder 5" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties62 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks62 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties62.Append(shapeLocks62);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties79 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape62 = new PlaceholderShape() { Type = PlaceholderValues.Footer, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)11U };

            applicationNonVisualDrawingProperties79.Append(placeholderShape62);

            nonVisualShapeProperties62.Append(nonVisualDrawingProperties79);
            nonVisualShapeProperties62.Append(nonVisualShapeDrawingProperties62);
            nonVisualShapeProperties62.Append(applicationNonVisualDrawingProperties79);
            ShapeProperties shapeProperties65 = new ShapeProperties();

            TextBody textBody62 = new TextBody();
            A.BodyProperties bodyProperties62 = new A.BodyProperties();
            A.ListStyle listStyle62 = new A.ListStyle();

            A.Paragraph paragraph98 = new A.Paragraph();
            A.EndParagraphRunProperties endParagraphRunProperties57 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph98.Append(endParagraphRunProperties57);

            textBody62.Append(bodyProperties62);
            textBody62.Append(listStyle62);
            textBody62.Append(paragraph98);

            shape62.Append(nonVisualShapeProperties62);
            shape62.Append(shapeProperties65);
            shape62.Append(textBody62);

            Shape shape63 = new Shape();

            NonVisualShapeProperties nonVisualShapeProperties63 = new NonVisualShapeProperties();
            NonVisualDrawingProperties nonVisualDrawingProperties80 = new NonVisualDrawingProperties() { Id = (UInt32Value)7U, Name = "Slide Number Placeholder 6" };

            NonVisualShapeDrawingProperties nonVisualShapeDrawingProperties63 = new NonVisualShapeDrawingProperties();
            A.ShapeLocks shapeLocks63 = new A.ShapeLocks() { NoGrouping = true };

            nonVisualShapeDrawingProperties63.Append(shapeLocks63);

            ApplicationNonVisualDrawingProperties applicationNonVisualDrawingProperties80 = new ApplicationNonVisualDrawingProperties();
            PlaceholderShape placeholderShape63 = new PlaceholderShape() { Type = PlaceholderValues.SlideNumber, Size = PlaceholderSizeValues.Quarter, Index = (UInt32Value)12U };

            applicationNonVisualDrawingProperties80.Append(placeholderShape63);

            nonVisualShapeProperties63.Append(nonVisualDrawingProperties80);
            nonVisualShapeProperties63.Append(nonVisualShapeDrawingProperties63);
            nonVisualShapeProperties63.Append(applicationNonVisualDrawingProperties80);
            ShapeProperties shapeProperties66 = new ShapeProperties();

            TextBody textBody63 = new TextBody();
            A.BodyProperties bodyProperties63 = new A.BodyProperties();
            A.ListStyle listStyle63 = new A.ListStyle();

            A.Paragraph paragraph99 = new A.Paragraph();

            A.Field field24 = new A.Field() { Id = "{82159155-D865-4AB3-A77E-63AB22C70C8E}", Type = "slidenum" };

            A.RunProperties runProperties87 = new A.RunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };
            runProperties87.SetAttribute(new OpenXmlAttribute("", "smtClean", "", "0"));
            A.Text text87 = new A.Text();
            text87.Text = "?#?";

            field24.Append(runProperties87);
            field24.Append(text87);
            A.EndParagraphRunProperties endParagraphRunProperties58 = new A.EndParagraphRunProperties() { Language = "ko-KR", AlternativeLanguage = "en-US" };

            paragraph99.Append(field24);
            paragraph99.Append(endParagraphRunProperties58);

            textBody63.Append(bodyProperties63);
            textBody63.Append(listStyle63);
            textBody63.Append(paragraph99);

            shape63.Append(nonVisualShapeProperties63);
            shape63.Append(shapeProperties66);
            shape63.Append(textBody63);

            shapeTree13.Append(nonVisualGroupShapeProperties14);
            shapeTree13.Append(groupShapeProperties14);
            shapeTree13.Append(shape58);
            shapeTree13.Append(shape59);
            shapeTree13.Append(shape60);
            shapeTree13.Append(shape61);
            shapeTree13.Append(shape62);
            shapeTree13.Append(shape63);

            CommonSlideDataExtensionList commonSlideDataExtensionList13 = new CommonSlideDataExtensionList();

            CommonSlideDataExtension commonSlideDataExtension13 = new CommonSlideDataExtension() { Uri = "{BB962C8B-B14F-4D97-AF65-F5344CB8AC3E}" };

            P14.CreationId creationId13 = new P14.CreationId() { Val = (UInt32Value)1923280022U };
            creationId13.AddNamespaceDeclaration("p14", "http://schemas.microsoft.com/office/powerpoint/2010/main");

            commonSlideDataExtension13.Append(creationId13);

            commonSlideDataExtensionList13.Append(commonSlideDataExtension13);

            commonSlideData13.Append(shapeTree13);
            commonSlideData13.Append(commonSlideDataExtensionList13);

            ColorMapOverride colorMapOverride12 = new ColorMapOverride();
            A.MasterColorMapping masterColorMapping12 = new A.MasterColorMapping();

            colorMapOverride12.Append(masterColorMapping12);

            slideLayout11.Append(commonSlideData13);
            slideLayout11.Append(colorMapOverride12);

            slideLayoutPart11.SlideLayout = slideLayout11;
        }

        // Generates content of tableStylesPart1.
        private void GenerateTableStylesPart1Content(TableStylesPart tableStylesPart1)
        {
            A.TableStyleList tableStyleList1 = new A.TableStyleList() { Default = "{5C22544A-7EE6-4342-B048-85BDC9FD1C3A}" };
            tableStyleList1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            tableStylesPart1.TableStyleList = tableStyleList1;
        }

        // Generates content of viewPropertiesPart1.
        private void GenerateViewPropertiesPart1Content(ViewPropertiesPart viewPropertiesPart1)
        {
            ViewProperties viewProperties1 = new ViewProperties();
            viewProperties1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");
            viewProperties1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            viewProperties1.AddNamespaceDeclaration("p", "http://schemas.openxmlformats.org/presentationml/2006/main");

            NormalViewProperties normalViewProperties1 = new NormalViewProperties() { HorizontalBarState = SplitterBarStateValues.Maximized };
            RestoredLeft restoredLeft1 = new RestoredLeft() { Size = 19986, AutoAdjust = false };
            RestoredTop restoredTop1 = new RestoredTop() { Size = 94660 };

            normalViewProperties1.Append(restoredLeft1);
            normalViewProperties1.Append(restoredTop1);

            SlideViewProperties slideViewProperties1 = new SlideViewProperties();

            CommonSlideViewProperties commonSlideViewProperties1 = new CommonSlideViewProperties() { SnapToGrid = false };

            CommonViewProperties commonViewProperties1 = new CommonViewProperties() { VariableScale = true };

            ScaleFactor scaleFactor1 = new ScaleFactor();
            A.ScaleX scaleX1 = new A.ScaleX() { Numerator = 89, Denominator = 100 };
            A.ScaleY scaleY1 = new A.ScaleY() { Numerator = 89, Denominator = 100 };

            scaleFactor1.Append(scaleX1);
            scaleFactor1.Append(scaleY1);
            Origin origin1 = new Origin() { X = 91L, Y = 941L };

            commonViewProperties1.Append(scaleFactor1);
            commonViewProperties1.Append(origin1);
            GuideList guideList1 = new GuideList();

            commonSlideViewProperties1.Append(commonViewProperties1);
            commonSlideViewProperties1.Append(guideList1);

            slideViewProperties1.Append(commonSlideViewProperties1);

            NotesTextViewProperties notesTextViewProperties1 = new NotesTextViewProperties();

            CommonViewProperties commonViewProperties2 = new CommonViewProperties();

            ScaleFactor scaleFactor2 = new ScaleFactor();
            A.ScaleX scaleX2 = new A.ScaleX() { Numerator = 1, Denominator = 1 };
            A.ScaleY scaleY2 = new A.ScaleY() { Numerator = 1, Denominator = 1 };

            scaleFactor2.Append(scaleX2);
            scaleFactor2.Append(scaleY2);
            Origin origin2 = new Origin() { X = 0L, Y = 0L };

            commonViewProperties2.Append(scaleFactor2);
            commonViewProperties2.Append(origin2);

            notesTextViewProperties1.Append(commonViewProperties2);
            GridSpacing gridSpacing1 = new GridSpacing() { Cx = 72008L, Cy = 72008L };

            viewProperties1.Append(normalViewProperties1);
            viewProperties1.Append(slideViewProperties1);
            viewProperties1.Append(notesTextViewProperties1);
            viewProperties1.Append(gridSpacing1);

            viewPropertiesPart1.ViewProperties = viewProperties1;
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Office Theme";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "1";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "0";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office PowerPoint";
            Ap.PresentationFormat presentationFormat1 = new Ap.PresentationFormat();
            presentationFormat1.Text = "화면 슬라이드 쇼(4:3)";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "0";
            Ap.Slides slides1 = new Ap.Slides();
            slides1.Text = "1";
            Ap.Notes notes1 = new Ap.Notes();
            notes1.Text = "0";
            Ap.HiddenSlides hiddenSlides1 = new Ap.HiddenSlides();
            hiddenSlides1.Text = "0";
            Ap.MultimediaClips multimediaClips1 = new Ap.MultimediaClips();
            multimediaClips1.Text = "0";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)6U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "사용한 글꼴";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "4";

            variant2.Append(vTInt321);

            Vt.Variant variant3 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "테마";

            variant3.Append(vTLPSTR2);

            Vt.Variant variant4 = new Vt.Variant();
            Vt.VTInt32 vTInt322 = new Vt.VTInt32();
            vTInt322.Text = "1";

            variant4.Append(vTInt322);

            Vt.Variant variant5 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR3 = new Vt.VTLPSTR();
            vTLPSTR3.Text = "슬라이드 제목";

            variant5.Append(vTLPSTR3);

            Vt.Variant variant6 = new Vt.Variant();
            Vt.VTInt32 vTInt323 = new Vt.VTInt32();
            vTInt323.Text = "1";

            variant6.Append(vTInt323);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);
            vTVector1.Append(variant3);
            vTVector1.Append(variant4);
            vTVector1.Append(variant5);
            vTVector1.Append(variant6);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)6U };
            Vt.VTLPSTR vTLPSTR4 = new Vt.VTLPSTR();
            vTLPSTR4.Text = "맑은 고딕";
            Vt.VTLPSTR vTLPSTR5 = new Vt.VTLPSTR();
            vTLPSTR5.Text = "Arial";
            Vt.VTLPSTR vTLPSTR6 = new Vt.VTLPSTR();
            vTLPSTR6.Text = "Calibri";
            Vt.VTLPSTR vTLPSTR7 = new Vt.VTLPSTR();
            vTLPSTR7.Text = "Calibri Light";
            Vt.VTLPSTR vTLPSTR8 = new Vt.VTLPSTR();
            vTLPSTR8.Text = "Office 테마";
            Vt.VTLPSTR vTLPSTR9 = new Vt.VTLPSTR();
            vTLPSTR9.Text = "PowerPoint 프레젠테이션";

            vTVector2.Append(vTLPSTR4);
            vTVector2.Append(vTLPSTR5);
            vTVector2.Append(vTLPSTR6);
            vTVector2.Append(vTLPSTR7);
            vTVector2.Append(vTLPSTR8);
            vTVector2.Append(vTLPSTR9);

            titlesOfParts1.Append(vTVector2);
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "15.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(words1);
            properties1.Append(application1);
            properties1.Append(presentationFormat1);
            properties1.Append(paragraphs1);
            properties1.Append(slides1);
            properties1.Append(notes1);
            properties1.Append(hiddenSlides1);
            properties1.Append(multimediaClips1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(linksUpToDate1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "goodhobak";
            document.PackageProperties.Title = "PowerPoint 프레젠테이션";
            document.PackageProperties.Revision = "1";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2015-03-31T14:47:32Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2015-03-31T14:48:50Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "goodhobak";
        }

        #region Binary Data
        private string thumbnailPart1Data = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCADAAQADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9U6KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKxPFHjTR/Btqk+rXqW5kO2GFQXlmb+6iDLMfoKqMZTfLFXZMpRguaTsjbrmv+FjeHf+Eq/wCEaGobtc3bfsawSFh8u7JIXAG3nOcYrn93jH4g/dEngnQW/iYBtTnX2HKwfqw9q3PC/wAM/Dvg++a+02w2ahJF5Ml5LI0ksg3biWZicknqfYdhXX7OlTT9q7y6Jd/N7fJfgcvtKtRr2StHq328l/n+J1NFFFcR2BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFRXN1DZ28k9xKkEEalnkkYKqgdSSegoAlqhrWu6f4c0+S+1S9hsLSP7007hV+nufYc1xk3xH1DxZK9r4H05dSQEo+t326OwjPfafvTEei8dOauaL8L7WPUI9W8RXkvijW15S4vVAhgPpDCPlT68n3rs9gqetd28uv/AAPnr5M5PbOppRV/Pp/wfl95Q/4SrxN4++TwvZnQtIb/AJjuqwnzJF9YLc8n2Z8D2rb8L/DnSfDN02oHztU1qQfvdV1B/NuG9gTwi/7KgCuqoqZV3bkprlj+fq+v5eRUaCvz1HzP8vRdPz8wooorlOkKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAorlfFXxDsPDN7HpkVvc6xrsyb4dLsE3ylc43Mfuouf4mI79axP+EL8Q+Oj5vjC+/s/TG5Hh/SZSqsPSeYYZ/dVwtdUaDsp1Hyx/F+i/peZzSra8lNcz/Ber/p+Rb1X4ow3F9LpXhWxfxRq0Z2yfZ3C2tuf+ms5+Uf7oyeMYqG1+Gd14iuI73xxqI1uVWDx6Tbgx6fAe3ydZSPV/XpXaaVpNlodjFZadaQ2VpEMJDAgRR+Aq5Ve3VPSgrefX/gfL72T7F1Nazv5dP8Ag/P7kMhhjt4kiiRYokAVUQYCgdAB2FPoorjOsKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAOB8BoJfH/xDusfevraDd/uWycf+PV31cH8LW86+8cT/wB/xDcJ/wB8RxL/AENd5XXiv4tuyS+5I5cN/Dv3b/FsKKKK5DqCiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooA4L4Ojfouu3Pa617UJgfX9+y/8Astd7XCfBFvM+G+nzd57i7m+u65lP9a7uuvF/x5rs2cuF/gQfkgooorkOoKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACobucWtrNMekaM/wCQzU1Y3jK5+x+D9cuOnlWM8n5RsauEeaSXcmT5YtmD8E4Db/Cjwwp6taLIf+BEt/Wu3rm/hrb/AGX4d+F4sY26XbA/XylzXSVriJc1acu7f5mWHXLRguyX5BRRRXObhRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAVynxXuPsvwy8VSdP8AiWXCj8YyP611dcJ8cpDH8J/EQBwZIUhH/A5FT/2aunCrmr015r8znxD5aM35P8jqfDdv9k8O6VBjHlWkSfkgFaVNjQRoqKMKowKdWEnzNs2iuVJBRRRUlBRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAVwfxrXzvApte91qFjCB65uY/8K7yuD+LbbrXwtB/z38RWKH6By5/9Brrwv8eD7O/3HLiv4M13X5neUUUVyHUFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAVm+IPDmm+KtMfT9VtEvLRyGMbEjkHIIIIII9Qa0qKqMnF80XZilFSVpK6OBPw11TRfm8M+LtS09Aciz1LF/b4/ugP86j6NR/wk3jjw/wD8hfwxb65AvJuvD9x8+P8ArhLgk/RjXfUV0/WHL+JFS9d/vVn95zfV1H+HJx/L7ndfccZpfxe8L6hdCznvzo+od7PV4mtJQfTDgA/gTXYo6yKrowZWGQynIIqrqmj2Gt2xt9Rsre/tz1iuYlkX8iK45/g9pmnuZfDuoan4Wmznbp1yTAT/ALUL7kI9gBRbDz2bj+K/R/gwvXhulL8H+q/FHe0VwH/FxfDv/QJ8YWy/Wwum/wDQoz/47Tl+MWmae6xeI9O1PwtKTt3ajbEwE/7MybkI9yRR9VnL+HaXp/lv+AfWYL+JePr/AJ7fid7RVPS9YsNctRc6de29/bnpLbSrIv5g1crlacXZnSmmroKKKKQwooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKa6LIjI6h0YYKsMginUUAcZqnwh8L6hctdwWDaPfnpeaRK1pKPfKEAn6g1T/wCEZ8ceH+dI8T2+t246WviC3+cD/rvFgk/VTXf0V1LE1bWk+Zeev57fI5nh6d7xVn5aflv8zgP+FlaponHiXwhqWnoOt5puL+3A/vEp86j6rXQeHfH3h3xaMaRrFpeyd4UkAlH1Q4YfiK365/xF8P8Aw54s+bVdGtLuXtOY9so+ki4YfgafNQn8UXH01/B/5i5a0Phlzeun4r/I6CiuA/4Vvq+h/N4a8X6jZIDkWeqAX1vj+6N+HUfRq7TSVvl023Gpvbvf7B5zWqssRbvtDEnH1rOpCEVeEr/ff+vRs0hOUnaUbfdb+vki3RRRWBsFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQB//2Q==";

        private System.IO.Stream GetBinaryDataStream(string base64String)
        {
            return new System.IO.MemoryStream(System.Convert.FromBase64String(base64String));
        }

        #endregion
    }
}
