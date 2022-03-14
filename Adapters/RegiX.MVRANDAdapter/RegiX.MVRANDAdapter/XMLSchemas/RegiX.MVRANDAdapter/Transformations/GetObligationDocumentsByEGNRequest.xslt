<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MVR/ObligationDocumentsByEGN/GetObligationDocumentsByEGNRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:GetObligationDocumentsByEGNRequest">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Входни параметри на справка за Проверка за налични неплатени документи в АИС АНД на дадено лице</xsl:text>
							</span>
						</h3>
						<xsl:for-each select="n1:EGN">
							<span style="font-style:italic; ">
								<xsl:text>ЕГН на водач, за чиито документи ще бъде изведена информация:</xsl:text>
							</span>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
							<span style="font-weight:bold; ">
								<xsl:apply-templates/>
							</span>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
