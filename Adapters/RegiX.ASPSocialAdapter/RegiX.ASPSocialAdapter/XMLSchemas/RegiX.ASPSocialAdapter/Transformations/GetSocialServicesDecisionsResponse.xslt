<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/ASP/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/ASP/SocialServices/GetSocialServicesDecisionsResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:GetSocialServicesDecisionsResponse">
						<h3 align="center">
							<span>
								<xsl:text>Министерство на труда и социалната политика</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>Агенция за социално подпомагане</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>към дата </xsl:text>
							</span>
							<xsl:for-each select="n1:CurrentTime">
								<span>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
									<xsl:text>.</xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
									<xsl:text>.</xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									<xsl:text> </xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 12, 2)), '00')"/>
									<xsl:text>:</xsl:text>
									<xsl:value-of select="format-number(number(substring(string(string(.)), 15, 2)), '00')"/>
									<xsl:text>:</xsl:text>
									<xsl:choose>
										<xsl:when test="contains(string(string(.)), 'Z')">
											<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), 'Z'), ':'), ':')), '00')"/>
										</xsl:when>
										<xsl:when test="contains(string(string(.)), '+')">
											<xsl:value-of select="format-number(number(substring-after(substring-after(substring-before(string(string(.)), '+'), ':'), ':')), '00')"/>
										</xsl:when>
										<xsl:when test="contains(substring(string(string(.)), 18), '-')">
											<xsl:value-of select="format-number(number(substring-before(substring(string(string(.)), 18), '-')), '00')"/>
										</xsl:when>
										<xsl:otherwise>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 18)), '00')"/>
										</xsl:otherwise>
									</xsl:choose>
								</span>
								<span>
									<xsl:text> г.</xsl:text>
								</span>
							</xsl:for-each>
						</h2>
						<xsl:for-each select="n1:PersonData">
							<xsl:choose>
								<xsl:when test="count( .) != 0 and count( common:Gender/common:GenderName ) !=  0">
									<h3>
										<span>
											<xsl:text>Данни за лицето</xsl:text>
										</span>
									</h3>
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tbody>
											<tr>
												<td valign="top" width="150">
													<span style="font-style:italic; ">
														<xsl:text>Имена:</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:FirstName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
													<xsl:for-each select="common:MiddleName">
														<span style="font-size:small; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
													<xsl:for-each select="common:LastName">
														<span style="font-size:small; ">
															<xsl:text>&#160;</xsl:text>
														</span>
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
														<br/>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
									<xsl:for-each select="common:BirthDatе">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tbody>
												<tr>
													<td valign="top" width="150">
														<span style="font-size:inherit; font-style:italic; ">
															<xsl:text>Дата на раждане:</xsl:text>
														</span>
													</td>
													<td>
														<span style="font-weight:bold; ">
															<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
														</span>
														<span style="font-weight:bold; ">
															<xsl:text> г</xsl:text>
														</span>
														<span style="font-size:small; ">
															<xsl:text>.</xsl:text>
														</span>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="common:Gender">
										<xsl:for-each select="common:GenderName">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tbody>
													<tr>
														<td valign="top" width="150">
															<span style="font-size:inherit; font-style:italic; ">
																<xsl:text>Пол:</xsl:text>
															</span>
														</td>
														<td>
															<span style="font-weight:bold; ">
																<xsl:apply-templates/>
															</span>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tbody>
											<tr>
												<td valign="top" width="150">
													<xsl:for-each select="common:IdentifierType">
														<xsl:choose>
															<xsl:when test=". = &quot;EGN&quot;">
																<span style="font-style:italic; ">
																	<xsl:text>ЕГН</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test=". = &quot;LNCh&quot;">
																<span style="font-style:italic; ">
																	<xsl:text>ЛНЧ</xsl:text>
																</span>
															</xsl:when>
														</xsl:choose>
														<span style="font-size:small; ">
															<xsl:text>: </xsl:text>
														</span>
													</xsl:for-each>
												</td>
												<td>
													<xsl:for-each select="common:Identifier">
														<span style="font-size:inherit; font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
														<br/>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
								</xsl:when>
								<xsl:when test="count( .) = 0 or count( common:Gender/common:GenderName ) =  0">
									<span style="font-size:small; font-style:italic; ">
										<xsl:text>Няма данни за лицето!</xsl:text>
									</span>
								</xsl:when>
							</xsl:choose>
						</xsl:for-each>
						<br/>
						<xsl:choose>
							<xsl:when test="count( n1:SocialServicesData ) != 0">
								<table style="border-collapse:collapse; font-size:small; " border="1" cellpadding="0" cellspacing="0" width="100%">
									<thead>
										<tr valign="top">
											<th>
												<span>
													<xsl:text>Номер</xsl:text>
												</span>
											</th>
											<th colspan="2">
												<span style="font-size:small; ">
													<xsl:text>Заповед</xsl:text>
												</span>
											</th>
											<th colspan="2">
												<span style="font-size:small; ">
													<xsl:text>Организационна единица, издала заповедта</xsl:text>
												</span>
											</th>
											<th colspan="2">
												<span>
													<xsl:text>Социална услуга</xsl:text>
												</span>
											</th>
											<th colspan="2">
												<span>
													<xsl:text>Вид услуга</xsl:text>
												</span>
											</th>
											<th rowspan="2">
												<span>
													<xsl:text>Контакти</xsl:text>
												</span>
											</th>
										</tr>
										<tr>
											<th/>
											<th>
												<span style="font-size:small; ">
													<xsl:text>№</xsl:text>
												</span>
											</th>
											<th>
												<span style="font-size:small; ">
													<xsl:text>Дата</xsl:text>
												</span>
											</th>
											<th>
												<span style="font-size:small; ">
													<xsl:text>Код</xsl:text>
												</span>
											</th>
											<th>
												<span style="font-size:small; ">
													<xsl:text>Наименование</xsl:text>
												</span>
											</th>
											<th>
												<span>
													<xsl:text>Код</xsl:text>
												</span>
											</th>
											<th>
												<span>
													<xsl:text>Наименование</xsl:text>
												</span>
											</th>
											<th>
												<span style="font-size:small; ">
													<xsl:text>Kод</xsl:text>
												</span>
											</th>
											<th>
												<span style="font-size:small; ">
													<xsl:text>Наименование</xsl:text>
												</span>
											</th>
										</tr>
									</thead>
									<tbody>
										<xsl:for-each select="n1:SocialServicesData">
											<tr valign="top">
												<td style="padding:2px; ">
													<span>
														<xsl:value-of select="position()"/>
													</span>
													<span>
														<xsl:text> от </xsl:text>
													</span>
													<span>
														<xsl:value-of select="count(   ../ n1:SocialServicesData)"/>
													</span>
												</td>
												<td style="padding:2px; ">
													<xsl:for-each select="common:Details">
														<xsl:for-each select="common:DecisionNumber">
															<span style="font-size:small; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</xsl:for-each>
												</td>
												<td style="padding:2px; " align="center">
													<xsl:for-each select="common:Details">
														<xsl:for-each select="common:Date">
															<span style="font-size:small; ">
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
															</span>
														</xsl:for-each>
													</xsl:for-each>
												</td>
												<td style="padding:2px; " align="center">
													<xsl:for-each select="common:Details">
														<xsl:for-each select="common:OrganizationUnitCode">
															<span style="font-size:small; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</xsl:for-each>
												</td>
												<td style="padding:2px; ">
													<xsl:for-each select="common:Details">
														<xsl:for-each select="common:OrganizationUnitName">
															<span style="font-size:small; ">
																<xsl:apply-templates/>
															</span>
														</xsl:for-each>
													</xsl:for-each>
												</td>
												<td style="padding:2px; " align="center">
													<xsl:for-each select="common:SocialServiceCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td style="padding:2px; " align="center">
													<xsl:for-each select="common:SocialServiceName">
														<xsl:apply-templates/>
													</xsl:for-each>
													<span>
														<xsl:text> (</xsl:text>
													</span>
													<xsl:for-each select="common:IsResidentType">
														<xsl:choose>
															<xsl:when test=". = &quot;true&quot;">
																<span style="font-weight:bold; ">
																	<xsl:text>Резидентна</xsl:text>
																</span>
															</xsl:when>
															<xsl:when test=". = &quot;false&quot;">
																<span style="font-weight:bold; ">
																	<xsl:text>Нерезидентна</xsl:text>
																</span>
															</xsl:when>
														</xsl:choose>
													</xsl:for-each>
													<span>
														<xsl:text>)</xsl:text>
													</span>
												</td>
												<td style="padding:2px; " align="center">
													<xsl:for-each select="common:SocialServiceTypeCode">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td style="padding:2px; ">
													<xsl:for-each select="common:SocialServiceType">
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
												<td style="padding:2px; ">
													<xsl:for-each select="common:CityName">
														<span style="font-weight:bold; ">
															<xsl:text>Населено място: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<br/>
													<xsl:for-each select="common:Address">
														<span style="font-weight:bold; ">
															<xsl:text>Адрес: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="common:PhoneNumber">
														<br/>
														<span style="font-weight:bold; ">
															<xsl:text>Телефон: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</xsl:for-each>
									</tbody>
								</table>
							</xsl:when>
							<xsl:when test="count( n1:SocialServicesData ) = 0">
								<span style="font-size:small; font-style:italic; ">
									<xsl:text>Няма данни за заповеди!</xsl:text>
								</span>
							</xsl:when>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>