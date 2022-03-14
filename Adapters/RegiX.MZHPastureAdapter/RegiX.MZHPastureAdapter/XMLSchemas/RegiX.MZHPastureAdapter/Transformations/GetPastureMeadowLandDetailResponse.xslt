﻿<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/MZH" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MZH/PastureMeadowLandDetailResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:PastureMeadowLandDetailResponse">
						<h2 align="center">
							<span>
								<xsl:text>Справка с детайли за ползване на пасища, мери и ливади</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="string-length(n1:BeneficiaryIdentifier) &gt; 0  or string-length(n1:BeneficiaryName) &gt; 0 or string-length( n1:BeneficiaryType ) &gt;0">
								<xsl:for-each select="n1:BeneficiaryIdentifier">
									<p style="padding-left:5%; " align="center">
										<span style="font-weight:bold; ">
											<xsl:text>Идентификатор на ползвател - ЕГН/ЛНЧ/ЕИК/БУЛСТАТ: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</p>
								</xsl:for-each>
								<xsl:for-each select="n1:PastureLands">
									<table style="vertical-align:middle; " border="1" cellpadding="0" cellspacing="0" width="100%">
										<thead>
											<tr style="background-color:#d2d2d2; text-align:center; vertical-align:middle; " align="center" valign="middle">
												<th style="border-color:black; padding:0.5%; text-align:center; " align="center" rowspan="2" title="Име" valign="middle">
													<span>
														<xsl:text>Име</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " rowspan="2" title="Област">
													<span>
														<xsl:text>Област</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " rowspan="2" title="Община">
													<span>
														<xsl:text>Община</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " rowspan="2" title="Землище">
													<span>
														<xsl:text>Землище</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " align="center" rowspan="2" title="ЕКАТТЕ">
													<span>
														<xsl:text>ЕКАТТЕ</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " rowspan="2" title="Площ (общо)">
													<span>
														<xsl:text>Площ (общо)</xsl:text>
													</span>
													<br/>
												</th>
												<th style="border-color:black; text-align:center; " align="center" colspan="2">
													<span>
														<xsl:text>По кагегория</xsl:text>
													</span>
												</th>
												<th style="border-color:black; text-align:center; " colspan="3">
													<span>
														<xsl:text>По собственост </xsl:text>
													</span>
												</th>
												<th style="border-color:black; text-align:center; " colspan="2">
													<span>
														<xsl:text>По право на ползване</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " rowspan="2" title="Дата на снемане на данните от регистъра">
													<span>
														<xsl:text>Дата</xsl:text>
													</span>
												</th>
											</tr>
											<tr style="background-color:#d2d2d2; text-align:center; " align="center" valign="middle">
												<th style="border-color:black; padding:0.5%; text-align:center; " align="center" title="Обща площ в дка земи от 1 до 7 категория">
													<span>
														<xsl:text>1 до 7</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка земи от 8 до 10 категория">
													<span>
														<xsl:text>8 до 10</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка земи от ДПФ (държавни)">
													<span>
														<xsl:text>ДПФ</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка земи от ОПФ (общински)">
													<span>
														<xsl:text>ОПФ</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка земи частна собственост">
													<span>
														<xsl:text>частна собств.</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка от договори">
													<span>
														<xsl:text>договори</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " title="Обща площ в дка лична собственост">
													<span>
														<xsl:text>лична собств.</xsl:text>
													</span>
												</th>
											</tr>
											<tr style="background-color:#d2d2d2; text-align:center; vertical-align:middle; " align="center" valign="middle">
												<th style="border-color:black; padding:0.5%; text-align:center; " align="center" height="31" title="Име" valign="middle">
													<span>
														<xsl:text>1</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Област">
													<span>
														<xsl:text>2</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Община">
													<span>
														<xsl:text>3</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Землище">
													<span>
														<xsl:text>4</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="ЕКАТТЕ">
													<span>
														<xsl:text>5</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Площ (общо)">
													<span>
														<xsl:text>6</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " align="center" height="31" title="Обща площ в дка земи от 1 до 7 категория">
													<span>
														<xsl:text>7</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка земи от 8 до 10 категория">
													<span>
														<xsl:text>8</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка земи от ДПФ (държавни)">
													<span>
														<xsl:text>9</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка земи от ОПФ (общински)">
													<span>
														<xsl:text>10</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка земи частна собственост">
													<span>
														<xsl:text>11</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка от договори">
													<span>
														<xsl:text>12</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Обща площ в дка лична собственост">
													<span>
														<xsl:text>13</xsl:text>
													</span>
												</th>
												<th style="border-color:black; padding:0.5%; text-align:center; " height="31" title="Дата на снемане на данните от регистъра">
													<span>
														<xsl:text>14</xsl:text>
													</span>
												</th>
											</tr>
										</thead>
										<tbody>
											<xsl:for-each select="n1:PastureLand">
												<tr style="text-align:left; vertical-align:middle; " align="left" valign="middle">
													<td style="border-color:black; padding:0.5%; " align="left" title="Име" valign="middle">
														<xsl:for-each select="n1:BeneficiaryName">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Област">
														<xsl:for-each select="n1:District">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Община">
														<xsl:for-each select="n1:Municipality">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Землище">
														<xsl:for-each select="n1:SettlementType">
															<xsl:apply-templates/>
															<span>
																<xsl:text>&#160;</xsl:text>
															</span>
														</xsl:for-each>
														<xsl:for-each select="n1:Settlement">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="ЕКАТТЕ">
														<xsl:for-each select="n1:Ekatte">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Площ (общо)">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:Acreage">
																<xsl:apply-templates/>
															</xsl:for-each>
														</xsl:for-each>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка земи от 1 до 7 категория">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:CategoryBreakdown">
																<xsl:for-each select="n1:Area_1_7">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка земи от 8 до 10 категория">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:CategoryBreakdown">
																<xsl:for-each select="n1:Area_8_10">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка земи от ДПФ (държавни)">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:OwnershipBreakdown">
																<xsl:for-each select="n1:Area_DPF">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка земи от ОПФ (общински)">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:OwnershipBreakdown">
																<xsl:for-each select="n1:Area_OPF">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка земи частна собственост">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:OwnershipBreakdown">
																<xsl:for-each select="n1:Area_PRIV">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка от договори">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:LandRightsBreakdown">
																<xsl:for-each select="n1:Area_CONT">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; padding:0.5%; " title="Обща площ в дка лична собственост">
														<xsl:for-each select="n1:AreaDetails">
															<xsl:for-each select="n1:LandRightsBreakdown">
																<xsl:for-each select="n1:Area_PERS">
																	<xsl:apply-templates/>
																</xsl:for-each>
															</xsl:for-each>
														</xsl:for-each>
														<span>
															<xsl:text>&#160;</xsl:text>
														</span>
													</td>
													<td style="border-color:black; " title="Дата на снемане на данните от регистъра">
														<xsl:for-each select="n1:ReportDate">
															<span>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
																<xsl:text>.</xsl:text>
																<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
															</span>
														</xsl:for-each>
													</td>
												</tr>
											</xsl:for-each>
										</tbody>
									</table>
								</xsl:for-each>
							</xsl:when>
							<xsl:otherwise>
								<h3 align="center">
									<span>
										<xsl:text>Не са намерени данни в регистъра по подадените входни параметри!</xsl:text>
									</span>
								</h3>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>