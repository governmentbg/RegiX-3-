<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MP/ChNTs/ForeignerPermissionsResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:ForeignerPermissionsResponse">
						<h3 align="center">
							<span>
								<xsl:text>Министерство на правосъдието</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>Регистър на разрешенията за извършване на дейност с нестопанска цел от чужденци в Република България</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка за издадени/отказани разрешения за извършване на дейност</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>с нестопанска цел в РБ</xsl:text>
							</span>
							<xsl:for-each select="n1:SearchDate">
								<span>
									<xsl:text>, към дата </xsl:text>
								</span>
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
							</xsl:for-each>
						</h2>
						<xsl:choose>
							<xsl:when test="string(  n1:PermissionData  ) != &apos;&apos;">
								<xsl:for-each select="n1:PermissionData">
									<div style="font-size:small; font-weight:bold; " align="left">
										<span>
											<xsl:text>Издадено/отказано разрешение: </xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:value-of select="position()"/>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text> от </xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:value-of select="count(    /n1:ForeignerPermissionsResponse/n1:PermissionData )"/>
										</span>
									</div>
									<xsl:for-each select="n1:NamesCyrillic">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<th align="left" width="250px">
														<span style="font-weight:normal; ">
															<xsl:text>Имена на кирилица</xsl:text>
														</span>
													</th>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="n1:NamesLatin">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<th align="left" width="250px">
														<span style="font-weight:normal; ">
															<xsl:text>Имена на латиница</xsl:text>
														</span>
													</th>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="n1:NationalityCode">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<th align="left" width="250px">
														<span style="font-weight:normal; ">
															<xsl:text>Код на държава</xsl:text>
														</span>
													</th>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="n1:NationalityName">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<th align="left" width="250px">
														<span style="font-weight:normal; ">
															<xsl:text>Националност</xsl:text>
														</span>
													</th>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="n1:StatusName">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<th align="left" width="250px">
														<span style="font-weight:normal; ">
															<xsl:text>Статус</xsl:text>
														</span>
													</th>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:for-each>
									<xsl:for-each select="n1:Resolution">
										<div>
											<span style="font-weight:bold; ">
												<xsl:text>Заповед за разрешение</xsl:text>
											</span>
										</div>
										<xsl:for-each select="n1:OrderNumber">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>Номер</xsl:text>
															</span>
														</th>
														<td>
															<xsl:apply-templates/>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
										<xsl:for-each select="n1:OrderDate">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>Дата</xsl:text>
															</span>
														</th>
														<td>
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
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
									<xsl:for-each select="n1:Permission">
										<div>
											<span style="font-weight:bold; ">
												<xsl:text>Разрешение</xsl:text>
											</span>
										</div>
										<xsl:for-each select="n1:DateFrom">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>Начална дата на валидност</xsl:text>
															</span>
														</th>
														<td>
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
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
										<xsl:for-each select="n1:DateTo">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>Крайна дата на валидност</xsl:text>
															</span>
														</th>
														<td>
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
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
										<xsl:for-each select="n1:ActivityType">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>Вид дейност</xsl:text>
															</span>
														</th>
														<td>
															<xsl:apply-templates/>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
										<xsl:for-each select="n1:NonprofitEntityName">
											<table border="0" width="100%">
												<tbody>
													<tr valign="top">
														<th align="left" width="250px">
															<span style="font-weight:normal; ">
																<xsl:text>ЮЛНСЦ, чрез което извършва дейността</xsl:text>
															</span>
														</th>
														<td>
															<xsl:apply-templates/>
														</td>
													</tr>
												</tbody>
											</table>
										</xsl:for-each>
										<xsl:for-each select="n1:Address">
											<div>
												<span style="font-weight:bold; ">
													<xsl:text>Адрес на дейността</xsl:text>
												</span>
											</div>
											<xsl:for-each select="n1:DistrictName">
												<table border="0" width="100%">
													<tbody>
														<tr valign="top">
															<th align="left" width="250px">
																<span style="font-weight:normal; ">
																	<xsl:text>Област</xsl:text>
																</span>
															</th>
															<td>
																<xsl:apply-templates/>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
											<xsl:for-each select="n1:MunicipalityName">
												<table border="0" width="100%">
													<tbody>
														<tr valign="top">
															<th align="left" width="250px">
																<span style="font-weight:normal; ">
																	<xsl:text>Община</xsl:text>
																</span>
															</th>
															<td>
																<xsl:apply-templates/>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
											<xsl:for-each select="n1:TerritorialUnitName">
												<table border="0" width="100%">
													<tbody>
														<tr valign="top">
															<th align="left" width="250px">
																<span style="font-weight:normal; ">
																	<xsl:text>Населено място</xsl:text>
																</span>
															</th>
															<td>
																<xsl:apply-templates/>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
											<xsl:for-each select="n1:AddressDescription">
												<table border="0" width="100%">
													<tbody>
														<tr valign="top">
															<th align="left" width="250px">
																<span style="font-weight:normal; ">
																	<xsl:text>Описание</xsl:text>
																</span>
															</th>
															<td>
																<xsl:apply-templates/>
															</td>
														</tr>
													</tbody>
												</table>
											</xsl:for-each>
										</xsl:for-each>
									</xsl:for-each>
									<br/>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<p>
									<span>
										<xsl:text>Няма данни в регистъра за издадени/отказани разрешения.</xsl:text>
									</span>
								</p>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
