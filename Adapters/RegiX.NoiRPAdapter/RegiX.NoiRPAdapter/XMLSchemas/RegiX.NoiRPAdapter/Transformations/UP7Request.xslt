<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NOI/RP" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NOI/RP/UP7Request" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:UP7Request">
						<br/>
						<h2 align="center">
							<span>
								<xsl:text>Входни параметри на справка за размер и вид на пенсия и добавка (УП-7)</xsl:text>
							</span>
						</h2>
						<br/>
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
									<td height="23">
										<span style="font-style:italic; ">
											<xsl:text>Месец</xsl:text>
										</span>
									</td>
									<td height="23">
										<xsl:for-each select="n1:Month">
											<xsl:for-each select="common:Month">
												<xsl:choose>
													<xsl:when test="contains(  .  , &apos;--05&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>май</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--06&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>юни</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--04&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>април</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--03&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>март</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--02&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>февруари</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--01&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>януари</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--07&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>юли</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--08&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>август</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--09&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>септември</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--10&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>октомври</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--11&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>ноември</xsl:text>
														</span>
													</xsl:when>
													<xsl:when test="contains(  .  , &apos;--12&apos; )">
														<span style="font-weight:bold; ">
															<xsl:text>декември</xsl:text>
														</span>
													</xsl:when>
												</xsl:choose>
											</xsl:for-each>
										</xsl:for-each>
									</td>
								</tr>
								<tr>
									<td>
										<span style="font-style:italic; ">
											<xsl:text>Година</xsl:text>
										</span>
									</td>
									<td>
										<xsl:for-each select="n1:Month">
											<xsl:for-each select="common:Year">
												<span style="font-weight:bold; ">
													<xsl:apply-templates/>
												</span>
											</xsl:for-each>
										</xsl:for-each>
									</td>
								</tr>
							</tbody>
						</table>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
