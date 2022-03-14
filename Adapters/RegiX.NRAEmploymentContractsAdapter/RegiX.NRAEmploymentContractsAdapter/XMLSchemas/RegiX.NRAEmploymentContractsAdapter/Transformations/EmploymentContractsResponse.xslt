<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NRA/EmploymentContracts" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NRA/EmploymentContracts/Response" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:EmploymentContractsResponse">
						<h5 align="center">
							<span>
								<xsl:text>Регистър на уведомленията за трудовите договори и уведомления за промяна на работодател</xsl:text>
							</span>
						</h5>
						<h3 align="center">
							<span>
								<xsl:text>Справка за актуално състояние на </xsl:text>
							</span>
							<xsl:choose>
								<xsl:when test="n1:ContractsFilter =&apos;All&apos;">
									<span>
										<xsl:text>всички</xsl:text>
									</span>
								</xsl:when>
								<xsl:otherwise>
									<span>
										<xsl:text>действащите</xsl:text>
									</span>
								</xsl:otherwise>
							</xsl:choose>
							<span>
								<xsl:text> трудови договори</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>към дата </xsl:text>
							</span>
							<xsl:for-each select="n1:ReportDate">
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
						</h3>
						<xsl:choose>
							<xsl:when test="n1:Status/common:Code =&apos;0&apos;">
								<xsl:choose>
									<xsl:when test="count(n1:EContracts/common:EContract )">
										<xsl:for-each select="n1:EContracts">
											<table border="1" cellpadding="0" cellspacing="0">
												<thead>
													<tr style="padding:5px; ">
														<th valign="top">
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Идентификатор и наименование</xsl:text>
															</span>
														</th>
														<th valign="top">
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>ЕГН и имена на лицето</xsl:text>
															</span>
														</th>
														<th align="center" valign="top">
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Дати</xsl:text>
															</span>
														</th>
														<th align="center">
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Основание по приложение № 1 от Наредба № 5</xsl:text>
															</span>
														</th>
														<th align="center">
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Срок</xsl:text>
															</span>
														</th>
														<th>
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Код КИД</xsl:text>
															</span>
														</th>
														<th>
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>НКПД</xsl:text>
															</span>
														</th>
														<th>
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Код по ЕКАТТЕ</xsl:text>
															</span>
														</th>
														<th>
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Заплата</xsl:text>
															</span>
														</th>
														<th>
															<span style="font-size:small; font-style:italic; font-weight:normal; ">
																<xsl:text>Основание за прекратяване</xsl:text>
															</span>
														</th>
													</tr>
												</thead>
												<tbody>
													<xsl:for-each select="common:EContract">
														<tr style="padding:5px; ">
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length(common:ContractorBulstat )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>ЕГН/ЛНЧ/Сл. номер/БУЛСТАТ</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:ContractorBulstat">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
																<xsl:choose>
																	<xsl:when test="string-length( common:ContractorName )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Наименование</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:ContractorName">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:IndividualEIK )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>ЕГН </xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:IndividualEIK">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
																<xsl:choose>
																	<xsl:when test="string-length( common:IndividualNames )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Имена на лицето</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:IndividualNames">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td align="left" valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:StartDate )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Дата на сключване</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:StartDate">
																			<span>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																			</span>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
																<xsl:choose>
																	<xsl:when test="string-length( common:LastAmendDate )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Дата на последно допълнително споразумение/Промяна на работното място</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:LastAmendDate">
																			<span>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																			</span>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
																<xsl:choose>
																	<xsl:when test="string-length( common:EndDate )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Дата на прекратяване</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:EndDate">
																			<span>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																			</span>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td align="center" valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:Reason  )&gt;0">
																		<xsl:for-each select="common:Reason">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td align="center" valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:TimeLimit )&gt;0">
																		<xsl:for-each select="common:TimeLimit">
																			<span>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																				<xsl:text>.</xsl:text>
																				<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																			</span>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:EcoCode )&gt;0">
																		<xsl:for-each select="common:EcoCode">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:ProfessionCode )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Код НКПД</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:ProfessionCode">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
																<xsl:choose>
																	<xsl:when test="string-length( common:ProfessionName )&gt;0">
																		<div>
																			<span style="font-size:small; font-style:italic; font-weight:normal; ">
																				<xsl:text>Длъжност наименование</xsl:text>
																			</span>
																		</div>
																		<xsl:for-each select="common:ProfessionName">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:EKATTECode )&gt;0">
																		<xsl:for-each select="common:EKATTECode">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>&#160;</xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:choose>
																	<xsl:when test="string-length( common:Remuneration )&gt;0">
																		<xsl:for-each select="common:Remuneration">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</xsl:when>
																	<xsl:otherwise>
																		<span>
																			<xsl:text>--- </xsl:text>
																		</span>
																	</xsl:otherwise>
																</xsl:choose>
															</td>
															<td valign="top">
																<xsl:for-each select="common:LastTermId">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
														</tr>
													</xsl:for-each>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:when>
									<xsl:otherwise>
										<span>
											<xsl:text>Не са открити данни за трудови договори по търсените критерии!</xsl:text>
										</span>
									</xsl:otherwise>
								</xsl:choose>
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
