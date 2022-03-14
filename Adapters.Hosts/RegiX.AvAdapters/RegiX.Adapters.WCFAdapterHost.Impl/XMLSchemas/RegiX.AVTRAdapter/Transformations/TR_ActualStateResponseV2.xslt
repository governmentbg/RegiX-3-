<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:f="http://egov.bg/RegiX/AV/TR/ActualStateResponseV2" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:choose>
						<xsl:when test="count(f:ActualStateResponseV2/f:Deed )&gt;0">
							<xsl:for-each select="f:ActualStateResponseV2">
								<div align="center">
									<span style="font-weight:bold; ">
										<xsl:text>Справка за актуално състояние</xsl:text>
									</span>
								</div>
								<br/>
								<xsl:for-each select="f:Deed">
									<xsl:for-each select="f:DeedStatus">
										<span>
											<xsl:text>Статус на партида: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:CompanyName">
										<br/>
										<span>
											<xsl:text>Наименование: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:GUID">
										<br/>
										<span>
											<xsl:text>GUID: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:UIC">
										<br/>
										<span>
											<xsl:text>ЕИК: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:LegalForm">
										<br/>
										<span>
											<xsl:text>Правна форма: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:CaseNo">
										<br/>
										<span>
											<xsl:text>Решение на съда: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:CaseYear">
										<span>
											<xsl:text>/</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:CourtNo">
										<span>
											<xsl:text>/</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="f:LiquidationOrInsolvency">
										<br/>
										<span>
											<xsl:text>Ликвидация или несъстоятелност: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<br/>
									<br/>
									<div>
										<span style="font-weight:bold; ">
											<xsl:text>Вписани обстоятелства</xsl:text>
										</span>
									</div>
									<br/>
									<xsl:for-each select="f:Records">
										<table border="0" width="100%">
											<thead>
												<tr>
													<th>
														<span>
															<xsl:text>Поле</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Стойност</xsl:text>
														</span>
													</th>
												</tr>
											</thead>
											<tbody>
												<xsl:for-each select="f:Record">
													<tr>
														<td>
															<xsl:for-each select="f:MainField">
																<xsl:for-each select="f:MainFieldCode">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span>
																	<xsl:text> -&#160; </xsl:text>
																</span>
																<xsl:for-each select="f:MainFieldName">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</td>
														<td>
															<xsl:for-each select="f:RecordData">
																<xsl:apply-templates/>
															</xsl:for-each>
														</td>
													</tr>
												</xsl:for-each>
											</tbody>
										</table>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:when>
						<xsl:otherwise>
							<span>
								<xsl:text>Не са намерени данни за търговско дружество в Търговският регистър по търсените критерии.</xsl:text>
							</span>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>