<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NRA/Obligations" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NRA/Obligations/Response" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:ObligationResponse">
						<h3 align="center">
							<span>
								<xsl:text>Национална агенция за приходите</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>Регистър на задължените лица</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка за наличие/липса на задължения</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>към дата </xsl:text>
							</span>
							<xsl:for-each select="n1:ReportDate">
								<span>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
									<xsl:text>.</xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
									<xsl:text>.</xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
								</span>
								<span>
									<xsl:text> г.</xsl:text>
								</span>
							</xsl:for-each>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="n1:Status/common:Code = &apos;0&apos;">
								<div align="center">
									<span>
										<xsl:text>Лицето </xsl:text>
									</span>
									<xsl:for-each select="n1:Name">
										<xsl:apply-templates/>
									</xsl:for-each>
									<span>
										<xsl:text> с </xsl:text>
									</span>
									<xsl:for-each select="n1:Identity">
										<xsl:for-each select="common:TYPE">
											<xsl:choose>
												<xsl:when test=". =&apos;EGN&apos;">
													<span>
														<xsl:text>ЕГН</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=". =&apos;Bulstat&apos;">
													<span>
														<xsl:text>БУЛСТАТ/ЕИК</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=". =&apos;LNC&apos;">
													<span>
														<xsl:text>ЛНЧ</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=".=&apos;SystemNo&apos;">
													<span>
														<xsl:text>сл. номер</xsl:text>
													</span>
												</xsl:when>
												<xsl:when test=".=&apos;BulstatCL&apos;">
													<span>
														<xsl:text>БУЛСТАТ(сл)</xsl:text>
													</span>
												</xsl:when>
											</xsl:choose>
										</xsl:for-each>
										<xsl:for-each select="common:ID">
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
									<xsl:for-each select="n1:ObligationStatus">
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:choose>
											<xsl:when test=". =&apos;ABSENT&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>няма</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test=".=&apos;PRESENT&apos;">
												<span style="font-weight:bold; ">
													<xsl:text>има</xsl:text>
												</span>
											</xsl:when>
										</xsl:choose>
									</xsl:for-each>
									<span>
										<xsl:text> задължения към НАП</xsl:text>
									</span>
									<xsl:if test="n1:Threshold &gt;0">
										<xsl:for-each select="n1:Threshold">
											<span>
												<xsl:text> над въведния праг от </xsl:text>
											</span>
											<xsl:apply-templates/>
											<span>
												<xsl:text> лв</xsl:text>
											</span>
										</xsl:for-each>
									</xsl:if>
									<span>
										<xsl:text>.</xsl:text>
									</span>
								</div>
							</xsl:when>
							<xsl:otherwise>
								<xsl:for-each select="n1:Status">
									<span>
										<xsl:text>Възникна грешка, при търсене на данни от регистъра:</xsl:text>
									</span>
									<br/>
									<xsl:for-each select="common:Code">
										<span>
											<xsl:text>Код на грешка: </xsl:text>
										</span>
										<xsl:choose>
											<xsl:when test=". =1">
												<span>
													<xsl:text>Невалидно XSD</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test=". =&apos;2&apos;">
												<span>
													<xsl:text>Невалиден ЕИК</xsl:text>
												</span>
											</xsl:when>
											<xsl:when test=". =&apos;99&apos;">
												<span>
													<xsl:text>Друго</xsl:text>
												</span>
											</xsl:when>
											<xsl:otherwise>
												<xsl:apply-templates/>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:for-each>
									<xsl:for-each select="common:Message">
										<br/>
										<span>
											<xsl:text>Текст на грешка: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>