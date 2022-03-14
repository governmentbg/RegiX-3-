<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MT/TOInsuranceByEIKResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<xsl:for-each select="n1:TOInsuranceByEIKResponse">
						<h3 align="center">
							<span>
								<xsl:text>Министерство на туризма</xsl:text>
							</span>
							<br/>
							<span>
								<xsl:text>Национален туристически регистър</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Справка за сключена застраховка за туроператор</xsl:text>
							</span>
						</h2>
						<xsl:for-each select="n1:Insurance">
							<div style="font-size:small; font-weight:bold; " align="left">
								<span>
									<xsl:text>За</xsl:text>
								</span>
								<span style="font-weight:bold; ">
									<xsl:text>страховка за туроператор</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<span style="font-style:italic; font-weight:bold; ">
									<xsl:value-of select="position()"/>
								</span>
								<span style="font-style:italic; font-weight:bold; ">
									<xsl:text> от </xsl:text>
								</span>
								<span style="font-style:italic; font-weight:bold; ">
									<xsl:value-of select="count(  /n1:TOInsuranceByEIKResponse/n1:Insurance   )"/>
								</span>
							</div>
							<xsl:for-each select="n1:EIK">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>ЕИК/БУЛСТАТ</xsl:text>
												</span>
											</th>
											<td>
												<xsl:apply-templates/>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="n1:RegNum">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>Номер на регистрация</xsl:text>
												</span>
											</th>
											<td>
												<xsl:apply-templates/>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="n1:InsuranceCompanyName">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>Застрахователна компания</xsl:text>
												</span>
											</th>
											<td>
												<xsl:apply-templates/>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="n1:InsurancePolicyNum">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>Номер на застрахователна полица</xsl:text>
												</span>
											</th>
											<td>
												<xsl:apply-templates/>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="n1:InsuranceIssuedDate">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>Дата на сключване</xsl:text>
												</span>
											</th>
											<td>
												<span>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
												</span>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<xsl:for-each select="n1:InsuranceEndDate">
								<table border="0" width="100%">
									<tbody>
										<tr valign="top">
											<th align="left" width="250px">
												<span style="font-style:italic; font-weight:normal; ">
													<xsl:text>Дата на валидност</xsl:text>
												</span>
											</th>
											<td>
												<span>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
													<xsl:text>.</xsl:text>
													<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
												</span>
											</td>
										</tr>
									</tbody>
								</table>
							</xsl:for-each>
							<br/>
						</xsl:for-each>
					</xsl:for-each>
					<br/>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>