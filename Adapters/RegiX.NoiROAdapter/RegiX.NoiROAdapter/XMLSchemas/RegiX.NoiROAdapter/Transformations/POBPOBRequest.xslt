<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NOI/RO" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NOI/RO/POBPOBRequest" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:decimal-format name="format1" grouping-separator=" " decimal-separator=","/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:POBPOBRequest">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Входни параметри на справка за изплатено парично обезщетение за безработица по период на обезщетението</xsl:text>
							</span>
						</h3>
						<table border="0" width="100%">
							<tbody>
								<tr>
									<td>
										<xsl:choose>
											<xsl:when test="n1:IdentifierType = &apos;EGN&apos; or n1:IdentifierType = &apos;ЕГН&apos;">
												<span style="font-style:italic; ">
													<xsl:text>ЕГН</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test="n1:IdentifierType = &apos;LNCh&apos; or n1:IdentifierType = &apos;ЛНЧ&apos;">
												<span style="font-style:italic; ">
													<xsl:text>ЛНЧ</xsl:text>
												</span>
											</xsl:when>
											<xsl:otherwise>
												<span style="font-style:italic; ">
													<xsl:text>Идентификатор</xsl:text>
												</span>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td>
										<xsl:for-each select="n1:Identifier">
											<span style="font-weight:bold; ">
												<xsl:apply-templates/>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-style:italic; ">
											<xsl:text>Начало на период</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:DateFrom">
											<span style="font-weight:bold; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text>г.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-style:italic; ">
											<xsl:text>Край на период</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:DateTo">
											<span style="font-weight:bold; ">
												<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
												<xsl:text>.</xsl:text>
												<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text> г.</xsl:text>
											</span>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
						<br/>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
