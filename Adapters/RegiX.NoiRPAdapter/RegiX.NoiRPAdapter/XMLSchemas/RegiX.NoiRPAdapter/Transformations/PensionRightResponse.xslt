<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NOI/RP" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NOI/RP/PensionRightResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:PensionRightResponse">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Национален осигурителен институт</xsl:text>
							</span>
						</h3>
						<h3 align="center">
							<span>
								<xsl:text>Регистър на пенсионерите</xsl:text>
							</span>
						</h3>
						<xsl:choose>
							<xsl:when test="string-length(n1:Identifier) != 0">
								<h2 align="center">
									<xsl:for-each select="n1:Title">
										<xsl:apply-templates/>
									</xsl:for-each>
								</h2>
								<h4 align="center">
									<xsl:for-each select="n1:TerritorialDivisionNOI">
										<span>
											<xsl:text>Териториално поделение </xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:apply-templates/>
										</span>
									</xsl:for-each>
								</h4>
								<xsl:for-each select="n1:Names">
									<span>
										<xsl:text>Име: </xsl:text>
									</span>
									<xsl:for-each select="common:Name">
										<xsl:apply-templates/>
									</xsl:for-each>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:for-each select="common:Surname">
										<xsl:apply-templates/>
									</xsl:for-each>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:for-each select="common:FamilyName">
										<xsl:apply-templates/>
									</xsl:for-each>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="n1:Identifier">
									<span>
										<xsl:text>ЕГН: </xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="n1:Status">
									<span>
										<xsl:text>Статус на пенсионер: </xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<xsl:for-each select="n1:DateOfDeath">
									<span>
										<xsl:text>Дата на смърт: </xsl:text>
									</span>
									<span>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									</span>
									<span>
										<xsl:text> г.</xsl:text>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="n1:ContentText">
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="n1:PensionCharacteristics">
									<xsl:for-each select="common:PensionCharacteristic">
										<br/>
										<xsl:for-each select="common:DataText">
											<xsl:apply-templates/>
											<span>
												<xsl:text>: </xsl:text>
											</span>
										</xsl:for-each>
										<xsl:for-each select="common:ValueText">
											<xsl:apply-templates/>
										</xsl:for-each>
										<br/>
									</xsl:for-each>
								</xsl:for-each>
								<br/>
							</xsl:when>
							<xsl:otherwise>
								<h2 align="center">
									<br/>
									<span>
										<xsl:text>Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст	&#160;&#160; </xsl:text>
									</span>
									<br/>
								</h2>
								<span>
									<xsl:text>Няма данни в регистъра на пенсионерите по зададените критерии.</xsl:text>
								</span>
								<br/>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
