<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/IAOS/TraderBroker/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/IAOS/TraderBroker/WasteCodesByEIKResponseV2" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
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
					<h2 align="center">
						<span>
							<xsl:text>Справка за кодове на отпадъци в Регистър на лицата, извършващи дейности като търговец и/или като брокер на отпадъци (Версия 2).</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="n1:TRADER_BROKER_Waste_Codes_By_EIK_ResponseV2">
						<xsl:for-each select="n1:Authorization">
							<br/>
							<table border="1">
								<tbody>
									<tr>
										<th align="left">
											<span>
												<xsl:text>Регистрационен номер</xsl:text>
											</span>
										</th>
										<td>
											<xsl:for-each select="n1:AuthNum">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<th align="left">
											<span>
												<xsl:text>Тип на регистрацията</xsl:text>
											</span>
										</th>
										<td>
											<xsl:for-each select="n1:AuthType">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<th align="left">
											<span>
												<xsl:text>Наименование на организацията</xsl:text>
											</span>
										</th>
										<td>
											<xsl:for-each select="n1:CompanyName">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
									<tr>
										<th align="left" height="82">
											<span>
												<xsl:text>Статус</xsl:text>
											</span>
										</th>
										<td>
											<xsl:for-each select="n1:State">
												<xsl:apply-templates/>
											</xsl:for-each>
										</td>
									</tr>
								</tbody>
							</table>
							<xsl:for-each select="n1:WasteOperationCodes">
								<xsl:for-each select="n1:WasteOperationCode">
									<xsl:for-each select="n1:WasteOperation">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Операция:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="n1:WasteOperationsCode">
										<xsl:for-each select="n1:WasteCode">
											<br/>
											<span style="font-weight:bold; ">
												<xsl:text>Код на отпадък:</xsl:text>
											</span>
											<span>
												<xsl:text>&#160;</xsl:text>
											</span>
											<xsl:apply-templates/>
										</xsl:for-each>
									</xsl:for-each>
									<br/>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
