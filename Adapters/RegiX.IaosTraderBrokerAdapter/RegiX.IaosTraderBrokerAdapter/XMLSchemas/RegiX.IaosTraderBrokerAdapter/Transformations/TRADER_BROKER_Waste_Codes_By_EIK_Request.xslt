<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2016 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:altova="http://www.altova.com" xmlns:altova-xfi="http://www.altova.com/xslt-extensions/xbrl" xmlns:altovaext="http://www.altova.com/xslt-extensions" xmlns:array="http://www.w3.org/2005/xpath-functions/array" xmlns:clitype="clitype" xmlns:common="http://egov.bg/RegiX/IAOS/TraderBroker/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:iso4217="http://www.xbrl.org/2003/iso4217" xmlns:ix="http://www.xbrl.org/2008/inlineXBRL" xmlns:java="java" xmlns:link="http://www.xbrl.org/2003/linkbase" xmlns:map="http://www.w3.org/2005/xpath-functions/map" xmlns:math="http://www.w3.org/2005/xpath-functions/math" xmlns:n1="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKRequest" xmlns:sps="http://www.altova.com/StyleVision/user-xpath-functions" xmlns:xbrldi="http://xbrl.org/2006/xbrldi" xmlns:xbrli="http://www.xbrl.org/2003/instance" xmlns:xff="http://www.xbrl.org/2010/function/formula" xmlns:xfi="http://www.xbrl.org/2008/function/instance" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" exclude-result-prefixes="altova altova-xfi altovaext array clitype common fn iso4217 ix java link map math n1 sps xbrldi xbrli xff xfi xlink xs xsi">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.01 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:variable name="altova:nPxPerIn" select="96"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
				<meta name="generator" content="Altova StyleVision Enterprise Edition 2016 (http://www.altova.com)"/>
				<meta http-equiv="X-UA-Compatible" content="IE=9"/>
				<xsl:comment>[if IE]&gt;&lt;STYLE type=&quot;text/css&quot;&gt;.altova-rotate-left-textbox{filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=3)} .altova-rotate-right-textbox{filter: progid:DXImageTransform.Microsoft.BasicImage(rotation=1)} &lt;/STYLE&gt;&lt;![endif]</xsl:comment>
				<xsl:comment>[if !IE]&gt;&lt;!</xsl:comment>
				<style type="text/css">.altova-rotate-left-textbox{-webkit-transform: rotate(-90deg) translate(-100%, 0%); -webkit-transform-origin: 0% 0%;-moz-transform: rotate(-90deg) translate(-100%, 0%); -moz-transform-origin: 0% 0%;-ms-transform: rotate(-90deg) translate(-100%, 0%); -ms-transform-origin: 0% 0%;}.altova-rotate-right-textbox{-webkit-transform: rotate(90deg) translate(0%, -100%); -webkit-transform-origin: 0% 0%;-moz-transform: rotate(90deg) translate(0%, -100%); -moz-transform-origin: 0% 0%;-ms-transform: rotate(90deg) translate(0%, -100%); -ms-transform-origin: 0% 0%;}</style>
				<xsl:comment>&lt;![endif]</xsl:comment>
				<style type="text/css">@page { margin-left:0.6in; margin-right:0.6in; margin-top:0.79in; margin-bottom:0.79in } @media print { br.altova-page-break { page-break-before: always; } }</style>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h3 align="center">
						<span>
							<xsl:text>Заявка за изготвяне на справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци.</xsl:text>
						</span>
					</h3>
					<br/>
					<table style="width:50%; " align="center" border="0" width="100%">
						<xsl:variable name="altova:CurrContextGrid_0" select="."/>
						<tbody>
							<tr>
								<td align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Eдинен идентификационен код (ЕИК)</xsl:text>
									</span>
								</td>
								<td>
									<xsl:for-each select="n1:TRADER_BROKER_Waste_Codes_By_EIK_Request">
										<xsl:for-each select="n1:EIK">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
								</td>
							</tr>
						</tbody>
					</table>
					<br/>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
