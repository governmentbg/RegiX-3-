<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NELK/EISME" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Национална експертна лекарска комисия</xsl:text>
						</span>
						<br/>
						<span>
							<xsl:text>Единна информационна система на медицинската експертиза</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка за експертни решения на лице </xsl:text>
						</span>
					</h2>
					<xsl:choose>
						<xsl:when test="string-length(n1:ExpertDecisionsResponse )&gt;0">
							<xsl:for-each select="n1:ExpertDecisionsResponse">
								<xsl:for-each select="n1:ExpertDecisionDocument">
									<div style="font-size:small; font-weight:bold; " align="left">
										<span>
											<xsl:text>Данни за експертно решение </xsl:text>
										</span>
										<span style="font-size:small; font-style:italic; font-weight:bold; ">
											<xsl:value-of select="position()"/>
										</span>
										<span style="font-style:italic; font-weight:bold; ">
											<xsl:text> от </xsl:text>
										</span>
										<span style="font-size:small; font-style:italic; font-weight:bold; ">
											<xsl:value-of select="count(    /n1:ExpertDecisionsResponse/n1:ExpertDecisionDocument  )"/>
										</span>
									</div>
									<span style="font-weight:bold; ">
										<xsl:text>ЕКСПЕРТНО РЕШЕНИЕ </xsl:text>
									</span>
									<xsl:for-each select="n1:RegistrationNumber">
										<span style="font-weight:bold; ">
											<xsl:text>№ </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:MeetingNumber">
										<span>
											<xsl:text> от зас. №</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:RegistrationDate">
										<span>
											<xsl:text> от дата </xsl:text>
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
									<br/>
									<xsl:choose>
										<xsl:when test="n1:AdditionalData/n1:EmployeeType = 9854">
											<xsl:for-each select="n1:CommissionDescr">
												<span style="font-weight:bold; ">
													<xsl:text>ТЕЛК за:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<xsl:for-each select="n1:CommissionCode">
												<span>
													<xsl:text> ,</xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:text>код </xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:when>
										<xsl:when test="n1:AdditionalData/n1:EmployeeType = 9853">
											<xsl:for-each select="n1:CommissionDescr">
												<span style="font-weight:bold; ">
													<xsl:text>Специализиран състав на НЕЛК по:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<xsl:for-each select="n1:CommissionCode">
												<span>
													<xsl:text>,</xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:text>код </xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:when>
									</xsl:choose>
									<br/>
									<br/>
									<table border="0" width="60%">
										<tbody>
											<tr>
												<td>
													<span style="font-weight:bold; ">
														<xsl:text>Членове: </xsl:text>
													</span>
												</td>
												<td>
													<table border="0">
														<tbody>
															<xsl:for-each select="n1:CommisionMember">
																<tr>
																	<td>
																		<span>
																			<xsl:value-of select="position()"/>
																		</span>
																		<span>
																			<xsl:text>.&#160;&#160;&#160;&#160;&#160; </xsl:text>
																		</span>
																	</td>
																	<td>
																		<xsl:for-each select="n1:Name">
																			<xsl:apply-templates/>
																		</xsl:for-each>
																	</td>
																	<td>
																		<xsl:choose>
																			<xsl:when test="n1:Position =&apos;Председател&apos;">
																				<xsl:for-each select="n1:Position">
																					<span style="font-weight:bold; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:when>
																			<xsl:otherwise>
																				<xsl:for-each select="n1:Position">
																					<xsl:apply-templates/>
																				</xsl:for-each>
																			</xsl:otherwise>
																		</xsl:choose>
																	</td>
																</tr>
															</xsl:for-each>
														</tbody>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
									<br/>
									<table border="0" width="60%">
										<tbody>
											<tr>
												<td align="left">
													<xsl:for-each select="n1:PersonNames">
														<span style="font-weight:bold; ">
															<xsl:text>На</xsl:text>
														</span>
														<span>
															<xsl:text>:&#160; </xsl:text>
														</span>
														<xsl:apply-templates/>
														<span>
															<xsl:text>,</xsl:text>
														</span>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="n1:PersonIdentifier">
														<span style="font-weight:bold; ">
															<xsl:text>ЕГН / ЛНЧ</xsl:text>
														</span>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
									<xsl:for-each select="n1:IdentityDocument">
										<table border="0" width="60%">
											<tbody>
												<tr>
													<td>
														<span style="font-weight:bold; ">
															<xsl:text>Лична карта: </xsl:text>
														</span>
														<xsl:for-each select="n1:DocumentNumber">
															<span style="font-weight:bold; ">
																<xsl:text>№</xsl:text>
															</span>
															<span>
																<xsl:text>&#160;</xsl:text>
															</span>
															<xsl:apply-templates/>
															<span>
																<xsl:text>,</xsl:text>
															</span>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="n1:IssueDate">
															<span style="font-weight:bold; ">
																<xsl:text> дата на издаване </xsl:text>
															</span>
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
															<span>
																<xsl:text>,</xsl:text>
															</span>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="n1:IssuePlace">
															<span style="font-weight:bold; ">
																<xsl:text>място на издаване </xsl:text>
															</span>
															<xsl:apply-templates/>
															<span>
																<xsl:text>,</xsl:text>
															</span>
														</xsl:for-each>
													</td>
													<td>
														<xsl:for-each select="n1:ValidDate">
															<span style="font-weight:bold; ">
																<xsl:text>дата на валидност</xsl:text>
															</span>
															<span>
																<xsl:text>&#160;</xsl:text>
															</span>
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
															<span>
																<xsl:text>г.</xsl:text>
															</span>
														</xsl:for-each>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:if test="n1:AdditionalData/n1:EmployeeType = 9854 and string-length( n1:Parent )&gt;0">
										<xsl:for-each select="n1:Parent">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Законен представител:</xsl:text>
											</span>
											<table border="1" width="40%">
												<tbody>
													<tr>
														<td>
															<xsl:for-each select="n1:PersonNames">
																<xsl:apply-templates/>
															</xsl:for-each>
														</td>
														<td>
															<span>
																<xsl:text>&#160;</xsl:text>
															</span>
															<xsl:for-each select="n1:EGN">
																<span style="font-weight:bold; ">
																	<xsl:text>ЕГН:</xsl:text>
																</span>
																<span>
																	<xsl:text>&#160;</xsl:text>
																</span>
																<xsl:apply-templates/>
															</xsl:for-each>
														</td>
													</tr>
												</tbody>
											</table>
											<xsl:for-each select="n1:IdentityDocument">
												<table border="0" width="60%">
													<tbody>
														<tr>
															<td>
																<span style="font-weight:bold; ">
																	<xsl:text>Лична карта: </xsl:text>
																</span>
																<xsl:for-each select="n1:DocumentNumber">
																	<span style="font-weight:bold; ">
																		<xsl:text>№</xsl:text>
																	</span>
																	<span>
																		<xsl:text>&#160;</xsl:text>
																	</span>
																	<xsl:apply-templates/>
																	<span>
																		<xsl:text>,</xsl:text>
																	</span>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="n1:IssueDate">
																	<span style="font-weight:bold; ">
																		<xsl:text> дата на издаване </xsl:text>
																	</span>
																	<span>
																		<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																		<xsl:text>.</xsl:text>
																		<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																		<xsl:text>.</xsl:text>
																		<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																	</span>
																	<span>
																		<xsl:text>,</xsl:text>
																	</span>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="n1:IssuePlace">
																	<span style="font-weight:bold; ">
																		<xsl:text>място на издаване </xsl:text>
																	</span>
																	<xsl:apply-templates/>
																	<span>
																		<xsl:text>,</xsl:text>
																	</span>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="n1:ValidDate">
																	<span style="font-weight:bold; ">
																		<xsl:text>дата на валидност</xsl:text>
																	</span>
																	<span>
																		<xsl:text>&#160;</xsl:text>
																	</span>
																	<span>
																		<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																		<xsl:text>.</xsl:text>
																		<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																		<xsl:text>.</xsl:text>
																		<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																	</span>
																	<span>
																		<xsl:text>г.</xsl:text>
																	</span>
																</xsl:for-each>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:if>
									<xsl:for-each select="n1:PermanentAddress">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Постоянен адрес: </xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:for-each select="n1:AddressDescription">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
									<xsl:for-each select="n1:TemporaryAddress">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Настоящ адрес:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160; </xsl:text>
										</span>
										<xsl:for-each select="n1:AddressDescription">
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
									<xsl:if test="n1:EmploymentCode &gt;0">
										<xsl:for-each select="n1:Employment">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Трудова заетост: </xsl:text>
											</span>
											<xsl:apply-templates/>
											<span>
												<xsl:text>&#160; </xsl:text>
											</span>
										</xsl:for-each>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:for-each select="n1:Profession">
											<xsl:apply-templates/>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
										</xsl:for-each>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:for-each select="n1:EmploymentCode">
											<span>
												<xsl:text>,</xsl:text>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text>код</xsl:text>
											</span>
											<span>
												<xsl:text> : </xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:if>
									<xsl:choose>
										<xsl:when test="n1:AdditionalData/n1:EmployeeType = 9854 and  n1:ConditionCode &gt;0">
											<xsl:for-each select="n1:ConditionText">
												<br/>
												<span style="font-weight:bold; ">
													<xsl:text>Състояние до експертизата: </xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
													<xsl:text>,</xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:text>&#160;</xsl:text>
												</span>
											</xsl:for-each>
											<xsl:for-each select="n1:ConditionCode">
												<span style="font-weight:bold; ">
													<xsl:text>код:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:when>
										<xsl:when test="n1:AdditionalData/n1:EmployeeType = 9853 and  n1:ConditionCode &gt;0">
											<xsl:for-each select="n1:ConditionText">
												<span style="font-weight:bold; ">
													<xsl:text>Състояние до експертиза в ТЕЛК: </xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
													<xsl:text>,</xsl:text>
												</span>
												<span style="font-weight:bold; ">
													<xsl:text>&#160;</xsl:text>
												</span>
											</xsl:for-each>
											<xsl:for-each select="n1:ConditionCode">
												<span style="font-weight:bold; ">
													<xsl:text>код:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
										</xsl:when>
									</xsl:choose>
									<xsl:if test="n1:AdditionalData/n1:EmployeeType = 9854 and string-length( n1:Appeal )&gt;0">
										<xsl:for-each select="n1:Appeal">
											<xsl:for-each select="n1:RegistrationNumber">
												<br/>
												<span style="font-weight:bold; ">
													<xsl:text>Обжалвано ЕР №</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<xsl:for-each select="n1:RegistrationDate">
												<span style="font-weight:bold; ">
													<xsl:text>от:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<span>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
												</span>
												<span>
													<xsl:text>г.</xsl:text>
												</span>
											</xsl:for-each>
											<xsl:for-each select="n1:Institution">
												<span style="font-weight:bold; ">
													<xsl:text>На ДЕЛК/ТЕЛК/НЕЛК</xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
													<xsl:text>, </xsl:text>
												</span>
											</xsl:for-each>
											<xsl:for-each select="n1:InstitutionCode">
												<span style="font-weight:bold; ">
													<xsl:text>код:</xsl:text>
												</span>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Обжалвани заинтересовани лица и органи:</xsl:text>
											</span>
											<xsl:for-each select="n1:Stakeholders">
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
											</xsl:for-each>
											<xsl:for-each select="n1:StakeholdersCode">
												<span>
													<xsl:text>&#160;</xsl:text>
												</span>
												<xsl:apply-templates/>
											</xsl:for-each>
											<xsl:if test="../n1:DecisionCode &gt;0">
												<xsl:for-each select="n1:Decision">
													<br/>
													<span style="font-weight:bold; ">
														<xsl:text>Решение на ТЕЛК/НЕЛК по обжалвания повод:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
												<xsl:for-each select="n1:DecisionCode">
													<span>
														<xsl:text>, </xsl:text>
													</span>
													<span style="font-weight:bold; ">
														<xsl:text>код:</xsl:text>
													</span>
													<span>
														<xsl:text>&#160;</xsl:text>
													</span>
													<xsl:apply-templates/>
												</xsl:for-each>
											</xsl:if>
										</xsl:for-each>
									</xsl:if>
									<xsl:for-each select="n1:ExpertiseType">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Вид експертиза:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>, </xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:ExpertiseTypeCode">
										<span style="font-weight:bold; ">
											<xsl:text>код: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:ExpertiseDecisionMaking">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Начин на вземане на решеие:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:ExpertiseDecisionMakingCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:ExpertisePlace">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Място на експертиза:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>, </xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:ExpertisePlaceCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:if test="string-length(n1:EmployabilityAssessment)&gt;0">
										<xsl:for-each select="n1:EmployabilityAssessment">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Оценка на работоспособността:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
										</xsl:for-each>
										<xsl:for-each select="n1:EmployabilityAssessmentCode">
											<span>
												<xsl:text>,</xsl:text>
											</span>
											<span style="font-weight:bold; ">
												<xsl:text>код:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:if>
									<xsl:if test="string-length( n1:AppealedHospitalSheets )&gt;0">
										<xsl:for-each select="n1:AppealedHospitalSheets">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Обжалвани болнични листове:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:if>
									<xsl:for-each select="n1:DurationForeignAid">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Срок на чуждата помощ:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
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
									<xsl:for-each select="n1:DurationDisabilityDate">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Срок на определения % трайно намалена работоспособност/вид и степен на увреждане:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<span>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
										</span>
										<span>
											<xsl:text> г. </xsl:text>
										</span>
									</xsl:for-each>
									<xsl:if test="../n1:DurationDisabilityCode &gt;0">
										<xsl:for-each select="n1:DurationDisabilityCode">
											<span style="font-weight:bold; ">
												<xsl:text>,код:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:if>
									<xsl:if test="string-length( n1:DisabilityReason )&gt;0">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Инвалидност по причини:</xsl:text>
										</span>
										<table border="1">
											<thead>
												<tr>
													<th>
														<span>
															<xsl:text>#</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Дата</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>% тр. н. раб.</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Тип</xsl:text>
														</span>
													</th>
												</tr>
											</thead>
											<tbody>
												<xsl:for-each select="n1:DisabilityReason">
													<tr>
														<td align="center">
															<span>
																<xsl:value-of select="position()"/>
															</span>
															<span>
																<xsl:text>.</xsl:text>
															</span>
														</td>
														<td>
															<xsl:for-each select="n1:Date">
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
														<td align="center">
															<xsl:for-each select="n1:Percent">
																<xsl:apply-templates/>
															</xsl:for-each>
														</td>
														<td align="center">
															<xsl:for-each select="n1:Type">
																<xsl:apply-templates/>
															</xsl:for-each>
														</td>
													</tr>
												</xsl:for-each>
											</tbody>
										</table>
									</xsl:if>
									<xsl:for-each select="n1:Diagnosis">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Водеща диагноза:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:DiagnosisCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:GeneralIllness">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Общо заболяване:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:GeneralIllnessCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:WorkAccident">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Трудова злополука:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:WorkAccidentCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:WorkDisease">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Професионално заболяване:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:WorkDiseaseCode">
										<span style="font-weight:bold; ">
											<xsl:text>,код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:MilitaryDisability">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Военна инвалидност:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="n1:MilitaryDisabilityCode">
										<span>
											<xsl:text>,</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>код:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:ContradictionWorkingConditions">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Противопоказни условия на труд:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:if test="n1:AdditionalData/n1:EmployeeType = 9853">
										<xsl:for-each select="n1:RecommendationsForChild">
											<span style="font-weight:bold; ">
												<xsl:text>&#160;</xsl:text>
											</span>
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Препоръки за по-нататъшно наблюдение и рехабилитация за деца до 16 годишна възраст:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:if>
									<br/>
									<h4>
										<span>
											<xsl:text>Констатация от медицинските изследвания, представените документи и мотиви за експертното решение:</xsl:text>
										</span>
									</h4>
									<xsl:for-each select="n1:ArgumentsAndObservations">
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:ReceiptDate">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Дата на получаване на ЕР на ТЕЛК:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<span>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
										</span>
										<span>
											<xsl:text>г.</xsl:text>
										</span>
									</xsl:for-each>
									<br/>
									<hr/>
									<br/>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:when>
						<xsl:otherwise>
							<span>
								<xsl:text>Не са намерени данни в системата по търсените критерии</xsl:text>
							</span>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>