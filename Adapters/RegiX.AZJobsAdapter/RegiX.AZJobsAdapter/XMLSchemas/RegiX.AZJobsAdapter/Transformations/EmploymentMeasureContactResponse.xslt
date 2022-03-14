<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/AZ" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/AZ/EmploymentMeasureContractResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Агенция по заетостта</xsl:text>
						</span>
						<br/>
						<span>
							<xsl:text>Регистър на търсещите работа лица</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по мярка за заетост</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:EmploymentMeasureContractResponse">
						<xsl:choose>
							<xsl:when test="string(.)  = &apos;&apos;">
								<p>
									<span>
										<xsl:text>Няма данни в регистъра за този ЕИК/БУЛСТАТ.</xsl:text>
									</span>
								</p>
							</xsl:when>
							<xsl:otherwise>
								<p>
									<span style="font-weight:bold; ">
										<xsl:text>Данни за работодател</xsl:text>
									</span>
								</p>
								<table border="1" width="100%">
									<tbody>
										<tr>
											<td width="154">
												<span style="font-weight:bold; ">
													<xsl:text>Идентификатор - ЕИК/БУЛСТАТ:</xsl:text>
												</span>
											</td>
											<td>
												<xsl:for-each select="n1:EmployerData">
													<xsl:for-each select="common:EntityID">
														<xsl:apply-templates/>
													</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<td width="154">
												<span style="font-weight:bold; ">
													<xsl:text>Наименование на работодател:</xsl:text>
												</span>
											</td>
											<td>
												<xsl:for-each select="n1:EmployerData">
													<xsl:for-each select="common:EntityName">
														<xsl:apply-templates/>
													</xsl:for-each>
												</xsl:for-each>
											</td>
										</tr>
									</tbody>
								</table>
								<br/>
								<xsl:choose>
									<xsl:when test="string( n1:EmploymentMeasureContracts ) = &apos;&apos;">
										<span>
											<xsl:text>Няма данни за сключени рамкови договори по мярка за заетост.</xsl:text>
										</span>
									</xsl:when>
									<xsl:otherwise>
										<p>
											<span style="font-weight:bold; ">
												<xsl:text>Сключени рамкови договори по мярка за заетост с работодател</xsl:text>
											</span>
										</p>
										<xsl:for-each select="n1:EmploymentMeasureContracts">
											<xsl:for-each select="n1:EmploymentMeasureContract">
												<p>
													<span>
														<xsl:value-of select="position()"/>
													</span>
													<span>
														<xsl:text> от </xsl:text>
													</span>
													<span>
														<xsl:value-of select="count (  ../n1:EmploymentMeasureContract )"/>
													</span>
													<span>
														<xsl:text>: </xsl:text>
													</span>
													<xsl:for-each select="n1:ContractNumber">
														<span>
															<xsl:text>Номер на договор: </xsl:text>
														</span>
														<span style="text-decoration:underline; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</p>
												<table border="1">
													<tbody>
														<tr>
															<td width="375">
																<span style="font-weight:bold; ">
																	<xsl:text>Наименование на мярка за заетост:</xsl:text>
																</span>
															</td>
															<td>
																<xsl:for-each select="n1:EmploymentMeasureName">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
														</tr>
														<tr>
															<td width="375">
																<span style="font-weight:bold; ">
																	<xsl:text>Дата на сключване:</xsl:text>
																</span>
															</td>
															<td>
																<xsl:for-each select="n1:ContractDate">
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
															</td>
														</tr>
														<tr>
															<td width="375">
																<span style="font-weight:bold; ">
																	<xsl:text>Състояние на договор:</xsl:text>
																</span>
															</td>
															<td>
																<xsl:for-each select="n1:ContractStatus">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:otherwise>
								</xsl:choose>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
