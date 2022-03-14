<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/Iaaa/EducationCenters" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsInstructorsReportResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<br/>
					<h3 align="center">
						<span>
							<xsl:text>Изпълнителна агенция „Автомобилна администрация“</xsl:text>
						</span>
					</h3>
					<h3 align="center">
						<span>
							<xsl:text>Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка по лице за вписвания в разрешителни за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:PermitsInstructorsResponse">
						<br/>
						<xsl:choose>
							<xsl:when test="count( n1:Instructor ) = 0">
								<span>
									<xsl:text>Няма намерени данни в&#160; регистъра! </xsl:text>
								</span>
							</xsl:when>
							<xsl:otherwise>
								<xsl:for-each select="n1:Instructor">
									<br/>
									<table style="vertical-align:top; " border="1" width="100%">
										<tbody>
											<tr>
												<td align="center">
													<p>
														<span style="font-weight:bold; ">
															<xsl:text>Данни за инструктор</xsl:text>
														</span>
													</p>
												</td>
												<td align="center" colspan="2" width="654">
													<p align="center">
														<span style="font-weight:bold; ">
															<xsl:text>Разрешения</xsl:text>
														</span>
													</p>
												</td>
											</tr>
											<tr>
												<th align="left" rowspan="3">
													<p style="vertical-align:top; ">
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Пълното име на инструктор: </xsl:text>
														</span>
														<xsl:for-each select="common:SubjectFullName">
															<span style="font-weight:normal; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>EГН на инструктор: </xsl:text>
														</span>
														<xsl:for-each select="common:SubjectIdentNumber">
															<span style="font-weight:normal; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Номер на последно удостоверения за професионална квалификация: </xsl:text>
														</span>
														<xsl:for-each select="common:LastQualificationCertificateNumber">
															<span style="font-weight:normal; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Дата на издаване на последно удостоверения за професионална квалификация: </xsl:text>
														</span>
														<xsl:for-each select="common:LastQualificationCertificateIssueDate">
															<span style="font-weight:normal; ">
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Издадено от на последно удостоверения за професионална квалификация: </xsl:text>
														</span>
														<xsl:for-each select="common:LastQualificationCertificateIssuedBy">
															<span style="font-weight:normal; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Номер на последно издадена шофьорска книжка: </xsl:text>
														</span>
														<xsl:for-each select="common:LastDrivingLicenceCertificateNumber">
															<span style="font-weight:normal; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Дата на издавне на последно издадена шофьорска книжка: </xsl:text>
														</span>
														<xsl:for-each select="common:LastDrivingLicenceCertificateIssueDate">
															<span style="font-weight:normal; ">
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
													</p>
													<br/>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Категории от последно издадена шофьорска книжка:</xsl:text>
														</span>
													</p>
													<ol>
														<xsl:for-each select="common:LastDrivingLicenceCertificateCategories">
															<li>
																<p>
																	<span style="font-size:13px; ">
																		<xsl:apply-templates/>
																	</span>
																</p>
															</li>
														</xsl:for-each>
													</ol>
													<p>
														<span style="font-size:13px; vertical-align:top; ">
															<xsl:text>Притежавание модули за обучение: </xsl:text>
														</span>
													</p>
													<ul>
														<xsl:for-each select="common:ExamModuleNames">
															<xsl:for-each select="common:ExamModuleName">
																<li>
																	<p>
																		<span style="font-size:13px; ">
																			<xsl:apply-templates/>
																		</span>
																	</p>
																</li>
															</xsl:for-each>
														</xsl:for-each>
													</ul>
													<br/>
												</th>
												<td align="left">
													<xsl:for-each select="n1:InstructorPermits">
														<xsl:for-each select="n1:InstructorPermit">
															<p>
																<span style="font-style:italic; ">
																	<xsl:text>Разрешение</xsl:text>
																</span>
																<span style="font-style:italic; ">
																	<xsl:value-of select="position()"/>
																</span>
																<span style="font-style:italic; ">
																	<xsl:text> от </xsl:text>
																</span>
																<span style="font-style:italic; ">
																	<xsl:value-of select="count(../n1:InstructorPermit)"/>
																</span>
															</p>
															<br/>
															<xsl:for-each select="n1:Permit">
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Номер на разрешение</xsl:text>
																</span>
																<span style="font-size:13px; ">
																	<xsl:text>: </xsl:text>
																</span>
																<xsl:for-each select="common:Number">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; ">
																	<xsl:text>: </xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Име на фирмата от разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:CompanyFullName">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>ЕИК/БУЛСТАТ на фирмата от разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:CompanyIdentNumber">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Име на управител на фирмата:</xsl:text>
																</span>
																<span style="font-size:13px; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<xsl:for-each select="common:ManagerFullName">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>ЕГН на управител на фирмата: </xsl:text>
																</span>
																<xsl:for-each select="common:ManagerIdentNumber">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Адрес на фирмата: </xsl:text>
																</span>
																<xsl:for-each select="common:Address">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Тип на разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:PermitType">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Дата на издаване на разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:IssueDate">
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
																<span>
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Дата на валидност на разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:ValidTo">
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
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Дата на прекратяване на разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:CeaseDate">
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
																<span style="font-size:13px; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Пълно име на технически сътрудник:</xsl:text>
																</span>
																<xsl:for-each select="common:TechAssistantFullName">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>ЕГН нa технически сътрудник:</xsl:text>
																</span>
																<xsl:for-each select="common:TechAssistantIdentNumber">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160; </xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Име на Регионалната дирекция в която работи разрешението:</xsl:text>
																</span>
																<span style="font-size:13px; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<xsl:for-each select="common:OrgUnitShortName">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Статус на разрешението: </xsl:text>
																</span>
																<xsl:for-each select="common:Status">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Брой кабинети за даденото разрешение:</xsl:text>
																</span>
																<xsl:for-each select="common:ExamRoomsCount">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>&#160;</xsl:text>
																</span>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Брой места за обучение: </xsl:text>
																</span>
																<xsl:for-each select="common:SeatPlacesCount">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<br/>
																<span style="font-size:13px; font-weight:bold; ">
																	<xsl:text>Брой места за изпит: </xsl:text>
																</span>
																<xsl:for-each select="common:ExamSeatsCount">
																	<xsl:apply-templates/>
																</xsl:for-each>
																<br/>
															</xsl:for-each>
															<span>
																<xsl:text>&#160;</xsl:text>
															</span>
														</xsl:for-each>
													</xsl:for-each>
												</td>
												<td rowspan="3" width="321">
													<xsl:for-each select="n1:InstructorPermits">
														<xsl:for-each select="n1:InstructorPermit">
															<p>
																<span style="font-style:italic; ">
																	<xsl:text>Разрешение</xsl:text>
																</span>
																<span style="font-style:italic; ">
																	<xsl:value-of select="position()"/>
																</span>
																<span style="font-style:italic; ">
																	<xsl:text> от </xsl:text>
																</span>
																<span style="font-style:italic; ">
																	<xsl:value-of select="count(../n1:InstructorPermit)"/>
																</span>
															</p>
															<xsl:for-each select="n1:Permit">
																<xsl:for-each select="n1:Vehicles">
																	<xsl:for-each select="n1:Vehicle">
																		<p>
																			<span style="font-size:13px; font-style:italic; ">
																				<xsl:text>Данни за учебно ППС</xsl:text>
																			</span>
																			<span style="font-size:13px; ">
																				<xsl:text>&#160;</xsl:text>
																			</span>
																			<span>
																				<xsl:value-of select="position()"/>
																			</span>
																			<span style="font-size:13px; ">
																				<xsl:text> от </xsl:text>
																			</span>
																			<span>
																				<xsl:value-of select="count(../n1:Vehicle)"/>
																			</span>
																			<span style="font-size:13px; ">
																				<xsl:text>:</xsl:text>
																			</span>
																		</p>
																		<table border="0" width="100%">
																			<tbody>
																				<tr>
																					<td>
																						<xsl:for-each select="common:RegNumber">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Регистрационне номер на учебни ППС: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:Make">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Марка и модел на ППС:</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:IdentNumber">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>ВИН/Рама на ППС: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:Categories">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Списък с категории на ППС:</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<p>
																								<xsl:apply-templates/>
																							</p>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:ProtocolNumber">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Номер на протокол за учебна дейност на ППС</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:ProtocolDate">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дата на протокол за учебна дейност на </xsl:text>
																							</span>
																							<br/>
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>ППС</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>: </xsl:text>
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
																						<xsl:for-each select="common:MaximumDesignSpeed">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Конструктивна максимална скорост (км/ч)</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:MaxPermittedDefinedMass">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Допустима макс. маса (kg):</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:SeatPlaces">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Брой места за сядане + място на водача</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:Width">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Широчина на ППС: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:Length">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дължина на ППС:</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																					</td>
																					<td>
																						<xsl:for-each select="common:Gears">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Брой предавки:</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:HasABS">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дали ППС има ABS система: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:HasTachograph">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дали ППС има тахограф: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:CargoDepartmentWidth">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Широчина на товарното отделение: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:CargoDepartmentHeight">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Височина на товарното отделение:</xsl:text>
																							</span>
																							<span style="font-size:13px; ">
																								<xsl:text>&#160;</xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:MaxPower">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Максимална мощност (kW): </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:Code78">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дали ППС е по чл. 78 (автоматична скоростна кутия): </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:EngineCapacity">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Обем на двигателя: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:PowerToWeightRatio">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Отношение мощност/тегло (kW/kg): </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:CertificateNumber">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Номер на удостоверение за обучение: </xsl:text>
																							</span>
																							<xsl:apply-templates/>
																						</xsl:for-each>
																						<br/>
																						<br/>
																						<xsl:for-each select="common:CertificateDate">
																							<span style="font-size:13px; font-weight:bold; ">
																								<xsl:text>Дата на издаване на удостоверение за обучение: </xsl:text>
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
																					</td>
																				</tr>
																			</tbody>
																		</table>
																	</xsl:for-each>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td align="center">
													<span style="font-weight:bold; ">
														<xsl:text>Удостоверение за работа в разрешение</xsl:text>
													</span>
												</td>
											</tr>
											<tr>
												<td align="left">
													<xsl:for-each select="n1:InstructorPermits">
														<xsl:for-each select="n1:InstructorPermit">
															<span style="font-style:italic; font-weight:bold; ">
																<xsl:text>Разрешение</xsl:text>
															</span>
															<span style="font-style:italic; font-weight:bold; ">
																<xsl:value-of select="position()"/>
															</span>
															<span style="font-style:italic; font-weight:bold; ">
																<xsl:text> от </xsl:text>
															</span>
															<span style="font-style:italic; font-weight:bold; ">
																<xsl:value-of select="count(../n1:InstructorPermit)"/>
															</span>
															<br/>
															<xsl:for-each select="n1:Certificates">
																<xsl:for-each select="n1:Certificate">
																	<span style="font-size:13px; font-style:italic; ">
																		<xsl:text>Удостоверение </xsl:text>
																	</span>
																	<span style="font-style:italic; ">
																		<xsl:value-of select="position()"/>
																	</span>
																	<span style="font-size:13px; font-style:italic; ">
																		<xsl:text> от </xsl:text>
																	</span>
																	<span style="font-style:italic; ">
																		<xsl:value-of select="count(../n1:Certificate)"/>
																	</span>
																	<span style="font-size:13px; ">
																		<xsl:text>&#160;</xsl:text>
																	</span>
																	<br/>
																	<table border="1">
																		<tbody>
																			<tr>
																				<th>
																					<span style="font-size:13px; ">
																						<xsl:text>Номер на удостоверение за работа в разрешение</xsl:text>
																					</span>
																				</th>
																				<td>
																					<xsl:for-each select="common:PermitCertificateNumber">
																						<xsl:apply-templates/>
																					</xsl:for-each>
																				</td>
																			</tr>
																			<tr>
																				<th>
																					<span style="font-size:13px; ">
																						<xsl:text>Дата на издаване на удостоверение за работа в разрешение</xsl:text>
																					</span>
																				</th>
																				<td>
																					<xsl:for-each select="common:PermitCertificateIssueDate">
																						<span>
																							<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																							<xsl:text>.</xsl:text>
																							<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																							<xsl:text>.</xsl:text>
																							<xsl:value-of select="format-number(number(substring(string(string(string(.))), 2, 3)), '000')"/>
																						</span>
																						<span>
																							<xsl:text> г.</xsl:text>
																						</span>
																					</xsl:for-each>
																				</td>
																			</tr>
																			<tr>
																				<th>
																					<span style="font-size:13px; ">
																						<xsl:text>Тип на удостоверение за работа в разрешение (теория/практика/теория и практика)</xsl:text>
																					</span>
																				</th>
																				<td>
																					<xsl:for-each select="common:ExamTypePermission">
																						<xsl:apply-templates/>
																					</xsl:for-each>
																				</td>
																			</tr>
																		</tbody>
																	</table>
																	<br/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
									<br/>
								</xsl:for-each>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
						<br/>
						<br/>
						<br/>
					</xsl:for-each>
					<br/>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
