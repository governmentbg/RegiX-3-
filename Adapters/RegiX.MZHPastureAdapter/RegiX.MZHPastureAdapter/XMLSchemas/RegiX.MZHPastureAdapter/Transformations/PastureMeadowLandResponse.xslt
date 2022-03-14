<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/MZH" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MZH/PastureMeadowLandResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:PastureMeadowLandResponse">
						<h2 align="center">
							<span>
								<xsl:text>Справка за ползване на пасища, мери и ливади - резултат</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="string-length(n1:BeneficiaryIdentifier) &gt; 0  or string-length(n1:BeneficiaryName) &gt; 0 or string-length( n1:BeneficiaryType ) &gt;0">
								<xsl:for-each select="n1:BeneficiaryIdentifier">
									<p style="padding-left:5%; ">
										<span style="font-weight:bold; ">
											<xsl:text>Идентификатор на ползвател - ЕГН/ЛНЧ/ЕИК/БУЛСТАТ: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</p>
								</xsl:for-each>
								<xsl:for-each select="n1:BeneficiaryName">
									<p style="padding-left:5%; ">
										<span style="font-weight:bold; ">
											<xsl:text>Наименование на ползвател:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</p>
								</xsl:for-each>
								<xsl:for-each select="n1:BeneficiaryType">
									<p style="padding-left:5%; ">
										<span style="font-weight:bold; ">
											<xsl:text>Вид ползвател:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</p>
								</xsl:for-each>
								<xsl:for-each select="n1:PastureLands">
									<h3 align="center">
										<span>
											<xsl:text>Пасища, мери или ливади на ползвател</xsl:text>
										</span>
									</h3>
									<table align="center" border="1" cellpadding="0" cellspacing="0" width="90%">
										<thead>
											<tr>
												<th style="padding:0.5%; ">
													<span>
														<xsl:text>Област на пасище, мера или ливада</xsl:text>
													</span>
												</th>
												<th style="padding:0.5%; ">
													<span style="padding:0.5%; ">
														<xsl:text>Община </xsl:text>
													</span>
												</th>
												<th style="padding:0.5%; ">
													<span>
														<xsl:text>Землище</xsl:text>
													</span>
												</th>
												<th style="padding:0.5%; ">
													<span>
														<xsl:text>Площ в дка</xsl:text>
													</span>
												</th>
												<th style="padding:0.5%; ">
													<span>
														<xsl:text>Дата на снемане на данните от регистъра</xsl:text>
													</span>
												</th>
											</tr>
										</thead>
										<tbody>
											<xsl:for-each select="n1:PastureLand">
												<tr>
													<td style="padding:0.5%; " align="center">
														<xsl:for-each select="n1:District">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="padding:0.5%; " align="center">
														<xsl:for-each select="n1:Municipality">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="padding:0.5%; " align="center">
														<xsl:for-each select="n1:Territory">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="padding:0.5%; " align="center">
														<xsl:for-each select="n1:Acreage">
															<xsl:apply-templates/>
														</xsl:for-each>
													</td>
													<td style="padding:0.5%; " align="center">
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
