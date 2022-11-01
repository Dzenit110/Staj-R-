using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using staj_r_backend.Models.Entities;

namespace staj_r_backend.Controllers.Documents
{
	public class DailyReportXML:IDocument
	{
		public DailyReport dr { get; set; }
        public string xml { get; set; }
        public DailyReportXML(DailyReport _dr)
        {
            dr = _dr;
            xml = $@"<?xml version='1.0' encoding='UTF-8' standalone='yes'?>
<?mso-application progid='Word.Document'?>
<w:wordDocument
	xmlns:aml='http://schemas.microsoft.com/aml/2001/core'
	xmlns:wpc='http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas'
	xmlns:cx='http://schemas.microsoft.com/office/drawing/2014/chartex'
	xmlns:cx1='http://schemas.microsoft.com/office/drawing/2015/9/8/chartex'
	xmlns:cx2='http://schemas.microsoft.com/office/drawing/2015/10/21/chartex'
	xmlns:cx3='http://schemas.microsoft.com/office/drawing/2016/5/9/chartex'
	xmlns:cx4='http://schemas.microsoft.com/office/drawing/2016/5/10/chartex'
	xmlns:cx5='http://schemas.microsoft.com/office/drawing/2016/5/11/chartex'
	xmlns:cx6='http://schemas.microsoft.com/office/drawing/2016/5/12/chartex'
	xmlns:cx7='http://schemas.microsoft.com/office/drawing/2016/5/13/chartex'
	xmlns:cx8='http://schemas.microsoft.com/office/drawing/2016/5/14/chartex'
	xmlns:dt='uuid:C2F41010-65B3-11d1-A29F-00AA00C14882'
	xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006'
	xmlns:aink='http://schemas.microsoft.com/office/drawing/2016/ink'
	xmlns:am3d='http://schemas.microsoft.com/office/drawing/2017/model3d'
	xmlns:o='urn:schemas-microsoft-com:office:office'
	xmlns:v='urn:schemas-microsoft-com:vml'
	xmlns:w10='urn:schemas-microsoft-com:office:word'
	xmlns:w='http://schemas.microsoft.com/office/word/2003/wordml'
	xmlns:wx='http://schemas.microsoft.com/office/word/2003/auxHint'
	xmlns:wne='http://schemas.microsoft.com/office/word/2006/wordml'
	xmlns:wsp='http://schemas.microsoft.com/office/word/2003/wordml/sp2'
	xmlns:sl='http://schemas.microsoft.com/schemaLibrary/2003/core' w:macrosPresent='no' w:embeddedObjPresent='no' w:ocxPresent='no' xml:space='preserve'>
	<w:ignoreSubtree w:val='http://schemas.microsoft.com/office/word/2003/wordml/sp2'/>
	<o:DocumentProperties>
		<o:Author>StajR</o:Author>
		<o:LastAuthor>CARA-USER</o:LastAuthor>
		<o:Revision>2</o:Revision>
		<o:TotalTime>0</o:TotalTime>
		<o:Created>2022-10-30T00:18:00Z</o:Created>
		<o:LastSaved>2022-10-30T00:18:00Z</o:LastSaved>
		<o:Pages>1</o:Pages>
		<o:Words>22</o:Words>
		<o:Characters>130</o:Characters>
		<o:Company>StajR</o:Company>
		<o:Lines>1</o:Lines>
		<o:Paragraphs>1</o:Paragraphs>
		<o:CharactersWithSpaces>151</o:CharactersWithSpaces>
		<o:Version>16</o:Version>
	</o:DocumentProperties>
	<w:fonts>
		<w:defaultFonts w:ascii='Calibri' w:fareast='Calibri' w:h-ansi='Calibri' w:cs='Arial'/>
		<w:font w:name='Times New Roman'>
			<w:panose-1 w:val='02020603050405020304'/>
			<w:charset w:val='00'/>
			<w:family w:val='Roman'/>
			<w:pitch w:val='variable'/>
			<w:sig w:usb-0='E0002EFF' w:usb-1='C000785B' w:usb-2='00000009' w:usb-3='00000000' w:csb-0='000001FF' w:csb-1='00000000'/>
		</w:font>
		<w:font w:name='Arial'>
			<w:panose-1 w:val='020B0604020202020204'/>
			<w:charset w:val='00'/>
			<w:family w:val='Swiss'/>
			<w:pitch w:val='variable'/>
			<w:sig w:usb-0='E0002EFF' w:usb-1='C000785B' w:usb-2='00000009' w:usb-3='00000000' w:csb-0='000001FF' w:csb-1='00000000'/>
		</w:font>
		<w:font w:name='Cambria Math'>
			<w:panose-1 w:val='02040503050406030204'/>
			<w:charset w:val='00'/>
			<w:family w:val='Roman'/>
			<w:pitch w:val='variable'/>
			<w:sig w:usb-0='00000003' w:usb-1='00000000' w:usb-2='00000000' w:usb-3='00000000' w:csb-0='00000001' w:csb-1='00000000'/>
		</w:font>
		<w:font w:name='Calibri'>
			<w:panose-1 w:val='020F0502020204030204'/>
			<w:charset w:val='00'/>
			<w:family w:val='Swiss'/>
			<w:pitch w:val='variable'/>
			<w:sig w:usb-0='E4002EFF' w:usb-1='C000247B' w:usb-2='00000009' w:usb-3='00000000' w:csb-0='000001FF' w:csb-1='00000000'/>
		</w:font>
	</w:fonts>
	<w:styles>
		<w:versionOfBuiltInStylenames w:val='7'/>
		<w:latentStyles w:defLockedState='off' w:latentStyleCount='376'>
			<w:lsdException w:name='Normal'/>
			<w:lsdException w:name='heading 1'/>
			<w:lsdException w:name='heading 2'/>
			<w:lsdException w:name='heading 3'/>
			<w:lsdException w:name='heading 4'/>
			<w:lsdException w:name='heading 5'/>
			<w:lsdException w:name='heading 6'/>
			<w:lsdException w:name='heading 7'/>
			<w:lsdException w:name='heading 8'/>
			<w:lsdException w:name='heading 9'/>
			<w:lsdException w:name='index 1'/>
			<w:lsdException w:name='index 2'/>
			<w:lsdException w:name='index 3'/>
			<w:lsdException w:name='index 4'/>
			<w:lsdException w:name='index 5'/>
			<w:lsdException w:name='index 6'/>
			<w:lsdException w:name='index 7'/>
			<w:lsdException w:name='index 8'/>
			<w:lsdException w:name='index 9'/>
			<w:lsdException w:name='toc 1'/>
			<w:lsdException w:name='toc 2'/>
			<w:lsdException w:name='toc 3'/>
			<w:lsdException w:name='toc 4'/>
			<w:lsdException w:name='toc 5'/>
			<w:lsdException w:name='toc 6'/>
			<w:lsdException w:name='toc 7'/>
			<w:lsdException w:name='toc 8'/>
			<w:lsdException w:name='toc 9'/>
			<w:lsdException w:name='Normal Indent'/>
			<w:lsdException w:name='footnote text'/>
			<w:lsdException w:name='annotation text'/>
			<w:lsdException w:name='header'/>
			<w:lsdException w:name='footer'/>
			<w:lsdException w:name='index heading'/>
			<w:lsdException w:name='caption'/>
			<w:lsdException w:name='table of figures'/>
			<w:lsdException w:name='envelope address'/>
			<w:lsdException w:name='envelope return'/>
			<w:lsdException w:name='footnote reference'/>
			<w:lsdException w:name='annotation reference'/>
			<w:lsdException w:name='line number'/>
			<w:lsdException w:name='page number'/>
			<w:lsdException w:name='endnote reference'/>
			<w:lsdException w:name='endnote text'/>
			<w:lsdException w:name='table of authorities'/>
			<w:lsdException w:name='macro'/>
			<w:lsdException w:name='toa heading'/>
			<w:lsdException w:name='List'/>
			<w:lsdException w:name='List Bullet'/>
			<w:lsdException w:name='List Number'/>
			<w:lsdException w:name='List 2'/>
			<w:lsdException w:name='List 3'/>
			<w:lsdException w:name='List 4'/>
			<w:lsdException w:name='List 5'/>
			<w:lsdException w:name='List Bullet 2'/>
			<w:lsdException w:name='List Bullet 3'/>
			<w:lsdException w:name='List Bullet 4'/>
			<w:lsdException w:name='List Bullet 5'/>
			<w:lsdException w:name='List Number 2'/>
			<w:lsdException w:name='List Number 3'/>
			<w:lsdException w:name='List Number 4'/>
			<w:lsdException w:name='List Number 5'/>
			<w:lsdException w:name='Title'/>
			<w:lsdException w:name='Closing'/>
			<w:lsdException w:name='Signature'/>
			<w:lsdException w:name='Default Paragraph Font'/>
			<w:lsdException w:name='Body Text'/>
			<w:lsdException w:name='Body Text Indent'/>
			<w:lsdException w:name='List Continue'/>
			<w:lsdException w:name='List Continue 2'/>
			<w:lsdException w:name='List Continue 3'/>
			<w:lsdException w:name='List Continue 4'/>
			<w:lsdException w:name='List Continue 5'/>
			<w:lsdException w:name='Message Header'/>
			<w:lsdException w:name='Subtitle'/>
			<w:lsdException w:name='Salutation'/>
			<w:lsdException w:name='Date'/>
			<w:lsdException w:name='Body Text First Indent'/>
			<w:lsdException w:name='Body Text First Indent 2'/>
			<w:lsdException w:name='Note Heading'/>
			<w:lsdException w:name='Body Text 2'/>
			<w:lsdException w:name='Body Text 3'/>
			<w:lsdException w:name='Body Text Indent 2'/>
			<w:lsdException w:name='Body Text Indent 3'/>
			<w:lsdException w:name='Block Text'/>
			<w:lsdException w:name='Hyperlink'/>
			<w:lsdException w:name='FollowedHyperlink'/>
			<w:lsdException w:name='Strong'/>
			<w:lsdException w:name='Emphasis'/>
			<w:lsdException w:name='Document Map'/>
			<w:lsdException w:name='Plain Text'/>
			<w:lsdException w:name='E-mail Signature'/>
			<w:lsdException w:name='HTML Top of Form'/>
			<w:lsdException w:name='HTML Bottom of Form'/>
			<w:lsdException w:name='Normal (Web)'/>
			<w:lsdException w:name='HTML Acronym'/>
			<w:lsdException w:name='HTML Address'/>
			<w:lsdException w:name='HTML Cite'/>
			<w:lsdException w:name='HTML Code'/>
			<w:lsdException w:name='HTML Definition'/>
			<w:lsdException w:name='HTML Keyboard'/>
			<w:lsdException w:name='HTML Preformatted'/>
			<w:lsdException w:name='HTML Sample'/>
			<w:lsdException w:name='HTML Typewriter'/>
			<w:lsdException w:name='HTML Variable'/>
			<w:lsdException w:name='Normal Table'/>
			<w:lsdException w:name='annotation subject'/>
			<w:lsdException w:name='No List'/>
			<w:lsdException w:name='Outline List 1'/>
			<w:lsdException w:name='Outline List 2'/>
			<w:lsdException w:name='Outline List 3'/>
			<w:lsdException w:name='Table Simple 1'/>
			<w:lsdException w:name='Table Simple 2'/>
			<w:lsdException w:name='Table Simple 3'/>
			<w:lsdException w:name='Table Classic 1'/>
			<w:lsdException w:name='Table Classic 2'/>
			<w:lsdException w:name='Table Classic 3'/>
			<w:lsdException w:name='Table Classic 4'/>
			<w:lsdException w:name='Table Colorful 1'/>
			<w:lsdException w:name='Table Colorful 2'/>
			<w:lsdException w:name='Table Colorful 3'/>
			<w:lsdException w:name='Table Columns 1'/>
			<w:lsdException w:name='Table Columns 2'/>
			<w:lsdException w:name='Table Columns 3'/>
			<w:lsdException w:name='Table Columns 4'/>
			<w:lsdException w:name='Table Columns 5'/>
			<w:lsdException w:name='Table Grid 1'/>
			<w:lsdException w:name='Table Grid 2'/>
			<w:lsdException w:name='Table Grid 3'/>
			<w:lsdException w:name='Table Grid 4'/>
			<w:lsdException w:name='Table Grid 5'/>
			<w:lsdException w:name='Table Grid 6'/>
			<w:lsdException w:name='Table Grid 7'/>
			<w:lsdException w:name='Table Grid 8'/>
			<w:lsdException w:name='Table List 1'/>
			<w:lsdException w:name='Table List 2'/>
			<w:lsdException w:name='Table List 3'/>
			<w:lsdException w:name='Table List 4'/>
			<w:lsdException w:name='Table List 5'/>
			<w:lsdException w:name='Table List 6'/>
			<w:lsdException w:name='Table List 7'/>
			<w:lsdException w:name='Table List 8'/>
			<w:lsdException w:name='Table 3D effects 1'/>
			<w:lsdException w:name='Table 3D effects 2'/>
			<w:lsdException w:name='Table 3D effects 3'/>
			<w:lsdException w:name='Table Contemporary'/>
			<w:lsdException w:name='Table Elegant'/>
			<w:lsdException w:name='Table Professional'/>
			<w:lsdException w:name='Table Subtle 1'/>
			<w:lsdException w:name='Table Subtle 2'/>
			<w:lsdException w:name='Table Web 1'/>
			<w:lsdException w:name='Table Web 2'/>
			<w:lsdException w:name='Table Web 3'/>
			<w:lsdException w:name='Balloon Text'/>
			<w:lsdException w:name='Table Grid'/>
			<w:lsdException w:name='Table Theme'/>
			<w:lsdException w:name='Placeholder Text'/>
			<w:lsdException w:name='No Spacing'/>
			<w:lsdException w:name='Light Shading'/>
			<w:lsdException w:name='Light List'/>
			<w:lsdException w:name='Light Grid'/>
			<w:lsdException w:name='Medium Shading 1'/>
			<w:lsdException w:name='Medium Shading 2'/>
			<w:lsdException w:name='Medium List 1'/>
			<w:lsdException w:name='Medium List 2'/>
			<w:lsdException w:name='Medium Grid 1'/>
			<w:lsdException w:name='Medium Grid 2'/>
			<w:lsdException w:name='Medium Grid 3'/>
			<w:lsdException w:name='Dark List'/>
			<w:lsdException w:name='Colorful Shading'/>
			<w:lsdException w:name='Colorful List'/>
			<w:lsdException w:name='Colorful Grid'/>
			<w:lsdException w:name='Light Shading Accent 1'/>
			<w:lsdException w:name='Light List Accent 1'/>
			<w:lsdException w:name='Light Grid Accent 1'/>
			<w:lsdException w:name='Medium Shading 1 Accent 1'/>
			<w:lsdException w:name='Medium Shading 2 Accent 1'/>
			<w:lsdException w:name='Medium List 1 Accent 1'/>
			<w:lsdException w:name='Revision'/>
			<w:lsdException w:name='List Paragraph'/>
			<w:lsdException w:name='Quote'/>
			<w:lsdException w:name='Intense Quote'/>
			<w:lsdException w:name='Medium List 2 Accent 1'/>
			<w:lsdException w:name='Medium Grid 1 Accent 1'/>
			<w:lsdException w:name='Medium Grid 2 Accent 1'/>
			<w:lsdException w:name='Medium Grid 3 Accent 1'/>
			<w:lsdException w:name='Dark List Accent 1'/>
			<w:lsdException w:name='Colorful Shading Accent 1'/>
			<w:lsdException w:name='Colorful List Accent 1'/>
			<w:lsdException w:name='Colorful Grid Accent 1'/>
			<w:lsdException w:name='Light Shading Accent 2'/>
			<w:lsdException w:name='Light List Accent 2'/>
			<w:lsdException w:name='Light Grid Accent 2'/>
			<w:lsdException w:name='Medium Shading 1 Accent 2'/>
			<w:lsdException w:name='Medium Shading 2 Accent 2'/>
			<w:lsdException w:name='Medium List 1 Accent 2'/>
			<w:lsdException w:name='Medium List 2 Accent 2'/>
			<w:lsdException w:name='Medium Grid 1 Accent 2'/>
			<w:lsdException w:name='Medium Grid 2 Accent 2'/>
			<w:lsdException w:name='Medium Grid 3 Accent 2'/>
			<w:lsdException w:name='Dark List Accent 2'/>
			<w:lsdException w:name='Colorful Shading Accent 2'/>
			<w:lsdException w:name='Colorful List Accent 2'/>
			<w:lsdException w:name='Colorful Grid Accent 2'/>
			<w:lsdException w:name='Light Shading Accent 3'/>
			<w:lsdException w:name='Light List Accent 3'/>
			<w:lsdException w:name='Light Grid Accent 3'/>
			<w:lsdException w:name='Medium Shading 1 Accent 3'/>
			<w:lsdException w:name='Medium Shading 2 Accent 3'/>
			<w:lsdException w:name='Medium List 1 Accent 3'/>
			<w:lsdException w:name='Medium List 2 Accent 3'/>
			<w:lsdException w:name='Medium Grid 1 Accent 3'/>
			<w:lsdException w:name='Medium Grid 2 Accent 3'/>
			<w:lsdException w:name='Medium Grid 3 Accent 3'/>
			<w:lsdException w:name='Dark List Accent 3'/>
			<w:lsdException w:name='Colorful Shading Accent 3'/>
			<w:lsdException w:name='Colorful List Accent 3'/>
			<w:lsdException w:name='Colorful Grid Accent 3'/>
			<w:lsdException w:name='Light Shading Accent 4'/>
			<w:lsdException w:name='Light List Accent 4'/>
			<w:lsdException w:name='Light Grid Accent 4'/>
			<w:lsdException w:name='Medium Shading 1 Accent 4'/>
			<w:lsdException w:name='Medium Shading 2 Accent 4'/>
			<w:lsdException w:name='Medium List 1 Accent 4'/>
			<w:lsdException w:name='Medium List 2 Accent 4'/>
			<w:lsdException w:name='Medium Grid 1 Accent 4'/>
			<w:lsdException w:name='Medium Grid 2 Accent 4'/>
			<w:lsdException w:name='Medium Grid 3 Accent 4'/>
			<w:lsdException w:name='Dark List Accent 4'/>
			<w:lsdException w:name='Colorful Shading Accent 4'/>
			<w:lsdException w:name='Colorful List Accent 4'/>
			<w:lsdException w:name='Colorful Grid Accent 4'/>
			<w:lsdException w:name='Light Shading Accent 5'/>
			<w:lsdException w:name='Light List Accent 5'/>
			<w:lsdException w:name='Light Grid Accent 5'/>
			<w:lsdException w:name='Medium Shading 1 Accent 5'/>
			<w:lsdException w:name='Medium Shading 2 Accent 5'/>
			<w:lsdException w:name='Medium List 1 Accent 5'/>
			<w:lsdException w:name='Medium List 2 Accent 5'/>
			<w:lsdException w:name='Medium Grid 1 Accent 5'/>
			<w:lsdException w:name='Medium Grid 2 Accent 5'/>
			<w:lsdException w:name='Medium Grid 3 Accent 5'/>
			<w:lsdException w:name='Dark List Accent 5'/>
			<w:lsdException w:name='Colorful Shading Accent 5'/>
			<w:lsdException w:name='Colorful List Accent 5'/>
			<w:lsdException w:name='Colorful Grid Accent 5'/>
			<w:lsdException w:name='Light Shading Accent 6'/>
			<w:lsdException w:name='Light List Accent 6'/>
			<w:lsdException w:name='Light Grid Accent 6'/>
			<w:lsdException w:name='Medium Shading 1 Accent 6'/>
			<w:lsdException w:name='Medium Shading 2 Accent 6'/>
			<w:lsdException w:name='Medium List 1 Accent 6'/>
			<w:lsdException w:name='Medium List 2 Accent 6'/>
			<w:lsdException w:name='Medium Grid 1 Accent 6'/>
			<w:lsdException w:name='Medium Grid 2 Accent 6'/>
			<w:lsdException w:name='Medium Grid 3 Accent 6'/>
			<w:lsdException w:name='Dark List Accent 6'/>
			<w:lsdException w:name='Colorful Shading Accent 6'/>
			<w:lsdException w:name='Colorful List Accent 6'/>
			<w:lsdException w:name='Colorful Grid Accent 6'/>
			<w:lsdException w:name='Subtle Emphasis'/>
			<w:lsdException w:name='Intense Emphasis'/>
			<w:lsdException w:name='Subtle Reference'/>
			<w:lsdException w:name='Intense Reference'/>
			<w:lsdException w:name='Book Title'/>
			<w:lsdException w:name='Bibliography'/>
			<w:lsdException w:name='TOC Heading'/>
			<w:lsdException w:name='Plain Table 1'/>
			<w:lsdException w:name='Plain Table 2'/>
			<w:lsdException w:name='Plain Table 3'/>
			<w:lsdException w:name='Plain Table 4'/>
			<w:lsdException w:name='Plain Table 5'/>
			<w:lsdException w:name='Grid Table Light'/>
			<w:lsdException w:name='Grid Table 1 Light'/>
			<w:lsdException w:name='Grid Table 2'/>
			<w:lsdException w:name='Grid Table 3'/>
			<w:lsdException w:name='Grid Table 4'/>
			<w:lsdException w:name='Grid Table 5 Dark'/>
			<w:lsdException w:name='Grid Table 6 Colorful'/>
			<w:lsdException w:name='Grid Table 7 Colorful'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 1'/>
			<w:lsdException w:name='Grid Table 2 Accent 1'/>
			<w:lsdException w:name='Grid Table 3 Accent 1'/>
			<w:lsdException w:name='Grid Table 4 Accent 1'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 1'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 1'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 1'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 2'/>
			<w:lsdException w:name='Grid Table 2 Accent 2'/>
			<w:lsdException w:name='Grid Table 3 Accent 2'/>
			<w:lsdException w:name='Grid Table 4 Accent 2'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 2'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 2'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 2'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 3'/>
			<w:lsdException w:name='Grid Table 2 Accent 3'/>
			<w:lsdException w:name='Grid Table 3 Accent 3'/>
			<w:lsdException w:name='Grid Table 4 Accent 3'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 3'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 3'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 3'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 4'/>
			<w:lsdException w:name='Grid Table 2 Accent 4'/>
			<w:lsdException w:name='Grid Table 3 Accent 4'/>
			<w:lsdException w:name='Grid Table 4 Accent 4'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 4'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 4'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 4'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 5'/>
			<w:lsdException w:name='Grid Table 2 Accent 5'/>
			<w:lsdException w:name='Grid Table 3 Accent 5'/>
			<w:lsdException w:name='Grid Table 4 Accent 5'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 5'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 5'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 5'/>
			<w:lsdException w:name='Grid Table 1 Light Accent 6'/>
			<w:lsdException w:name='Grid Table 2 Accent 6'/>
			<w:lsdException w:name='Grid Table 3 Accent 6'/>
			<w:lsdException w:name='Grid Table 4 Accent 6'/>
			<w:lsdException w:name='Grid Table 5 Dark Accent 6'/>
			<w:lsdException w:name='Grid Table 6 Colorful Accent 6'/>
			<w:lsdException w:name='Grid Table 7 Colorful Accent 6'/>
			<w:lsdException w:name='List Table 1 Light'/>
			<w:lsdException w:name='List Table 2'/>
			<w:lsdException w:name='List Table 3'/>
			<w:lsdException w:name='List Table 4'/>
			<w:lsdException w:name='List Table 5 Dark'/>
			<w:lsdException w:name='List Table 6 Colorful'/>
			<w:lsdException w:name='List Table 7 Colorful'/>
			<w:lsdException w:name='List Table 1 Light Accent 1'/>
			<w:lsdException w:name='List Table 2 Accent 1'/>
			<w:lsdException w:name='List Table 3 Accent 1'/>
			<w:lsdException w:name='List Table 4 Accent 1'/>
			<w:lsdException w:name='List Table 5 Dark Accent 1'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 1'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 1'/>
			<w:lsdException w:name='List Table 1 Light Accent 2'/>
			<w:lsdException w:name='List Table 2 Accent 2'/>
			<w:lsdException w:name='List Table 3 Accent 2'/>
			<w:lsdException w:name='List Table 4 Accent 2'/>
			<w:lsdException w:name='List Table 5 Dark Accent 2'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 2'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 2'/>
			<w:lsdException w:name='List Table 1 Light Accent 3'/>
			<w:lsdException w:name='List Table 2 Accent 3'/>
			<w:lsdException w:name='List Table 3 Accent 3'/>
			<w:lsdException w:name='List Table 4 Accent 3'/>
			<w:lsdException w:name='List Table 5 Dark Accent 3'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 3'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 3'/>
			<w:lsdException w:name='List Table 1 Light Accent 4'/>
			<w:lsdException w:name='List Table 2 Accent 4'/>
			<w:lsdException w:name='List Table 3 Accent 4'/>
			<w:lsdException w:name='List Table 4 Accent 4'/>
			<w:lsdException w:name='List Table 5 Dark Accent 4'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 4'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 4'/>
			<w:lsdException w:name='List Table 1 Light Accent 5'/>
			<w:lsdException w:name='List Table 2 Accent 5'/>
			<w:lsdException w:name='List Table 3 Accent 5'/>
			<w:lsdException w:name='List Table 4 Accent 5'/>
			<w:lsdException w:name='List Table 5 Dark Accent 5'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 5'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 5'/>
			<w:lsdException w:name='List Table 1 Light Accent 6'/>
			<w:lsdException w:name='List Table 2 Accent 6'/>
			<w:lsdException w:name='List Table 3 Accent 6'/>
			<w:lsdException w:name='List Table 4 Accent 6'/>
			<w:lsdException w:name='List Table 5 Dark Accent 6'/>
			<w:lsdException w:name='List Table 6 Colorful Accent 6'/>
			<w:lsdException w:name='List Table 7 Colorful Accent 6'/>
			<w:lsdException w:name='Mention'/>
			<w:lsdException w:name='Smart Hyperlink'/>
			<w:lsdException w:name='Hashtag'/>
			<w:lsdException w:name='Unresolved Mention'/>
			<w:lsdException w:name='Smart Link'/>
		</w:latentStyles>
		<w:style w:type='paragraph' w:default='on' w:styleId='Normal'>
			<w:name w:val='Normal'/>
			<w:rsid w:val='00947702'/>
			<w:pPr>
				<w:spacing w:after='200' w:line='276' w:line-rule='auto'/>
			</w:pPr>
			<w:rPr>
				<w:rFonts w:fareast='Times New Roman' w:cs='Times New Roman'/>
				<wx:font wx:val='Calibri'/>
				<w:sz w:val='22'/>
				<w:sz-cs w:val='22'/>
				<w:lang w:val='TR' w:fareast='TR' w:bidi='AR-SA'/>
			</w:rPr>
		</w:style>
		<w:style w:type='character' w:default='on' w:styleId='DefaultParagraphFont'>
			<w:name w:val='Default Paragraph Font'/>
		</w:style>
		<w:style w:type='table' w:default='on' w:styleId='TableNormal'>
			<w:name w:val='Normal Table'/>
			<wx:uiName wx:val='Table Normal'/>
			<w:rPr>
				<wx:font wx:val='Calibri'/>
				<w:lang w:val='EN-GB' w:fareast='EN-GB' w:bidi='AR-SA'/>
			</w:rPr>
			<w:tblPr>
				<w:tblInd w:w='0' w:type='dxa'/>
				<w:tblCellMar>
					<w:top w:w='0' w:type='dxa'/>
					<w:left w:w='108' w:type='dxa'/>
					<w:bottom w:w='0' w:type='dxa'/>
					<w:right w:w='108' w:type='dxa'/>
				</w:tblCellMar>
			</w:tblPr>
		</w:style>
		<w:style w:type='list' w:default='on' w:styleId='NoList'>
			<w:name w:val='No List'/>
		</w:style>
		<w:style w:type='paragraph' w:styleId='Header'>
			<w:name w:val='header'/>
			<wx:uiName wx:val='Header'/>
			<w:basedOn w:val='Normal'/>
			<w:link w:val='HeaderChar'/>
			<w:rsid w:val='00947702'/>
			<w:pPr>
				<w:tabs>
					<w:tab w:val='center' w:pos='4536'/>
					<w:tab w:val='right' w:pos='9072'/>
				</w:tabs>
				<w:spacing w:after='0' w:line='240' w:line-rule='auto'/>
			</w:pPr>
			<w:rPr>
				<wx:font wx:val='Calibri'/>
			</w:rPr>
		</w:style>
		<w:style w:type='character' w:styleId='HeaderChar'>
			<w:name w:val='Header Char'/>
			<w:link w:val='Header'/>
			<w:rsid w:val='00947702'/>
			<w:rPr>
				<w:rFonts w:ascii='Calibri' w:fareast='Times New Roman' w:h-ansi='Calibri' w:cs='Times New Roman'/>
				<w:lang w:val='TR' w:fareast='TR'/>
			</w:rPr>
		</w:style>
		<w:style w:type='table' w:styleId='TableGrid'>
			<w:name w:val='Table Grid'/>
			<w:basedOn w:val='TableNormal'/>
			<w:rsid w:val='00947702'/>
			<w:rPr>
				<wx:font wx:val='Calibri'/>
				<w:lang w:val='TR'/>
			</w:rPr>
			<w:tblPr>
				<w:tblBorders>
					<w:top w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					<w:left w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					<w:bottom w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					<w:right w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					<w:insideH w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					<w:insideV w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
				</w:tblBorders>
			</w:tblPr>
		</w:style>
	</w:styles>
	<w:shapeDefaults>
		<o:shapedefaults v:ext='edit' spidmax='1026'/>
		<o:shapelayout v:ext='edit'>
			<o:idmap v:ext='edit' data='1'/>
		</o:shapelayout>
	</w:shapeDefaults>
	<w:docPr>
		<w:view w:val='print'/>
		<w:zoom w:percent='100'/>
		<w:doNotEmbedSystemFonts/>
		<w:defaultTabStop w:val='720'/>
		<w:hyphenationZone w:val='425'/>
		<w:punctuationKerning/>
		<w:characterSpacingControl w:val='DontCompress'/>
		<w:optimizeForBrowser/>
		<w:allowPNG/>
		<w:validateAgainstSchema/>
		<w:saveInvalidXML w:val='off'/>
		<w:ignoreMixedContent w:val='off'/>
		<w:alwaysShowPlaceholderText w:val='off'/>
		<w:footnotePr>
			<w:footnote w:type='separator'>
				<w:p wsp:rsidR='00B43DDB' wsp:rsidRDefault='00B43DDB'>
					<w:pPr>
						<w:spacing w:after='0' w:line='240' w:line-rule='auto'/>
					</w:pPr>
					<w:r>
						<w:separator/>
					</w:r>
				</w:p>
			</w:footnote>
			<w:footnote w:type='continuation-separator'>
				<w:p wsp:rsidR='00B43DDB' wsp:rsidRDefault='00B43DDB'>
					<w:pPr>
						<w:spacing w:after='0' w:line='240' w:line-rule='auto'/>
					</w:pPr>
					<w:r>
						<w:continuationSeparator/>
					</w:r>
				</w:p>
			</w:footnote>
		</w:footnotePr>
		<w:endnotePr>
			<w:endnote w:type='separator'>
				<w:p wsp:rsidR='00B43DDB' wsp:rsidRDefault='00B43DDB'>
					<w:pPr>
						<w:spacing w:after='0' w:line='240' w:line-rule='auto'/>
					</w:pPr>
					<w:r>
						<w:separator/>
					</w:r>
				</w:p>
			</w:endnote>
			<w:endnote w:type='continuation-separator'>
				<w:p wsp:rsidR='00B43DDB' wsp:rsidRDefault='00B43DDB'>
					<w:pPr>
						<w:spacing w:after='0' w:line='240' w:line-rule='auto'/>
					</w:pPr>
					<w:r>
						<w:continuationSeparator/>
					</w:r>
				</w:p>
			</w:endnote>
		</w:endnotePr>
		<w:compat>
			<w:breakWrappedTables/>
			<w:snapToGridInCell/>
			<w:wrapTextWithPunct/>
			<w:useAsianBreakRules/>
			<w:dontGrowAutofit/>
		</w:compat>
		<wsp:rsids>
			<wsp:rsidRoot wsp:val='00947702'/>
			<wsp:rsid wsp:val='00014D07'/>
			<wsp:rsid wsp:val='000F12AF'/>
			<wsp:rsid wsp:val='00362844'/>
			<wsp:rsid wsp:val='00364186'/>
			<wsp:rsid wsp:val='004C0B1A'/>
			<wsp:rsid wsp:val='005914F2'/>
			<wsp:rsid wsp:val='007647F4'/>
			<wsp:rsid wsp:val='00947702'/>
			<wsp:rsid wsp:val='00995CC9'/>
			<wsp:rsid wsp:val='009E5D50'/>
			<wsp:rsid wsp:val='00A95E7F'/>
			<wsp:rsid wsp:val='00B43DDB'/>
			<wsp:rsid wsp:val='00DE4B73'/>
		</wsp:rsids>
	</w:docPr>
	<w:body>
		<wx:sect>
			<w:tbl>
				<w:tblPr>
					<w:tblW w:w='0' w:type='auto'/>
					<w:tblBorders>
						<w:top w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
						<w:left w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
						<w:bottom w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
						<w:right w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
						<w:insideH w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
						<w:insideV w:val='single' w:sz='4' wx:bdrwidth='10' w:space='0' w:color='auto'/>
					</w:tblBorders>
					<w:tblLook w:val='04A0'/>
				</w:tblPr>
				<w:tblGrid>
					<w:gridCol w:w='4361'/>
					<w:gridCol w:w='2332'/>
					<w:gridCol w:w='2595'/>
				</w:tblGrid>
				<w:tr wsp:rsidR='00947702' wsp:rsidRPr='00362844' wsp:rsidTr='007647F4'>
					<w:tc>
						<w:tcPr>
							<w:tcW w:w='6693' w:type='dxa'/>
							<w:gridSpan w:val='2'/>
							<w:shd w:val='clear' w:color='auto' w:fill='auto'/>
						</w:tcPr>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t>Yapılan İş: </w:t>
							</w:r>
							<w:r wsp:rsidR='00995CC9' wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t>{dr.yapilan_is_QHt6wvC}</w:t>
							</w:r>
						</w:p>
					</w:tc>
					<w:tc>
						<w:tcPr>
							<w:tcW w:w='2595' w:type='dxa'/>
							<w:shd w:val='clear' w:color='auto' w:fill='auto'/>
						</w:tcPr>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t>Tarih:</w:t>
							</w:r>
							<w:r wsp:rsidR='00995CC9' wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t> {dr.tarih_Rvt9hVm.Day+"."+ dr.tarih_Rvt9hVm.Month+"."+ dr.tarih_Rvt9hVm.Year}</w:t>
							</w:r>
						</w:p>
					</w:tc>
				</w:tr>
				<w:tr wsp:rsidR='00947702' wsp:rsidRPr='00362844' wsp:rsidTr='007647F4'>
					<w:trPr>
						<w:trHeight w:val='11376'/>
					</w:trPr>
					<w:tc>
						<w:tcPr>
							<w:tcW w:w='9288' w:type='dxa'/>
							<w:gridSpan w:val='3'/>
							<w:shd w:val='clear' w:color='auto' w:fill='auto'/>
						</w:tcPr>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t>Açıklama:</w:t>
							</w:r>
							<w:r wsp:rsidR='00014D07' wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:br/>
							</w:r>
							<w:r wsp:rsidR='00995CC9' wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
								<w:t>{dr.aciklama_GT6ExY2}</w:t>
							</w:r>
						</w:p>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
						</w:p>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
						</w:p>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
								</w:rPr>
							</w:pPr>
						</w:p>
					</w:tc>
				</w:tr>
				<w:tr wsp:rsidR='00947702' wsp:rsidRPr='00362844' wsp:rsidTr='007647F4'>
					<w:trPr>
						<w:trHeight w:val='1417'/>
					</w:trPr>
					<w:tc>
						<w:tcPr>
							<w:tcW w:w='4361' w:type='dxa'/>
							<w:shd w:val='clear' w:color='auto' w:fill='auto'/>
						</w:tcPr>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='00272866'>
							<w:pPr>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
									<w:u w:val='thick'/>
								</w:rPr>
								<w:t>ÖĞRENCİNİN;</w:t>
							</w:r>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
									<w:u w:val='thick'/>
								</w:rPr>
								<w:br/>
							</w:r>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
								</w:rPr>
								<w:t> İMZASI:</w:t>
							</w:r>
						</w:p>
					</w:tc>
					<w:tc>
						<w:tcPr>
							<w:tcW w:w='4927' w:type='dxa'/>
							<w:gridSpan w:val='2'/>
							<w:shd w:val='clear' w:color='auto' w:fill='auto'/>
						</w:tcPr>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='007647F4'>
							<w:pPr>
								<w:widowControl w:val='off'/>
								<w:autoSpaceDE w:val='off'/>
								<w:autoSpaceDN w:val='off'/>
								<w:adjustRightInd w:val='off'/>
								<w:snapToGrid w:val='off'/>
								<w:spacing w:line='360' w:line-rule='auto'/>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
									<w:u w:val='thick'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
									<w:u w:val='thick'/>
								</w:rPr>
								<w:t>KURUM SORUMLUSUNUN;</w:t>
							</w:r>
						</w:p>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='007647F4'>
							<w:pPr>
								<w:widowControl w:val='off'/>
								<w:autoSpaceDE w:val='off'/>
								<w:autoSpaceDN w:val='off'/>
								<w:adjustRightInd w:val='off'/>
								<w:snapToGrid w:val='off'/>
								<w:spacing w:line='360' w:line-rule='auto'/>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
								</w:rPr>
								<w:t>ADI VE SOYADI: </w:t>
							</w:r>
						</w:p>
						<w:p wsp:rsidR='00947702' wsp:rsidRPr='007647F4' wsp:rsidRDefault='00947702' wsp:rsidP='007647F4'>
							<w:pPr>
								<w:widowControl w:val='off'/>
								<w:autoSpaceDE w:val='off'/>
								<w:autoSpaceDN w:val='off'/>
								<w:adjustRightInd w:val='off'/>
								<w:snapToGrid w:val='off'/>
								<w:spacing w:line='360' w:line-rule='auto'/>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
								</w:rPr>
							</w:pPr>
							<w:r wsp:rsidRPr='007647F4'>
								<w:rPr>
									<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
									<wx:font wx:val='Times New Roman'/>
									<w:b/>
									<w:b-cs/>
									<w:color w:val='000000'/>
									<w:sz w:val='21'/>
									<w:sz-cs w:val='21'/>
								</w:rPr>
								<w:t>İMZASI: </w:t>
							</w:r>
						</w:p>
					</w:tc>
				</w:tr>
			</w:tbl>
			<w:p wsp:rsidR='00364186' wsp:rsidRPr='00362844' wsp:rsidRDefault='00364186' wsp:rsidP='00995CC9'>
				<w:pPr>
					<w:rPr>
						<w:rFonts w:ascii='Times New Roman' w:h-ansi='Times New Roman'/>
						<wx:font wx:val='Times New Roman'/>
					</w:rPr>
				</w:pPr>
			</w:p>
			<w:sectPr wsp:rsidR='00364186' wsp:rsidRPr='00362844' wsp:rsidSect='009552F5'>
				<w:hdr w:type='odd'>
					<w:p wsp:rsidR='006C1C16' wsp:rsidRPr='006C683F' wsp:rsidRDefault='00B43DDB' wsp:rsidP='006C683F'>
						<w:pPr>
							<w:pStyle w:val='Header'/>
						</w:pPr>
					</w:p>
				</w:hdr>
				<w:hdr w:type='first'>
					<w:p wsp:rsidR='006C1C16' wsp:rsidRDefault='00B43DDB'>
						<w:pPr>
							<w:pStyle w:val='Header'/>
						</w:pPr>
					</w:p>
				</w:hdr>
				<w:pgSz w:w='11906' w:h='16838'/>
				<w:pgMar w:top='1417' w:right='1417' w:bottom='1417' w:left='1417' w:header='709' w:footer='709' w:gutter='0'/>
				<w:cols w:space='708'/>
				<w:titlePg/>
				<w:docGrid w:line-pitch='360'/>
			</w:sectPr>
		</wx:sect>
	</w:body>
</w:wordDocument>";
        }
        
    }
}
