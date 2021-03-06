<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/GIT/RZZBUT" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/GIT/RZZBUT/ActualDeclarationRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<h3 align="center">
						<span>
							<xsl:text>Входни параметри на справка по ЕГН/ЕИК за актуална декларация</xsl:text>
						</span>
					</h3>
					<table align="center" border="0">
						<tbody>
							<tr>
								<th width="262">
									<span>
										<xsl:text>Идентификатор на декларатора - ЕГН или ЕИК</xsl:text>
									</span>
								</th>
								<xsl:for-each select="n1:ActualDeclarationRequest">
									<td>
										<xsl:for-each select="n1:DeclaratorIdentifier">
											<xsl:apply-templates/>
										</xsl:for-each>
									</td>
								</xsl:for-each>
							</tr>
						</tbody>
					</table>
					<br/>
					<span>
						<xsl:text>&#160;</xsl:text>
					</span>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
