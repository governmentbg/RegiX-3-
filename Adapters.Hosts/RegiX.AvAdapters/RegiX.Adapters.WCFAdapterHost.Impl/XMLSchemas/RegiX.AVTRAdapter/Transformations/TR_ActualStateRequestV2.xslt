<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/AV/TR" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/AV/TR/ActualStateRequestV2" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:import-schema schema-location="D:\Projects\eGov\RegiX\RegiX.AVTRAdapter\XMLSchemas\TR_ActualStateRequestv2.xsd" namespace="http://egov.bg/RegiX/AV/TR/ActualStateRequestV2"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:ActualStateRequestV2">
						<h5>
							<span>
								<xsl:text>Входни параметри на Справка за актуално състояние за вписани обстоятелства</xsl:text>
							</span>
						</h5>
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tbody>
								<tr>
									<td width="187">
										<span style="font-style:italic; ">
											<xsl:text>ЕИК:</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:UIC">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td width="187">
										<span style="font-style:italic; ">
											<xsl:text>Списък с полета: </xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:FieldList">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
