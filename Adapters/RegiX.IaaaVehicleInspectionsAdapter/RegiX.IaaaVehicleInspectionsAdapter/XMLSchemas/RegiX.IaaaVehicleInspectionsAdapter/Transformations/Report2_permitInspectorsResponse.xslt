<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/Iaaa/VehicleInspections" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/VehicleInspections/PermitInspectorsResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Регистър на издадените разрешения по чл. 2, на председателите на комисиите, извършващи прегледите, и на техническите специалисти</xsl:text>
						</span>
					</h3>
					<h2 align="center">
						<span>
							<xsl:text>Справка по лице за вписвания като председател на комисия/технически специалист в регистрирани пунктове за технически прегледи.</xsl:text>
						</span>
					</h2>
					<xsl:choose>
						<xsl:when test="count( n1:PermitInspectorsResponse/n1:Inspectors ) = 0">
							<span>
								<xsl:text>Няма данни в регистъра!</xsl:text>
							</span>
						</xsl:when>
						<xsl:otherwise>
							<xsl:for-each select="n1:PermitInspectorsResponse">
								<xsl:for-each select="n1:Inspectors">
									<xsl:for-each select="n1:Inspector">
										<br/>
										<span>
											<xsl:text>Данни за инспектор </xsl:text>
										</span>
										<span>
											<xsl:value-of select="position()"/>
										</span>
										<span>
											<xsl:text> от </xsl:text>
										</span>
										<span>
											<xsl:value-of select="count(../n1:Inspector)"/>
										</span>
										<span>
											<xsl:text> :</xsl:text>
										</span>
										<br/>
										<table border="1" width="100%">
											<tbody>
												<tr>
													<td align="center">
														<p align="center">
															<span style="font-weight:bold; ">
																<xsl:text>Данни на инспектор в пукнт за технически прегледи</xsl:text>
															</span>
														</p>
													</td>
													<td align="center">
														<p>
															<span style="font-weight:bold; ">
																<xsl:text>Разрешение в което участва предсетадел/член на комисия за технически преглед</xsl:text>
															</span>
														</p>
													</td>
												</tr>
												<tr>
													<th align="left">
														<p>
															<span>
																<xsl:text>ЕГН на инспектор в пукнт за технически прегледи: </xsl:text>
															</span>
															<xsl:for-each select="common:SubjectIdentNumber">
																<span style="font-style:italic; font-weight:normal; ">
																	<xsl:apply-templates/>
																</span>
															</xsl:for-each>
														</p>
														<br/>
														<p>
															<span>
																<xsl:text>Име на инспектор в пукнт за технически прегледи: </xsl:text>
															</span>
															<xsl:for-each select="common:SubjectFullName">
																<span style="font-style:italic; font-weight:normal; ">
																	<xsl:apply-templates/>
																</span>
															</xsl:for-each>
														</p>
														<br/>
														<p>
															<span>
																<xsl:text>Текущо състояние (В - включен в списъка, И - изключен от списъка): </xsl:text>
															</span>
															<xsl:for-each select="common:CurrentStatus">
																<span style="font-style:italic; font-weight:normal; ">
																	<xsl:apply-templates/>
																</span>
															</xsl:for-each>
														</p>
														<br/>
														<p>
															<span>
																<xsl:text>Дали е председател (Y=Да, N=Не): </xsl:text>
															</span>
															<xsl:for-each select="common:IsChairman">
																<span style="font-style:italic; font-weight:normal; ">
																	<xsl:apply-templates/>
																</span>
															</xsl:for-each>
														</p>
													</th>
													<td>
														<table border="0" width="100%">
															<tbody>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Име на фирма на пункт за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:KtpName">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Статус код на разрешението за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:PermitStatusCode">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>ЕИК/БУЛСТАТ на фирма на пункт за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:SubjectIdentNumber">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Статус на разрешението за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:PermitStatus">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Град на пунктът за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:KtpCityName">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на първа регистрация: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:FirstRegDate">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span style="font-weight:bold; ">
																						<xsl:text>&#160;</xsl:text>
																					</span>
																					<span>
																						<xsl:text>г.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Адрес на пунктът за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:KtpAddress">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на валидност: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:ValidTo">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span>
																						<xsl:text>&#160;</xsl:text>
																					</span>
																					<span style="font-weight:normal; ">
																						<xsl:text>г.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Категория на пунктът за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:KtpCategoryLabel">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на последна промяна на разрешението: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:LastChangeDate">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span>
																						<xsl:text>&#160;</xsl:text>
																					</span>
																					<span style="font-weight:normal; ">
																						<xsl:text>г.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Номер на разрешението за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:PermitNumber">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на последна промяна на списъка от председатели и членове: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:ListChangeDate">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span>
																						<xsl:text>&#160;</xsl:text>
																					</span>
																					<span style="font-weight:normal; ">
																						<xsl:text>г.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Областен отдел в който оперира пунктът за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:OrgUnitShortName">
																					<span style="font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																			<span>
																				<xsl:text>&#160;</xsl:text>
																			</span>
																		</p>
																	</th>
																	<th align="left" rowspan="3">
																		<p>
																			<span>
																				<xsl:text>Номера на протоколи от инспекция: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:InspectionProtocols">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на протоколи от инспекция: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:InspectionDate">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span style="font-weight:normal; ">
																						<xsl:text> г</xsl:text>
																					</span>
																					<span>
																						<xsl:text>.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Дата на закриване, ако е закрито: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:CloseDate">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																						<xsl:text>.</xsl:text>
																						<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
																					</span>
																					<span style="font-weight:normal; ">
																						<xsl:text> г.</xsl:text>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left" height="1" rowspan="3">
																		<p>
																			<span>
																				<xsl:text>Причина за закриване, ако е закрито: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:CloseReason">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																	<th align="left" height="1">
																		<p>
																			<span>
																				<xsl:text>Номер на печат: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:StampNumber">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Бележки, коментар: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:Remarks">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
																<tr>
																	<th align="left">
																		<p>
																			<span>
																				<xsl:text>Брой линии за технически прегледи: </xsl:text>
																			</span>
																			<xsl:for-each select="n1:Permit">
																				<xsl:for-each select="common:LineCount">
																					<span style="font-style:italic; font-weight:normal; ">
																						<xsl:apply-templates/>
																					</span>
																				</xsl:for-each>
																			</xsl:for-each>
																		</p>
																	</th>
																</tr>
															</tbody>
														</table>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
