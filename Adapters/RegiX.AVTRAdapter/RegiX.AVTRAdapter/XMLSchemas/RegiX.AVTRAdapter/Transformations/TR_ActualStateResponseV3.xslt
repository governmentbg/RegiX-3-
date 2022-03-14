<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/AV/TR/SubdeedsCommon" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/AV/TR/ActualStateResponseV3" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:ActualStateResponseV3">
						<h2 align="center">
							<span>
								<xsl:text>Справка за актуално състояние за вписани обстоятелства по раздели</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="n1:DataFound = &apos;true&apos;">
								<xsl:for-each select="n1:Deed">
									<xsl:for-each select="common:DeedStatus">
										<span>
											<xsl:text>Статус на партида: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:CompanyName">
										<br/>
										<span>
											<xsl:text>Наименование: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:GUID">
										<br/>
										<span>
											<xsl:text>GUID: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:UIC">
										<br/>
										<span>
											<xsl:text>ЕИК: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:LegalForm">
										<br/>
										<span>
											<xsl:text>Правна форма: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:CaseNo">
										<br/>
										<span>
											<xsl:text>Решение на съда: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:CaseYear">
										<span>
											<xsl:text>/</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:CourtNo">
										<span>
											<xsl:text>/</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:LiquidationOrInsolvency">
										<br/>
										<span>
											<xsl:text>Ликвидация или несъстоятелност: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<br/>
									<br/>
									<h3>
										<span style="font-weight:bold; ">
											<xsl:text>Вписани обстоятелства по раздели</xsl:text>
										</span>
									</h3>
									<xsl:for-each select="common:Subdeeds">
										<xsl:for-each select="common:Subdeed">
											<xsl:for-each select="@SubUIC">
												<span style="font-weight:bold; ">
													<xsl:text>Номер на раздел/клон:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:value-of select="string(.)"/>
												</span>
												<br/>
											</xsl:for-each>
											<xsl:for-each select="@SubUICType">
												<span style="font-weight:bold; ">
													<xsl:text>Тип на раздел: </xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:value-of select="string(.)"/>
												</span>
												<br/>
											</xsl:for-each>
											<xsl:for-each select="@SubUICName">
												<span style="font-weight:bold; ">
													<xsl:text>Име на раздел/клон: </xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:value-of select="string(.)"/>
												</span>
												<br/>
											</xsl:for-each>
											<xsl:for-each select="@SubdeedStatus">
												<span style="font-weight:bold; ">
													<xsl:text>Статус на раздел: </xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:value-of select="string(.)"/>
												</span>
												<br/>
											</xsl:for-each>
											<br/>
											<br/>
											<xsl:for-each select="common:Records">
												<table border="0" width="100%">
													<thead>
														<tr>
															<th align="left" width="297">
																<span>
																	<xsl:text>Поле</xsl:text>
																</span>
															</th>
															<th align="left">
																<span>
																	<xsl:text>Стойност</xsl:text>
																</span>
															</th>
														</tr>
													</thead>
													<tbody>
														<xsl:for-each select="common:Record">
															<tr>
																<td width="297">
																	<xsl:for-each select="common:MainField">
																		<xsl:for-each select="common:MainFieldCode">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:for-each>
																	<span>
																		<xsl:text> - </xsl:text>
																	</span>
																	<xsl:for-each select="common:MainField">
																		<xsl:for-each select="common:MainFieldName">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="common:RecordData">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</tbody>
												</table>
												<br/>
												<br/>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<br/>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<span>
									<xsl:text>В Търговския регистър не са намерени данни за търговско дружество по търсените критерии.</xsl:text>
								</span>
								<br/>
								<br/>
							</xsl:otherwise>
						</xsl:choose>
						<xsl:for-each select="n1:DataValidForDate">
							<span style="font-style:italic; ">
								<xsl:text>Дата на изготвяне на справката: </xsl:text>
							</span>
							<span style="font-style:italic; ">
								<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
								<xsl:text>.</xsl:text>
								<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
								<xsl:text>.</xsl:text>
								<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
								<xsl:text> г. </xsl:text>
								<xsl:value-of select="format-number(number(substring(string(string(.)), 12, 2)), '00', 'format1')"/>
								<xsl:text>:</xsl:text>
								<xsl:value-of select="format-number(number(substring(string(string(.)), 15, 2)), '00', 'format1')"/>
								<xsl:text> ч.</xsl:text>
							</span>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
