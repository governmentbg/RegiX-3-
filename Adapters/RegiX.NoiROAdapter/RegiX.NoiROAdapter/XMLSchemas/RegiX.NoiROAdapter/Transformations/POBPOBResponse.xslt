<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NOI/RO" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NOI/RO/POBPOBResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:POBPOBResponse">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Национален осигурителен институт</xsl:text>
							</span>
						</h3>
						<h3 align="center">
							<span>
								<xsl:text>Регистър на обезщетенията за болест, майчинство и безработица</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка за изплатено парично обезщетение за безработица по период на обезщетението</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="string-length( . )&gt;0">
								<table border="1" width="100%">
									<tbody>
										<tr>
											<td>
												<xsl:for-each select="n1:IdentifierType">
													<span style="font-style:italic; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
											</td>
											<td>
												<xsl:for-each select="n1:Identifier">
													<span style="font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
											</td>
										</tr>
										<tr>
											<td>
												<span style="font-style:italic; ">
													<xsl:text>Име на лицето</xsl:text>
												</span>
											</td>
											<td>
												<xsl:for-each select="n1:Names">
													<span style="font-weight:bold; ">
														<xsl:apply-templates/>
													</span>
												</xsl:for-each>
											</td>
										</tr>
									</tbody>
								</table>
								<xsl:if test="string-length( n1:MissingData )&gt;0">
									<xsl:for-each select="n1:MissingData">
										<xsl:apply-templates/>
									</xsl:for-each>
								</xsl:if>
								<br/>
								<xsl:if test="string-length( n1:PaymentData )&gt;0">
									<h4>
										<span>
											<xsl:text>На лицето е изплатено парично обезщетение и/или помощ, както следва:</xsl:text>
										</span>
									</h4>
									<xsl:for-each select="n1:PaymentData">
										<xsl:for-each select="common:PaymentByDate">
											<br/>
											<h5>
												<xsl:for-each select="common:RegNumberDate">
													<xsl:apply-templates/>
												</xsl:for-each>
											</h5>
											<table border="1">
												<thead>
													<tr>
														<td align="center" width="220">
															<span style="font-weight:bold; ">
																<xsl:text>Вид парично обезщетение и/или помощ</xsl:text>
															</span>
														</td>
														<td align="center">
															<span style="font-weight:bold; ">
																<xsl:text>Извършени плащания</xsl:text>
															</span>
														</td>
													</tr>
												</thead>
												<tbody>
													<xsl:for-each select="common:PaymentsByType">
														<xsl:for-each select="common:PaymentByType">
															<tr>
																<td>
																	<xsl:for-each select="common:BenefitType">
																		<xsl:apply-templates/>
																	</xsl:for-each>
																</td>
																<td>
																	<xsl:for-each select="common:Payments">
																		<table border="1">
																			<thead>
																				<tr>
																					<th>
																						<span>
																							<xsl:text>Месец</xsl:text>
																						</span>
																					</th>
																					<th>
																						<span>
																							<xsl:text>Година</xsl:text>
																						</span>
																					</th>
																					<th>
																						<span>
																							<xsl:text>Изплатена сума, лв.</xsl:text>
																						</span>
																					</th>
																				</tr>
																			</thead>
																			<tbody>
																				<xsl:for-each select="common:Payment">
																					<tr>
																						<td>
																							<xsl:for-each select="common:BenefitMonth">
																								<xsl:choose>
																									<xsl:when test="contains(  .  , &apos;--05&apos; )">
																										<span>
																											<xsl:text>май</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--06&apos; )">
																										<span>
																											<xsl:text>юни</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--04&apos; )">
																										<span>
																											<xsl:text>април</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--03&apos; )">
																										<span>
																											<xsl:text>март</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--02&apos; )">
																										<span>
																											<xsl:text>февруали</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--01&apos; )">
																										<span>
																											<xsl:text>януари</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--07&apos; )">
																										<span>
																											<xsl:text>юли</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--08&apos; )">
																										<span>
																											<xsl:text>август</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--09&apos; )">
																										<span>
																											<xsl:text>септември</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--10&apos; )">
																										<span>
																											<xsl:text>октомври</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--11&apos; )">
																										<span>
																											<xsl:text>ноември</xsl:text>
																										</span>
																									</xsl:when>
																									<xsl:when test="contains(  .  , &apos;--12&apos; )">
																										<span>
																											<xsl:text>декември</xsl:text>
																										</span>
																									</xsl:when>
																								</xsl:choose>
																							</xsl:for-each>
																						</td>
																						<td>
																							<xsl:for-each select="common:BenefitYear">
																								<xsl:apply-templates/>
																							</xsl:for-each>
																						</td>
																						<td>
																							<xsl:for-each select="common:BenefitAmount">
																								<span>
																									<xsl:value-of select="format-number(number(string(.)), '##0.00')"/>
																								</span>
																							</xsl:for-each>
																						</td>
																					</tr>
																				</xsl:for-each>
																			</tbody>
																		</table>
																	</xsl:for-each>
																</td>
															</tr>
														</xsl:for-each>
													</xsl:for-each>
												</tbody>
											</table>
										</xsl:for-each>
									</xsl:for-each>
								</xsl:if>
							</xsl:when>
							<xsl:otherwise>
								<span>
									<xsl:text>Няма данни в регистъра на обезщетенията за болест, майчинство и безработица по търсените критерии.</xsl:text>
								</span>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
