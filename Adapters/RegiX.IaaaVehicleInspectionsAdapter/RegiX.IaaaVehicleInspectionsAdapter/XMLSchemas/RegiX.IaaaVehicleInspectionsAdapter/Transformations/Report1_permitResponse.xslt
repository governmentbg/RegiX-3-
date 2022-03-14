<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/Iaaa/VehicleInspections" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/Iaaa/VehicleInspections/PermitResponse" xmlns:n2="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
							<xsl:text>Справка за статус на регистрацията по ЕИК</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:PermitResponse">
						<xsl:choose>
							<xsl:when test="count( n1:Permits  ) = 0">
								<span>
									<xsl:text>Няма намерени данни в регистъра!</xsl:text>
								</span>
							</xsl:when>
							<xsl:otherwise>
								<xsl:for-each select="n1:Permits">
									<xsl:for-each select="n1:Permit">
										<span style="font-weight:bold; ">
											<xsl:text>Разрешително </xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:value-of select="position( )"/>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text> от </xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:value-of select="count ( ../n1:Permit )"/>
										</span>
										<br/>
										<table border="1" class="table-responsive" width="100%">
											<tbody>
												<tr>
													<td>
														<span>
															<xsl:text>Име на фирма на пункт за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:KtpName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>ЕИК/БУЛСТАТ на фирма на пункт за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:SubjectIdentNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Град на пунктът за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:KtpCityName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Адрес на пунктът за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:KtpAddress">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Категория на пунктът за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:KtpCategoryLabel">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Номер на разрешението за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:PermitNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Областен отдел в който оперира пунктът за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:OrgUnitShortName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Статус код на разрешението за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:PermitStatusCode">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Статус на разрешението за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:PermitStatus">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Дата на първа регистрация</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:FirstRegDate">
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
													<td>
														<span>
															<xsl:text>Дата на валидност</xsl:text>
														</span>
													</td>
													<td>
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
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Дата на последна промяна на разрешението</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:LastChangeDate">
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
													<td>
														<span>
															<xsl:text>Дата на последна промяна на списъка от председатели и членове</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:ListChangeDate">
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
													<td>
														<span>
															<xsl:text>Номера на протоколи от инспекция</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:InspectionProtocols">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Дата на протоколи от инспекция</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:InspectionDate">
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
													<td>
														<span>
															<xsl:text>Дата на закриване, ако е закрито</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:CloseDate">
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
													<td>
														<span>
															<xsl:text>Причина за закриване, ако е закрито</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:CloseReason">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Номер на печат</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:StampNumber">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Бележки, коментар</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:Remarks">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
												<tr>
													<td>
														<span>
															<xsl:text>Брой линии за технически прегледи</xsl:text>
														</span>
													</td>
													<td>
														<xsl:for-each select="common:LineCount">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
												</tr>
											</tbody>
										</table>
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Специалисти работещи в пукта за технически прегледи:</xsl:text>
										</span>
										<br/>
										<table border="1" class="table-responsive">
											<thead>
												<tr>
													<th>
														<span>
															<xsl:text>ЕГН на инспектор в пукнт за технически прегледи</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Име на инспектор в пукнт за технически прегледи</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Текущо състояние (В - включен в списъка, И - изключен от списъка)</xsl:text>
														</span>
													</th>
													<th>
														<span>
															<xsl:text>Дали е председател (Y=Да, N=Не)</xsl:text>
														</span>
													</th>
												</tr>
											</thead>
											<tbody>
												<xsl:for-each select="n1:Inspectors">
													<xsl:for-each select="n1:Inspector">
														<tr>
															<td>
																<xsl:for-each select="common:SubjectIdentNumber">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="common:SubjectFullName">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="common:CurrentStatus">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
															<td>
																<xsl:for-each select="common:IsChairman">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</td>
														</tr>
													</xsl:for-each>
												</xsl:for-each>
											</tbody>
										</table>
										<br/>
										<hr style="height:2px; "/>
										<br/>
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