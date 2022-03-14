<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/GRAO/PNA" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/GRAO/PNA/PermanentAddressResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:PermanentAddressResponse">
						<h3 align="center">
							<span>
								<xsl:text>Министерство на регионалното развитие и благоустройството</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>Класификатор на настоящите и постоянните адреси</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка за постоянен адрес</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="string-length( . ) &gt; 0">
								<xsl:for-each select="n1:DistrictName">
									<xsl:if test="string-length(. )&gt;0">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<td style="padding:4px; vertical-align:top; " width="159">
														<span style="font-style:italic; ">
															<xsl:text>Област</xsl:text>
														</span>
													</td>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="n1:MunicipalityName">
									<xsl:if test="string-length(. )&gt;0">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<td style="padding:4px; vertical-align:top; " width="159">
														<span style="font-style:italic; ">
															<xsl:text>Община</xsl:text>
														</span>
													</td>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="n1:SettlementName">
									<xsl:if test="string-length(. )&gt;0">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<td style="padding:4px; vertical-align:top; " width="159">
														<span style="font-style:italic; ">
															<xsl:text>Населено място</xsl:text>
														</span>
													</td>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</xsl:for-each>
								<xsl:for-each select="n1:CityArea">
									<xsl:if test="string-length(. )&gt;0">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<td style="padding:4px; vertical-align:top; " width="159">
														<span style="font-style:italic; ">
															<xsl:text>Район</xsl:text>
														</span>
													</td>
													<td>
														<xsl:apply-templates/>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</xsl:for-each>
								<xsl:if test="string-length( n1:LocationName )&gt;0 or string-length(  n1:BuildingNumber )&gt;0 or string-length(   n1:Entrance )&gt;0 or string-length(    n1:Floor )&gt;0 or string-length(     n1:Apartment )&gt;0">
									<table border="0" width="100%">
										<tbody>
											<tr valign="top">
												<td style="padding:4px; vertical-align:top; " width="159">
													<span style="font-style:italic; ">
														<xsl:text>Адрес</xsl:text>
													</span>
												</td>
												<td style="padding:4px; vertical-align:top; ">
													<xsl:for-each select="n1:LocationName">
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:BuildingNumber">
														<span>
															<xsl:text> №: </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Entrance">
														<span>
															<xsl:text> вх. </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Floor">
														<span>
															<xsl:text> ет. </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
													<xsl:for-each select="n1:Apartment">
														<span>
															<xsl:text> ап. </xsl:text>
														</span>
														<xsl:apply-templates/>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
								</xsl:if>
								<xsl:for-each select="n1:FromDate">
									<xsl:if test="string-length(. )&gt;0">
										<table border="0" width="100%">
											<tbody>
												<tr valign="top">
													<td style="padding:4px; vertical-align:top; " width="159">
														<span style="font-style:italic; ">
															<xsl:text>Дата на заявяване</xsl:text>
														</span>
													</td>
													<td>
														<span>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
														</span>
														<span>
															<xsl:text> г.</xsl:text>
														</span>
													</td>
												</tr>
											</tbody>
										</table>
									</xsl:if>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<span>
									<xsl:text>В регистъра не са намерени данни за постоянен адрес по подадените ЕГН и дата.</xsl:text>
								</span>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>